using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    static GameController instance;

    public float cameraHeight;
    public float cameraWidth;

    public float topBorderOfMap;
    public float bottomBorderOfMap;
    public float leftBorderOfMap;
    public float rightBorderOfMap;
    float getTopBorder()
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
        return cameraHeight / 2 - 0.4f;
    }
    public float getRocketBottomBorder()
    {
        return -cameraHeight / 2 + 0.4f;
    }
    //public float getRocket
    public bool gameObjectOnMap(GameObject obj)
    {
        Vector3 tr = obj.transform.position;
        return (leftBorderOfMap < tr.x && tr.x < rightBorderOfMap && bottomBorderOfMap < tr.y && tr.y < topBorderOfMap);
    }
    public void loose()
    {
        Debug.Log("LOOSE");
    }
    void Start()
    {
        if (instance)
            Destroy(gameObject);
        else
        {
            instance = this;

            cameraHeight = 2f * Camera.main.orthographicSize;
            cameraWidth = cameraHeight * Camera.main.aspect;

            topBorderOfMap = cameraHeight / 2 + 2f;
            bottomBorderOfMap = -cameraHeight / 2;

            leftBorderOfMap = -cameraWidth / 2 - 1f;
            rightBorderOfMap = cameraWidth / 2 + 1f;
        }
    }
    public static GameController GetGame() 
    {
        return instance;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
}
