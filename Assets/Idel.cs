using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idel : MonoBehaviour
{
    [SerializeField] Projectaile projectaile;
    [SerializeField] GameObject field;
    [SerializeField] MoneyController moneyController;
    [SerializeField] float maxHealth = 10;
    [SerializeField] float shootDelay = 1f;
    [SerializeField] float damageAttack = 1f;
    float timer = 0;

    GameManager manager;
    bool isShooting = false;
    Transform target;
    HpController hp;
    List<Enemy> enemies = new List<Enemy>();

    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
        GlobaleStatus.enemyDestroyed += StopShoot;
        GlobaleStatus.enemyDestroyed += TakeMoney;
        hp = GetComponentInChildren<HpController>();
        if (hp != null)
            hp.SetMaxHealth(maxHealth);
    }

    public void StartShoot(Enemy target)
    {
        if (this.target == null)
            this.target = target.transform;
        enemies.Add(target);
        isShooting = true;
        timer = 0;
    }

    public void StopShoot(Enemy target)
    {
        enemies.Remove(target);
        if (enemies.Count > 0)
        {
            this.target = enemies[0].transform;
            return;
        }
        isShooting = false;
        target = null;
        timer = 0;
        GlobaleStatus.switchState();
    }

    public void TakeDamage(float damage)
    {
        if (hp != null && hp.TakeDamage(damage) && manager != null)
            manager.ResetGame();
    }

    public void TakeMoney(Enemy enemy)
    {
        moneyController.AddMoney(enemy.GetMoney());
    }

    private void Update()
    {
        if (target == null) return;
        if (!isShooting) return;
        timer -= Time.deltaTime;
        if (timer > 0) return;
        Projectaile newProjectail;
        if (field != null)
            newProjectail = Instantiate(projectaile, transform.position + (Vector3.right * 0.2f), Quaternion.identity, field.transform);
        else
            newProjectail = Instantiate(projectaile);
        newProjectail.target = target;
        newProjectail.Launch(damageAttack);
        timer = shootDelay;

    }

    public void AddDamage(float prog)
    {
        damageAttack *= prog;
    }
    public void AddSpeed(float prog)
    {
        shootDelay /= prog;
    }
}
