using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyController : MonoBehaviour
{
    [SerializeField] Text moneyText;
    [SerializeField] PowerUpController powerUp;
    int currentMoney;
    public void AddMoney(int money)
    {
        currentMoney += money;
        UpdateMoney();
    }

    public void ConMoney(int money)
    {
        currentMoney = Mathf.Clamp(currentMoney - money, 0, 1000000);
        UpdateMoney();
    }

    public void UpdateMoney()
    {
        moneyText.text = currentMoney.ToString();
        powerUp.Check(currentMoney);
    }
}
