using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 바닥에 닿았을 때
        if (collision.gameObject.CompareTag("Ground"))
        {
            GameManager.isGrounded = true;
            GameManager.jumpCnt = 0;
            Debug.Log("땅에 착지");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // 바닥에서 벗어났을 때
        if (collision.gameObject.CompareTag("Ground"))
        {
            GameManager.isGrounded = false;
            Debug.Log("점프");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("JumpObstacle"))
        {
            GameManager.playerLife -= 1;
            Debug.Log("점프 장애물과 충돌ㅠㅠ");
            Debug.Log(GameManager.playerLife);
        }
        else if (collision.gameObject.CompareTag("SlideObstacle"))
        {
            if(GameManager.isSliding == false)
            {
                GameManager.playerLife -= 1;
                Debug.Log("슬라이드 장애물과 충돌ㅠㅠ");
                Debug.Log(GameManager.playerLife);
            }
        }
        else if(collision.gameObject.CompareTag("BronzeCoin"))
        {
            GameManager.score += 10;
            Debug.Log("동화 획득");
            Debug.Log(GameManager.score);
            collision.gameObject.SetActive(false);
            //Destroy(collision.gameObject);
            
        }
        else if (collision.gameObject.CompareTag("GoldCoin"))
        {
            GameManager.score += 100;
            Debug.Log("금화 획득");
            Debug.Log(GameManager.score);
            collision.gameObject.SetActive(false);
            //Destroy(collision.gameObject);
        }
    }
    
}
