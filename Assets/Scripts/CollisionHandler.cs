using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
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
            GameManager.playerLife -= 1;
        }
        // 슬라이드 장애물 충돌
        else if (collision.gameObject.CompareTag("SlideObstacle"))
        {
            if(GameManager.isSliding == false)
            {
                GameManager.playerLife -= 1;
            }
        }
        else if(collision.gameObject.CompareTag("BronzeCoin"))
        {
            GameManager.score += 10;
            Debug.Log("동화 획득");
            Debug.Log(GameManager.score);
            collision.gameObject.SetActive(false);
            
        }
        else if (collision.gameObject.CompareTag("GoldCoin"))
        {
            GameManager.score += 100;
            Debug.Log("금화 획득");
            Debug.Log(GameManager.score);
            collision.gameObject.SetActive(false);
        }
    }
    
}
