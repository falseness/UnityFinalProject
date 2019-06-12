using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustEnemyGunController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Rocket;
    public GameObject Bullet;

    public float reload = 0.5f;
    public float lastShotTime = 0;

    void Start()
    {
        Rocket = GameObject.Find("Rocket");
    }

    // Update is called once per frame
    void LookAtRocket(float dt)
    {
        Vector3 targetDir = Rocket.transform.position - transform.position;

        // The step size is equal to speed times frame time.
        float step = 10f * dt;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        //Debug.DrawRay(transform.position, newDir, Color.red);
        Vector3 dir = Rocket.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    void deleteIfNeed()
    {
        if (!(GameController.GetGame()).gameObjectOnMap(gameObject))
            Destroy(gameObject);
    }
    void Update()
    {
        // gameObject.transform.LookAt(Rocket.transform);

        /*
        Vector3 delta = Rocket.transform.position - transform.position;
        print(delta);
        Quaternion rotation = Quaternion.LookRotation(delta, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 1 * Time.deltaTime);
        */

        // transform.LookAt(Rocket.transform, Vector3.up);


       LookAtRocket(Time.deltaTime);

        lastShotTime += Time.deltaTime;
        if (lastShotTime >= reload)
        {
            Instantiate(Bullet, gameObject.transform.position, gameObject.transform.rotation);
            lastShotTime = 0;
        }
        deleteIfNeed();
    }
}
