using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = -6f;
    
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
        gameObject.transform.Translate(new Vector2(0, speed * Time.deltaTime));

        GameController game = (GameController.GetGame());

        deleteIfNeed();
    }
}
