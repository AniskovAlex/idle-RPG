using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpController : MonoBehaviour
{
    [SerializeField] GameObject currentHpObj;
    float maxWidth;
    float maxHealth = 1;
    float currentHp;
    float barPerHp;
    RectTransform healthBar;

    private void Awake()
    {
        healthBar = currentHpObj.GetComponent<RectTransform>();
        if (healthBar == null) return;
        maxWidth = healthBar.sizeDelta.x;
    }

    public void SetMaxHealth(float hp)
    {
        maxHealth = hp;
        currentHp = maxHealth;
        barPerHp = maxWidth / maxHealth;
    }

    public bool TakeDamage(float damage)
    {
        currentHp -= damage;
        healthBar.sizeDelta = new Vector2( Mathf.Clamp(currentHp * barPerHp, 0, maxWidth), healthBar.sizeDelta.y);
        if (currentHp <= 0)
            return true;
        return false;
    }
}
