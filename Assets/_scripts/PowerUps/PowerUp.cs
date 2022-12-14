using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class PowerUp : MonoBehaviour
{
    [SerializeField] int cost;
    [SerializeField] protected float costProg;
    [SerializeField] protected float addProg;
    Text costText;
    PowerUpController controller;
    protected Idel idel;
    Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        controller = GetComponentInParent<PowerUpController>();
        TextIndex index = GetComponentInChildren<TextIndex>();
        if (index != null)
            costText = index.GetComponent<Text>();
        if (costText != null)
            costText.text = cost.ToString();
        if (controller != null)
            idel = controller.GetIdel();
        if (button != null)
            button.onClick.AddListener(delegate { Power(); });
    }

    public virtual void Power()
    {
        int buf = cost;
        SetCost();
        if (costText != null)
            costText.text = cost.ToString();
        controller.Pay(buf);
    }

    public int GetCost()
    {
        return cost;
    }

    protected void SetCost()
    {
        cost = (int)(cost * costProg);
    }

    public void Lock()
    {
        button.interactable = false;
    }

    public void UnLock()
    {
        button.interactable = true;
    }
}
