using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] HpController hp;
    [SerializeField] float maxHp;
    float globaleSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        globaleSpeed = GlobaleStatus.GetSpeed();
        hp.SetMaxHealth(maxHp);
    }

    // Update is called once per frame
    void Update()
    {
        float sumSpeed = speed;
        if (GlobaleStatus.GetState() == GlobaleStatus.StatePos.move) sumSpeed += globaleSpeed;
        transform.position += (Vector3.left * sumSpeed) * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Projectaile projectaile;
        if (collision.gameObject.TryGetComponent(out projectaile))
        {
            if (hp.TakeDamage(projectaile.GetDamage()))
                Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        GlobaleStatus.enemyDestroyed(this);
    }
}
