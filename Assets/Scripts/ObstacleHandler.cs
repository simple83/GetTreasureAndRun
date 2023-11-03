using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHandler : MonoBehaviour
{
    public Vector2 StartPos = new Vector2(25f,0f);

    private void OnEnable()
    {
        for(int i = 0; i < transform.childCount; i++)
            if (!(transform.GetChild(i).gameObject.activeSelf))
                transform.GetChild(i).gameObject.SetActive(true);   // ��Ȱ��ȭ�� ���� �ٽ� Ȱ��ȭ

        transform.position = StartPos;
    }
    void Update()
    {
        transform.Translate(GameManager.gameSpeed * Time.deltaTime * Vector2.left);

        if (transform.position.x < -16) gameObject.SetActive(false);
    }
}
