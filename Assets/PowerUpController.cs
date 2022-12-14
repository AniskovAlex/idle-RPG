using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    [SerializeField] Idel idel;
    [SerializeField] MoneyController money;
    PowerUp[] list;
    private void Start()
    {
        list = GetComponentsInChildren<PowerUp>();
    }

    public Idel GetIdel()
    {
        return idel;
    }
        
    public void Pay(int moneyPay)
    {
        money.ConMoney(moneyPay);
    }

    public void Check(int bank)
    {
        foreach(PowerUp x in list)
        {
            if (bank >= x.GetCost())
                x.UnLock();
            else
                x.Lock();
        }
    }

}
