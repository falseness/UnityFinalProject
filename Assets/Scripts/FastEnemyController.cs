using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Rocket;
    public float speed = -6f; 
    
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

        transform.Rotate(0, 0, 90);
    }
    void deleteIfNeed()
    {
       if (!(GameController.GetGame()).gameObjectOnMap(gameObject))
            Destroy(gameObject);
    }
    void Update()
    {
        GameController game = GameController.GetGame();
        if (transform.position.y > game.getTopBorder())
            game.moveToMap(gameObject, Time.deltaTime);
        else
        {
            LookAtRocket(Time.deltaTime);
            gameObject.transform.Translate(new Vector2(0, speed * Time.deltaTime));
        }
        deleteIfNeed();
    }
}
