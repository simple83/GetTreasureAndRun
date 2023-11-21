using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_1_RespawnHandler : MonoBehaviour
{
    public List<GameObject> ObstaclePool = new List<GameObject>();
    public GameObject[] Obstacles;
    public int obsCnt = 1;
    public float spawnTime = 1f;
    void Awake()
    {
        for (int i = 0; i < Obstacles.Length; i++)
            for (int j = 0; j < obsCnt; j++)
                ObstaclePool.Add(CreateObject(Obstacles[i], transform));        // 생성한 장애물 세트를 오브젝트 풀에 추가
    }
    void Start()
    {
        StartCoroutine(CreateObs());
    }

    GameObject CreateObject(GameObject obj, Transform parent)
    {
        GameObject temp = Instantiate(obj);

        temp.transform.SetParent(parent);
        temp.SetActive(false);                                  // 장애물 세트를 비활성화

        return temp;
    }
    IEnumerator CreateObs()
    {
        for (int i = 0; i < 5; i++)
        {
            ObstaclePool[i].SetActive(true);       // 순서대로 장애물 세트를 활성화
            yield return new WaitForSeconds(spawnTime);         // 설정한 생성 시간마다 반복
        }
    }
}

