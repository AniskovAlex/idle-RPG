using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float damage = 1;
    [SerializeField] float atackSpeed = 1;
    [SerializeField] HpController hp;
    [SerializeField] Text damageText;
    [SerializeField] float maxHp;
    public bool stay = false;
    float globaleSpeed = 0;

    Idel idel;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        globaleSpeed = GlobaleStatus.GetSpeed();
        hp.SetMaxHealth(maxHp);
    }

    // Update is called once per frame
    void Update()
    {
        if (stay)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                idel.TakeDamage(damage);
                timer = atackSpeed;
            }
            return;
        }
        float sumSpeed = speed;
        if (GlobaleStatus.GetState() == GlobaleStatus.StatePos.move) sumSpeed += globaleSpeed;
        transform.position += (Vector3.left * sumSpeed) * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Projectaile projectaile;
        if (collision.gameObject.TryGetComponent(out projectaile))
        {
            LaunchText((int)projectaile.GetDamage());
            if (hp.TakeDamage(projectaile.GetDamage()))
                Destroy(gameObject);
        }
    }

    public void Attack(Idel idel)
    {
        this.idel = idel;
        idel.TakeDamage(damage);
        timer = atackSpeed;
        stay = true;
    }
    public void Attack()
    {
        if (idel == null)
        {
            stay = false;
            return;
        }
        idel.TakeDamage(damage);
        timer = atackSpeed;
    }

    public int GetMoney()
    {
        return Random.Range(10, 26);
    }

    void LaunchText(int damage)
    {
        Instantiate(damageText, transform.position + Vector3.up * 2, Quaternion.identity, hp.transform).text = damage.ToString();
    }

    private void OnDestroy()
    {
        GlobaleStatus.enemyDestroyed(this);
    }
}
