using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectaile : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float turnSpeed = 0.1f;
    [SerializeField] float damage = 2f;
    float deathTimer = 0.2f;
    public Transform target;

    private void Start()
    {
    }

    public void Launch()
    {
        if (target != null)
            transform.LookAt(target.position);
        transform.Rotate(new Vector3(0, Random.Range(-80, 80), Random.Range(-20, 80)));
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 targetDir = (target.position - transform.position).normalized;
            Quaternion rot = Quaternion.LookRotation(targetDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, turnSpeed);
            transform.position += (transform.forward * speed) * Time.deltaTime;
        }
        else
        {
            transform.position += (transform.forward * speed) * Time.deltaTime;
            deathTimer -= Time.deltaTime;
            if (deathTimer <= 0)
                Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy;
        if (collision.gameObject.TryGetComponent(out enemy))
        {
            Destroy(gameObject);
        }
    }

    public float GetDamage()
    {
        return damage;
    }
}
