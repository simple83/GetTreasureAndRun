using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }

    public static bool isGrounded;
    public static float jumpForce = 10f;
    public static int playerLife = 3;
    public static int score = 0;
    public static bool isSliding = false;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 다른 씬으로 넘어갈 때 오브젝트가 파괴되지 않도록 설정
        }
        else
        {
            Destroy(gameObject); // 이미 인스턴스가 존재하면 새로 생성된 오브젝트를 파괴
        }
    }

    public void SetSlide(bool isSlide)
    {
        isSliding = isSlide;

        //여기다가 애니메이션 다 넣기.
    }


}
