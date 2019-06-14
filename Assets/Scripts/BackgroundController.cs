using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = -0.05f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((GameController.GetGame()).levelInProcess)
            gameObject.transform.Translate(new Vector2(0, speed * Time.deltaTime));
    }
}
