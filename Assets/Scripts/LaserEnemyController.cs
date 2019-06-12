using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemyController : MonoBehaviour
{
    // Start is called before the first frame update

    public float speedY = -0.5f;
    public float topBorder = 6f;
    public bool stopOnY = false;

    public float speedX = 3f;
    
    public float reload = 5f;
    public float laserTime = 2f;
    public bool lasering = false;
    public float lastShotTime = 0;

    public GameObject laser;
    public GameObject backFire;
    public GameObject leftFire;
    public GameObject rightFire;
    void Start()
    {
        lastShotTime = reload;

         laser = gameObject.transform.GetChild(0).gameObject;
         backFire = gameObject.transform.GetChild(1).gameObject;
         leftFire = gameObject.transform.GetChild(2).gameObject;
         rightFire = gameObject.transform.GetChild(3).gameObject;

         (laser.GetComponent<Renderer>()).enabled = lasering;
         (backFire.GetComponent<Renderer>()).enabled = !(gameObject.transform.position.y < topBorder);
         (leftFire.GetComponent<Renderer>()).enabled = false;
         (rightFire.GetComponent<Renderer>()).enabled = false;
    }

    void deleteIfNeed()
    {
        if (!(GameController.GetGame()).gameObjectOnMap(gameObject))
            Destroy(gameObject);
    }
    // Update is called once per frame
    void moveX(float dt)
    {
        Vector3 pos = gameObject.transform.position;

        gameObject.transform.Translate(new Vector2(speedX * Time.deltaTime, 0));

            GameController game = GameController.GetGame();
            if (pos.x < game.getRocketLeftBorder())
            {
                gameObject.transform.position = new Vector3(game.getRocketLeftBorder(), pos.y, 0);
                speedX *= -1;

                (leftFire.GetComponent<Renderer>()).enabled = true;
                (rightFire.GetComponent<Renderer>()).enabled = false;
            }
            if (pos.x > game.getRocketRightBorder())
            {
                gameObject.transform.position = new Vector3(game.getRocketRightBorder(), pos.y, 0);
                speedX *= -1;

                (leftFire.GetComponent<Renderer>()).enabled = false;
                (rightFire.GetComponent<Renderer>()).enabled = true;
            }
    }
    void moveY(float dt)
    {
        Vector3 pos = gameObject.transform.position;
        gameObject.transform.Translate(new Vector2(0, speedY * dt));
        if (pos.y < topBorder)
        {
            (backFire.GetComponent<Renderer>()).enabled = false;

            (leftFire.GetComponent<Renderer>()).enabled = speedX > 0;
            (rightFire.GetComponent<Renderer>()).enabled = speedX < 0;

            stopOnY = true;
        }
    }
    void laserLogic(float dt)
    {
        lastShotTime += dt;
        if (lasering && lastShotTime > laserTime)
        {
            lastShotTime = 0;
            lasering = false;

            (laser.GetComponent<Renderer>()).enabled = false;

            laser.tag = "Untagged";
        }
        if (!lasering && lastShotTime > reload)
        {
            lastShotTime = 0;
            lasering = true;

            (laser.GetComponent<Renderer>()).enabled = true;

            laser.tag = "EnemyBullet";
        }
    }
    void Update()
    {
        
        if (!stopOnY)
        {
            moveY(Time.deltaTime);
        }
        else
        {
            moveX(Time.deltaTime);
            laserLogic(Time.deltaTime);
        }
        deleteIfNeed();
    }
}
