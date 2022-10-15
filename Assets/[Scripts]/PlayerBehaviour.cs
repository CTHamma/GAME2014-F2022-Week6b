using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : Entity
{
    [Header("Player Properties")]
    public float moveSpeed = 10.0f;
    public Boundary boundary;
    public float veritcalPos;
    public bool usingMobileInput = false;

    private ScoreManager scoreManager;
    private Camera camera;

    private void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();

        camera = Camera.main;

        usingMobileInput = Application.platform == RuntimePlatform.Android ||
                            Application.platform == RuntimePlatform.IPhonePlayer;

        scoreManager = FindObjectOfType<ScoreManager>();

        InvokeRepeating("FireBullets", 0.0f, fireRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (usingMobileInput)
        {
            MobileInput();
        }
        else
        {
            ConventionalInput();
        }
        Move();

        if(Input.GetKeyDown(KeyCode.K))
        {
            scoreManager.AddPoints(10);
        }
    }

    public override void Move()
    {
        float clampedPosition = Mathf.Clamp(transform.position.x, boundary.min, boundary.max);
        transform.position = new Vector2(clampedPosition, veritcalPos);
    }

    public void MobileInput()
    {
        foreach (var touch in Input.touches)
        {
            var destination = camera.ScreenToWorldPoint(touch.position);
            transform.position = Vector2.Lerp(transform.position, destination, Time.deltaTime * verticalSpeed);
        }
    }

    public void ConventionalInput()
    {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed;
        transform.position += new Vector3(x, 0, 0);

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    FireBullets();
        //}
    }

    public override void FireBullets()
    {
        var bullets = bulletManager.GetBullet(bulletSpawnPoint.position, BulletType.PLAYER);
    }
}
