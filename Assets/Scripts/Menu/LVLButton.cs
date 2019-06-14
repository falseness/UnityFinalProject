using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LVLButton : MonoBehaviour
{
    // Start is called before the first frame update
    public int numOfLevel;
    public Button btn;

    void startLevel()
    {
        if ((GameController.GetGame()).canStartLevel(numOfLevel))
        {
            Debug.Log("ok");
            SceneManager.LoadScene("Scenes/LVL" + numOfLevel.ToString());
            (GameController.GetGame()).numOfLevelInProcess = numOfLevel;
        }
    }
    void Start()
    {
        if (btn)
            btn.onClick.AddListener(startLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
