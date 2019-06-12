using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PentaEnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = -3f;

    public GameObject Bullet;

    public float reloadBetweenSeies = 2f;
    public float intervalBetweenShotsInSerie = 0.5f;
    public int maxShotsInSerieCount = 5;

    public int shotsInSerieCount = 0;
    public float lastShotTime = 0;

    public float bulletOffsetY = -0.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void deleteIfNeed()
    {
        if (!(GameController.GetGame()).gameObjectOnMap(gameObject))
            Destroy(gameObject);
    }
    bool serieNotStarted()
    {
        return shotsInSerieCount == 0;
    }
    void createBullet()
    {
        Vector3 newBulletPos = gameObject.transform.position;
        newBulletPos.y += bulletOffsetY;
        Instantiate(Bullet, newBulletPos, new Quaternion(0, 0, 0, 0));

        shotsInSerieCount = ++shotsInSerieCount % maxShotsInSerieCount;
        lastShotTime = 0;
    }
    void move(float dt)
    {
        gameObject.transform.Translate(new Vector2(speed * dt, 0));
    }
    void shotsLogic(float dt)
    {
        lastShotTime += dt;
        if (serieNotStarted())
        {
            if (lastShotTime > reloadBetweenSeies)
            {
                createBullet();
            }
        }
        else
        {
            if (lastShotTime > intervalBetweenShotsInSerie)
            {
                createBullet();
            }
        }
    }
    void Update()
    {
        move(Time.deltaTime);

        shotsLogic(Time.deltaTime);

        deleteIfNeed();
    }
}
