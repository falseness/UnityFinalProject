using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject rocket;
    public float speed = 10f;
    public GameObject leftFire;
    public GameObject rightFire;

    public GameObject backSmallFire;
    public GameObject backMiddleFire;
    public GameObject backBigFire;
    //public bool wasClicked = false;
    //public Animator anim;
    void Start()
    {
        //Renderer rend = rocket.GetComponent<Renderer>();
        //rend.enabled = true;
        //anim = rocket.GetComponent<Animator>();
        leftFire = rocket.transform.GetChild(0).gameObject;
        rightFire = rocket.transform.GetChild(1).gameObject;

        backSmallFire =  rocket.transform.GetChild(2).GetChild(0).gameObject;
        backMiddleFire =  rocket.transform.GetChild(2).GetChild(1).gameObject;
        backBigFire =  rocket.transform.GetChild(2).GetChild(2).gameObject;

        Input.simulateMouseWithTouches = true;
    }

    // Update is called once per frame
    void changeFire(Vector3 mousePos)
    {
        (leftFire.GetComponent<Renderer>()).enabled = mousePos.x > rocket.transform.position.x;
        (rightFire.GetComponent<Renderer>()).enabled = mousePos.x < rocket.transform.position.x;

        (backSmallFire.GetComponent<Renderer>()).enabled = mousePos.y < rocket.transform.position.y;
        (backMiddleFire.GetComponent<Renderer>()).enabled = mousePos.y == rocket.transform.position.y;
        (backBigFire.GetComponent<Renderer>()).enabled = mousePos.y > rocket.transform.position.y;
    }
    void defaultFire()
    {
        (leftFire.GetComponent<Renderer>()).enabled = false;
        (rightFire.GetComponent<Renderer>()).enabled = false;

        (backSmallFire.GetComponent<Renderer>()).enabled = false;
        (backMiddleFire.GetComponent<Renderer>()).enabled = true;
        (backBigFire.GetComponent<Renderer>()).enabled = false;
    }
    void moveRocketToMap()
    {
        Vector3 pos = rocket.transform.position;
        GameController game = GameController.GetGame();

        if (pos.x < game.getRocketLeftBorder())
            rocket.transform.position = new Vector3(game.getRocketLeftBorder(), pos.y, 0);
        if (pos.x > game.getRocketRightBorder())
            rocket.transform.position = new Vector3(game.getRocketRightBorder(), pos.y, 0);
        if (pos.y < game.getRocketBottomBorder())
            rocket.transform.position = new Vector3(pos.x, game.getRocketBottomBorder(), 0);
        if (pos.y > game.getRocketTopBorder())
            rocket.transform.position = new Vector3(pos.x, game.getRocketTopBorder(), 0);

            
    }
    void Update()
    {
        defaultFire();
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            changeFire(mousePos);
            rocket.transform.position = Vector2.MoveTowards(rocket.transform.position, new Vector2(mousePos.x, mousePos.y), speed * Time.deltaTime);

            moveRocketToMap();
        }
    }
    /*void changeAnimations(Vector3 mousePos)
    {
        //wasClicked = Input.GetMouseButton(0);
        //anim.SetBool("GoRight", !wasClicked && (mousePos.x > rocket.transform.position.x));
    }*/
    /*void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        changeFire(mousePos);
        rocket.transform.position = Vector2.MoveTowards(rocket.transform.position, new Vector2(mousePos.x, mousePos.y), speed * Time.deltaTime);
    }*/
}
