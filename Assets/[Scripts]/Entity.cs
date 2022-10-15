using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float verticalSpeed;
    public Transform bulletSpawnPoint;
    public float fireRate = 0.2f;

    protected BulletManager bulletManager;

    public virtual void Move()
    {
        // For Player and Enemy Movement
    }

    public virtual void FireBullets()
    {
        // For Player and Enemy Bullet Firing
    }
}
