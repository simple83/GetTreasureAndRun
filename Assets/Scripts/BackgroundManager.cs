using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject[] Backgrounds; //1���� 1��������
    public float[] runningTime; //�������� ����Ÿ��, 1���� 1��������
    int backgroundCount;
    private Material[] materials;

    private void Start()
    {
        StartCoroutine(GameStart());
    }

    IEnumerator Stage(int stageNumber)
    {

        yield return new WaitForSeconds(runningTime[stageNumber]); //�������� ����
        //���� ��� �̸� active
        if (Backgrounds[stageNumber + 1] != null)
        {
            Backgrounds[stageNumber + 1].SetActive(true);
        }
        else
        {
            Debug.LogError("Ÿ�� ������Ʈ�� �������� �ʾҰų� null�Դϴ�.");
        }

        backgroundCount = Backgrounds[stageNumber].transform.childCount;
        GameObject[] backgrounds = new GameObject[backgroundCount];
        materials = new Material[backgroundCount];

        for (int i = 0; i < backgroundCount; ++i)
        {
            backgrounds[i] = Backgrounds[stageNumber].transform.GetChild(i).gameObject;
            materials[i] = backgrounds[i].GetComponent<Renderer>().material;
        }

        StartCoroutine(Fadeout(stageNumber));

        stageNumber++;//���� ����������
        if (stageNumber <= 5) //5������������
            yield return Stage(stageNumber);
    }
    IEnumerator GameStart()//���� ����
    {
        Backgrounds[1].SetActive(true);
        yield return Stage(1);
    }

    IEnumerator Fadeout(int stageNumber)
    {
        int count = 0;
        float alpha = 1f;
        while (count < 10)
        {
            for(int i = 0; i < backgroundCount; i++)
            {
                materials[i].color = new Color(1, 1, 1, alpha);
            }
            alpha -= 0.1f;
            yield return new WaitForSeconds(0.1f);
            count++;
        }
        Backgrounds[stageNumber].SetActive(false);
    }
}
