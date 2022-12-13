using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idel : MonoBehaviour
{
    [SerializeField] Projectaile projectaile;
    [SerializeField] GameObject field;
    [SerializeField] float shootDelay = 1f;
    float timer = 0;

    bool isShooting = false;
    Transform target;
    List<Enemy> enemies = new List<Enemy>();

    private void Start()
    {
        GlobaleStatus.enemyDestroyed += StopShoot;
    }

    public void StartShoot(Enemy target)
    {
        if (this.target == null)
            this.target = target.transform;
        enemies.Add(target);
        isShooting = true;
        timer = shootDelay;
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
        newProjectail.Launch();
        timer = shootDelay;

    }
}
