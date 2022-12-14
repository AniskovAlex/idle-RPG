using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUp : PowerUp
{
    public override void Power()
    {
        idel.AddDamage(addProg);
        base.Power();
    }
}
