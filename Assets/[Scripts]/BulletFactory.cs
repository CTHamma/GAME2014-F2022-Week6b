using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class BulletFactory : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Sprite playerBulletSprite;
    public Sprite enemyBulletSprite;

    public Transform bulletParent;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Initialize()
    {
        playerBulletSprite = Resources.Load<Sprite>("Sprites/Bullet");
        enemyBulletSprite = Resources.Load<Sprite>("Sprites/EnemySmallBullet");
        bulletPrefab = Resources.Load<GameObject>("Prefabs/PlayerBullet");
        bulletParent = GameObject.Find("Bullets").transform;
    }

    public GameObject CreateBullet(BulletType type)
    {
        GameObject bullet = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity, bulletParent);

        switch (type)
        {
            case BulletType.PLAYER:
                bullet.GetComponent<SpriteRenderer>().sprite = playerBulletSprite;
                bullet.GetComponent<BulletBehaviour>().SetDirection(BulletDirection.UP);
                break;
                case BulletType.ENEMY:
                bullet.GetComponent<SpriteRenderer>().sprite = enemyBulletSprite;
                bullet.GetComponent<BulletBehaviour>().SetDirection(BulletDirection.DOWN);
                bullet.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
                break;
        }

        bullet.SetActive(true);
        return bullet;
    }
}