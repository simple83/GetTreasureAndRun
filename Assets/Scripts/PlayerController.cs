using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D playerRigidbody;
    public AudioClip[] jumpSoundclip;
    public AudioClip slideDownSoundclip;
    int jumpSoundindex = 0;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float velocity = playerRigidbody.velocity.y;

        if (velocity > 0) {
            animator.SetBool("isRising", true);
            animator.SetBool("isFalling", false);
        }
        else if (velocity < 0) {
            animator.SetBool("isRising", false);
            animator.SetBool("isFalling", true);
        }
        else
        {
            animator.SetInteger("jumpCnt", GameManager.jumpCnt);
            animator.SetBool("isRising", false);
            animator.SetBool("isJump", false);
        }
    }

    public void Jump()
    {
        if ((GameManager.isGrounded && GameManager.jumpCnt < 2) || (!GameManager.isGrounded && GameManager.jumpCnt<2))
        {
            GameManager.isSliding = false;
            GameManager.jumpCnt++;
            animator.SetInteger("jumpCnt", GameManager.jumpCnt);
            Debug.Log("점프 횟수 : " + GameManager.jumpCnt);
            SoundManager.instance.SFXPlay("jump", jumpSoundclip[jumpSoundindex]);
            jumpSoundindex++;
            if(jumpSoundindex >= 3 ) { jumpSoundindex = 0;}
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, GameManager.jumpForce);
            //이거 속도가 아니라 힘으로 바꾸자
        }
    }

    public void SlideDown() //슬라이드 시작
    {
        if (GameManager.isGrounded)
        {
            GameManager.isSliding = true;
            animator.SetBool("isSlide", GameManager.isSliding);
            SoundManager.instance.SFXPlay("slide Down", slideDownSoundclip);
            Debug.Log("슬라이드 중!");
        }
    }
    public void SlideUp() //슬라이드 끝
    {
        if(GameManager.isSliding == true)
        {
            GameManager.isSliding = false;
            animator.SetBool("isSlide", GameManager.isSliding);
            SoundManager.instance.StopSFX("slide Down");
            Debug.Log("슬라이드 끝!");
        }    
    }
}

