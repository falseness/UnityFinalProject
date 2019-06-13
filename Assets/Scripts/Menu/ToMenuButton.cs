using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToMenuButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Button btn;
    void toMenu()
    {
        SceneManager.LoadScene("Scenes/Menu");
        Debug.Log("ok");
        gameObject.SetActive(false);
        //(gameObject.GetComponent<Button>()).interactable = false;
    }
    void Start()
    {
        gameObject.SetActive(false);
        //(gameObject.GetComponent<Button>()).interactable = false;
        (GameController.GetGame()).levelInProcess = true;
        if (btn)
            btn.onClick.AddListener(toMenu);
    }

    // Update is called once per frame

    // Update is called once per frame
    void Update()
    {
    }
}
