using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject[] Backgrounds; //1번이 1스테이지
    public float[] runningTime; //스테이지 러닝타임, 1번이 1스테이지
    int backgroundCount;
    private Material[] materials;

    private void Start()
    {
        StartCoroutine(GameStart());
    }

    IEnumerator Stage(int stageNumber)
    {

        yield return new WaitForSeconds(runningTime[stageNumber]); //스테이지 진행
        //다음 배경 미리 active
        if (Backgrounds[stageNumber + 1] != null)
        {
            Backgrounds[stageNumber + 1].SetActive(true);
        }
        else
        {
            Debug.LogError("타겟 오브젝트가 설정되지 않았거나 null입니다.");
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

        stageNumber++;//다음 스테이지로
        if (stageNumber <= 5) //5스테이지까지
            yield return Stage(stageNumber);
    }
    IEnumerator GameStart()//게임 시작
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
