using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : PowerUp
{
    public override void Power()
    {
        idel.AddSpeed(addProg);
        base.Power();
    }
}
