using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHandler : MonoBehaviour
{
    SpriteRenderer temp;
    public SpriteRenderer[] groundTile;
    void Start()
    {
        temp = groundTile[0];           // ���� ���ʿ� �ִ� ����
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
                        temp = groundTile[j];                                                           // ���� ���ʿ� �ִ� ������ ��ȣ ����
                groundTile[i].transform.position = new Vector2(temp.transform.position.x + 1, -4f);     // ������ ��ȣ �������� �迭 ���� ����
            }
        }

        for (int i = 0; i < groundTile.Length; i++)
            groundTile[i].transform.Translate(GameManager.gameSpeed * Time.deltaTime * Vector2.left);   // ������ ��� ������ ������ �ӵ���ŭ �������� �̵�
    }
}
