using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject[] Stages; //스테이지별 장애물 스포너 배열 0번은 비울것 1번이 1스테이지
    public float[] runningTime; //스테이지 러닝타임, 0번은 비울것 1번이 1스테이지
    public AudioClip[] BGM;

    private void Start()
    {
        StartCoroutine(GameStart());
        SoundManager.instance.SFXPlay("stage1,2", BGM[0]);
    }

    IEnumerator Stage(int stageNumber)
    {
        if (Stages[stageNumber] != null)
        {
            Debug.Log("다음 스테이지로 이동.");
            Stages[stageNumber].SetActive(true);
        }
        else
        {
            Debug.LogError("타겟 오브젝트가 설정되지 않았거나 null입니다.");
        }
        yield return new WaitForSeconds(runningTime[stageNumber]); //스테이지 진행
        stageNumber++;//다음 스테이지로
        if (stageNumber <= 5) //5스테이지까지
            yield return Stage(stageNumber);
    }
    IEnumerator GameStart()//게임 시작
    {
        yield return new WaitForSeconds(1f);
        yield return Stage(1);
    }
}

