using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustEnemyBulletController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void deleteIfNeed()
    {
       if (!(GameController.GetGame()).gameObjectOnMap(gameObject))
            Destroy(gameObject);
    }
    void Update()
    {
        gameObject.transform.Translate(new Vector2(speed * Time.deltaTime, 0));

        deleteIfNeed();
    }
}
