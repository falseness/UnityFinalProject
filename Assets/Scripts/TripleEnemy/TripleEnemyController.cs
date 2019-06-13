using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleEnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Bullet;

    public float speed = -2f;
    public float reload = 2f;
    public float lastShotTime = 0;
    public float bulletOffsetY = -0.1f;
    public float bulletFirstOffsetX = -0.1f;
    public float bulletSecondOffsetX = 0f;
    public float bulletThirdOffsetX = 0.1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void deleteIfNeed()
    {
        if (!(GameController.GetGame()).gameObjectOnMap(gameObject))
            Destroy(gameObject);
    }
    void createBullet(float offsetX, float offsetY)
    {
        Vector3 newBulletPos = gameObject.transform.position;
        newBulletPos.x += offsetX;
        newBulletPos.y += offsetY;

        Instantiate(Bullet, newBulletPos, new Quaternion(0, 0, 0, 0));
    }
    void shotsLogic(float dt)
    {
        lastShotTime += dt;
        if (lastShotTime > reload)
        {
            createBullet(bulletFirstOffsetX, bulletOffsetY);
            createBullet(bulletSecondOffsetX, bulletOffsetY);
            createBullet(bulletThirdOffsetX, bulletOffsetY);

            lastShotTime = 0;
        }
    }
    void move(float dt)
    {
        gameObject.transform.Translate(new Vector2(0, speed * dt));
    }
    void Update()
    {
        GameController game = GameController.GetGame();
        if (transform.position.y > game.getTopBorder())
            game.moveToMap(gameObject, Time.deltaTime);
        else
        {
            move(Time.deltaTime);

            shotsLogic(Time.deltaTime);
        }

        deleteIfNeed();
    }
}
