using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctoEnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = -0.5f;
    public GameObject Bullet;

    public float reload = 1f;
    public float lastShotTime = 0;
    void Start()
    {
        
    }
    void deleteIfNeed()
    {
        if (!(GameController.GetGame()).gameObjectOnMap(gameObject))
            Destroy(gameObject);
    }
    // Update is called once per frame
    void createBullet(float angle)
    {
        GameObject newBullet = Instantiate(Bullet, gameObject.transform.position, new Quaternion(0, 0, 0, 0));
        newBullet.transform.Rotate(0, 0, angle);
    }
    void Update()
    {
        GameController game = GameController.GetGame();
        if (transform.position.y > game.getTopBorder())
            game.moveToMap(gameObject, Time.deltaTime);
        else
        {
            lastShotTime += Time.deltaTime;

            gameObject.transform.Translate(new Vector2(0, speed * Time.deltaTime));
            if (lastShotTime > reload)
            {
                createBullet(0);

                createBullet(90);
                createBullet(-90);

                createBullet(45);
                createBullet(-45);

                createBullet(135);
                createBullet(-135);
                lastShotTime = 0;

            }
        }
        deleteIfNeed();
    }
}
