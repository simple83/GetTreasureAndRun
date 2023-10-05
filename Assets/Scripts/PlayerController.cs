using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static float initialSpeed = 10f; // 초기 속도 값
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // 게임 시작 시 x축 방향의 플레이어 초기 속도를 설정
        Vector2 initialVelocity = new Vector2(initialSpeed, rb.velocity.y);
        rb.velocity = initialVelocity;
    }

    public void Jump()
    {
        if (GameManager.isGrounded)
        {
            GameManager.isSliding = false;
            Rigidbody2D playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, GameManager.jumpForce);
            //이거 속도가 아니라 힘으로 바꾸자
        }
    }

    public void SlideDown() //슬라이드 시작
    {
        if (GameManager.isGrounded)
        {
            GameManager.isSliding = true;
            Debug.Log("슬라이드 중!");
        }
    }
    public void SlideUp() //슬라이드 끝
    {
        if(GameManager.isSliding == true)
        {
            GameManager.isSliding = false;
            Debug.Log("슬라이드 끝!");
        }    
    }
}

