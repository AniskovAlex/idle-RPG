using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    Enemy enemy;

    void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Idel idel;
        if (other.gameObject.TryGetComponent(out idel))
        {
            if (enemy == null) return;
            enemy.Attack(idel);
        }
    }
}
