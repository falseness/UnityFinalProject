using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Bullet;
    public float reload = 0.5f;
    public float lastShotTime = 0;

    public float bulletOffsetY = 0.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lastShotTime += Time.deltaTime;
        if (lastShotTime >= reload)
        {
            Vector3 newBulletPos = gameObject.transform.position;
            newBulletPos.y += bulletOffsetY;
            Instantiate(Bullet, newBulletPos, new Quaternion(0, 0, 0, 0));
            lastShotTime = 0;
        }
    }
     void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "EnemyBullet")
        {
            (GameController.GetGame()).loose();
        }
    }
}
