using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidControllet : MonoBehaviour
{
    // Start is called before the first frame update
    public float angle = 0;
    public float speed = -0.5f;
    public int hp = 5;
    void Start()
    {
        angle = Random.Range(0f, 360f);
        transform.Rotate(0, 0, angle);
    }

    // Update is called once per frame
    void move(float dt)
    {
        transform.Rotate(0, 0, -angle);
        gameObject.transform.Translate(new Vector2(0, speed * dt));
        transform.Rotate(0, 0, +angle);
    }
    void deleteIfNeed()
    {
        if (!(GameController.GetGame()).gameObjectOnMap(gameObject))
            Destroy(gameObject);
    }
    public void minusHP()
    {
        --hp;
        if (hp <= 0)
            Destroy(gameObject);
    }
    void Update()
    {
        GameController game = GameController.GetGame();
        if (transform.position.y > game.getTopBorder())
        {
            transform.Rotate(0, 0, -angle);
            game.moveToMap(gameObject, Time.deltaTime);
            transform.Rotate(0, 0, +angle);
        }
        else
            move(Time.deltaTime);

        deleteIfNeed();
    }
}
