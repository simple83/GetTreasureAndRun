using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject[] Stages; //���������� ��ֹ� ������ �迭 0���� ���� 1���� 1��������
    public float[] runningTime; //�������� ����Ÿ��, 0���� ���� 1���� 1��������

    private void Start()
    {
        StartCoroutine(GameStart());
    }

    IEnumerator Stage(int stageNumber)
    {
        if (Stages[stageNumber] != null)
        {
            Debug.Log("���� ���������� �̵�.");
            Stages[stageNumber].SetActive(true);
        }
        else
        {
            Debug.LogError("Ÿ�� ������Ʈ�� �������� �ʾҰų� null�Դϴ�.");
        }
        yield return new WaitForSeconds(runningTime[stageNumber]); //�������� ����
        stageNumber++;//���� ����������
        if (stageNumber <= 5) //5������������
            yield return Stage(stageNumber);
    }
    IEnumerator GameStart()//���� ����
    {
        yield return new WaitForSeconds(1f);
        yield return Stage(1);
    }
}

