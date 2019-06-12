using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustEnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.2f;
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
        deleteIfNeed();
    }
}
