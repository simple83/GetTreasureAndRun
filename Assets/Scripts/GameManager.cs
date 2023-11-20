using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }

    public static bool isGrounded = true;
    public static bool isSliding = false;
    public static float gameSpeed = 5f;
    public static float jumpForce = 12f;
    public static int jumpCnt = 0;
    public static int playerLife = 3;
    public static int score = 0;

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
    private void Update()
    {
        if (GameManager.playerLife <= 0)
        {
            Time.timeScale = 0;
            //GameManager.gameSpeed = 0f;
        }
    }

}