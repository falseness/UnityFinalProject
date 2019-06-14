using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Button btn;
    void startGame()
    {
        SceneManager.LoadScene("Scenes/LVL1");
        (GameController.GetGame()).numOfLevelInProcess = 0;
    }
    void Start()
    {
        if (btn)
            btn.onClick.AddListener(startGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
