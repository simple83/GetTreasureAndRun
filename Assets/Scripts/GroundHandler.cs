using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHandler : MonoBehaviour
{
    SpriteRenderer temp;
    public SpriteRenderer[] groundTile;
    void Start()
    {
        temp = groundTile[0];           // 가장 왼쪽에 있는 발판
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < groundTile.Length; i++)
        {
            if (groundTile[i].transform.position.x <= -14)
            {
                for (int j = 0; j < groundTile.Length; j++)
                    if (temp.transform.position.x < groundTile[j].transform.position.x)
                        temp = groundTile[j];                                                           // 제일 왼쪽에 있는 발판의 번호 갱신
                groundTile[i].transform.position = new Vector2(temp.transform.position.x + 1, -4f);     // 갱신한 번호 기준으로 배열 순서 갱신
            }
        }

        for (int i = 0; i < groundTile.Length; i++)
            groundTile[i].transform.Translate(GameManager.gameSpeed * Time.deltaTime * Vector2.left);   // 발판은 계속 설정된 게임의 속도만큼 왼쪽으로 이동
    }
}
