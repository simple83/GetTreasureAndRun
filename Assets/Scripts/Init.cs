using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameInit();
    }

    public void GameInit()
    {
        GameManager.score = 0;
        GameManager.playerLife = 3;
        GameManager.gameSpeed = 10f;
        Time.timeScale = 1;
    }
}
