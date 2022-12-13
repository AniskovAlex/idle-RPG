using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTrigger : MonoBehaviour
{
    Idel idel;
    private void Start()
    {
        idel = GetComponent<Idel>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy;
        if (other.TryGetComponent(out enemy))
        {
            if (GlobaleStatus.GetState() == GlobaleStatus.StatePos.move)
                GlobaleStatus.switchState();
            idel.StartShoot(enemy);
        }
    }
}
