using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    Animator animator;
    private SpriteRenderer player_spriteRenderer;
    private float player_invincibility_delay = 2f;
    public AudioClip collideSoundclip;
    public AudioClip coinSoundclip;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        player_spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 바닥에 닿았을 때
        if (collision.gameObject.CompareTag("Ground"))
        {
            GameManager.isGrounded = true;
            GameManager.jumpCnt = 0;                                // 점프 횟수 초기화
            animator.SetBool("isJump", !GameManager.isGrounded);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // 바닥에서 벗어났을 때
        if (collision.gameObject.CompareTag("Ground"))
        {
            GameManager.isGrounded = false;
            animator.SetBool("isJump", !GameManager.isGrounded);    // 점프 애니메이션 트리거 작동
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 점프 장애물 충돌
        if (collision.gameObject.CompareTag("JumpObstacle"))
        {
            SoundManager.instance.SFXPlay("collide", collideSoundclip);
            GameManager.playerLife -= 1;
            if(GameManager.playerLife <= 0) { SceneManager.LoadScene(0); }
            PlayerInvincibility();
            PlayerFlincker();
        }
        // 슬라이드 장애물 충돌
        else if (collision.gameObject.CompareTag("SlideObstacle"))
        {
            if(GameManager.isSliding == false)
            {
                SoundManager.instance.SFXPlay("collide", collideSoundclip);
                GameManager.playerLife -= 1;
                if (GameManager.playerLife <= 0) { SceneManager.LoadScene(0); }
                PlayerInvincibility();
                PlayerFlincker();
            }
        }
        else if(collision.gameObject.CompareTag("BronzeCoin"))
        {
            GameManager.score += 10;
            SoundManager.instance.SFXPlay("coin", coinSoundclip);
            Debug.Log("동화 획득");
            Debug.Log(GameManager.score);
            collision.gameObject.SetActive(false);
            
        }
        else if (collision.gameObject.CompareTag("GoldCoin"))
        {
            GameManager.score += 100;
            SoundManager.instance.SFXPlay("coin", coinSoundclip);
            Debug.Log("금화 획득");
            Debug.Log(GameManager.score);
            collision.gameObject.SetActive(false);
        }
    }

    //충돌시 캐릭터 무적
    private void PlayerInvincibility()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Obstacle"), LayerMask.NameToLayer("Player"), true);
        Debug.Log("충돌");
        StartCoroutine("PlayerInvincibilityTime");
    }

    //충돌시 캐릭터 무적 시간
    IEnumerator PlayerInvincibilityTime()
    {
        yield return new WaitForSeconds(player_invincibility_delay);
        Debug.Log("무적2초");
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Obstacle"), LayerMask.NameToLayer("Player"), false);
    }

    //충돌시 깜빡임효과
    private void PlayerFlincker()
    {

        StartCoroutine("Flincker", player_spriteRenderer.color);

    }
    IEnumerator Flincker(Color c)
    {
        for (float sprite_alpha = 1; sprite_alpha == 0; sprite_alpha -= 0.1f)
        {
            c = new Color(1, 1, 1, sprite_alpha);
            StartCoroutine("DelayFlincker");
            Debug.Log("실험");
        }

        for (float sprite_alpha = 0; sprite_alpha > 1; sprite_alpha += 0.1f)
        {
            c = new Color(1, 1, 1, sprite_alpha);
            StartCoroutine("DelayFlincker");
        }
        yield return null;
    }

    IEnumerator DelayFlincker()
    {
        yield return new WaitForSeconds(0.1f);
    }


}
