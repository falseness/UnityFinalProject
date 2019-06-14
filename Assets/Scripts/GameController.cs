using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    static GameController instance;

    public int numOfLastLevelOpened = 1;
    public bool levelInProcess = false;
    public int numOfLevelInProcess = 0;

    public float cameraHeight;
    public float cameraWidth;

    public float topBorderOfMap;
    public float bottomBorderOfMap;
    public float leftBorderOfMap;
    public float rightBorderOfMap;

    public float standartSpeed = -1f;
    public bool canStartLevel(int level)
    {
        return numOfLastLevelOpened >= level;
    }
    public float getTopBorder()
    {
        return topBorderOfMap;
    }
    public float getBottomBorder()
    {
        return bottomBorderOfMap;
    }
    public float getLeftBorder()
    {
        return leftBorderOfMap;
    }
    public float getRightBorder()
    {
        return rightBorderOfMap;
    }
    public float getRocketLeftBorder()
    {
        return -cameraWidth / 2 + 0.3f;
    }
    public float getRocketRightBorder()
    {
        return cameraWidth / 2 - 0.33f;
    }
    public float getRocketTopBorder()
    {
        return cameraHeight / 2 - 1f;
    }
    public float getRocketBottomBorder()
    {
        return -cameraHeight / 2 + 0.4f;
    }
    /*
    public Button btnNextLvl;
    public Button btnNextLv2;
    void Start()
    {
        if (btnNextLvl) btnNextLvl.onClick.AddListener(NextLevel);
        if (btnNextLv2) btnNextLv2.onClick.AddListener(NextLevel2);
    }

    void NextLevel()
    {
        SceneManager.LoadScene("Scenes/Level1");
    }
    void NextLevel2()
    {
        SceneManager.LoadScene("Scenes/Level2");
    }
     */
    //public float getRocket
    public bool gameObjectOnMap(GameObject obj)
    {
        Vector3 tr = obj.transform.position;
        bool res = leftBorderOfMap <= tr.x && tr.x <= rightBorderOfMap && bottomBorderOfMap <= tr.y;
        if (obj.tag == "Enemy" || obj.tag == "Strong")
            return res;
        if (obj.tag == "Bullet")
            return (res && tr.y <= cameraHeight / 2 + 0.5f);

        return (res && tr.y <= topBorderOfMap);
    }
    public void moveToMap(GameObject obj, float dt)
    {
        obj.transform.Translate(new Vector2(0, standartSpeed * dt));
    }
    public void loose()
    {
        //return ;
        //потом убери!
        if (levelInProcess)
        {
            levelInProcess = false;
            SceneManager.LoadScene("Scenes/Menu");
        }
    }
    void Start()
    {
        if (instance)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            cameraHeight = 2f * Camera.main.orthographicSize;
            cameraWidth = cameraHeight * Camera.main.aspect;

            topBorderOfMap = cameraHeight / 2 + 2f;
            bottomBorderOfMap = -cameraHeight / 2 - 2f;

            leftBorderOfMap = -cameraWidth / 2 - 1f;
            rightBorderOfMap = cameraWidth / 2 + 1f;

        }
    }
    public static GameController GetGame() 
    {
        return instance;
    }
    void Win()
    {
        GameObject rootObject = GameObject.Find("Canvas");
        GameObject toMenuButton = rootObject.transform.Find("ToMenuButton").gameObject;
        toMenuButton.SetActive(true);

        if (numOfLastLevelOpened == numOfLevelInProcess)
            ++numOfLastLevelOpened;
        levelInProcess = false;
    }
    // Update is called once per frame

    void Update()
    {
        if (levelInProcess)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 &&
                GameObject.FindGameObjectsWithTag("Strong").Length == 0)
                Win();
        }
    }
    
}
