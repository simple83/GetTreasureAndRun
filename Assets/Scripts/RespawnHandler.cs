using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnHandler : MonoBehaviour
{
    public List<GameObject> ObstaclePool = new List<GameObject>();
    public GameObject[] Obstacles;
    public int obsCnt = 1;
    public float spawnTime = 1f;

    void Awake()
    {
        for(int i=0; i < Obstacles.Length; i++)
            for(int j = 0; j < obsCnt; j++)
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
        while (true)
        {
            ObstaclePool[NotActiveObs()].SetActive(true);       // 생성할 장애물 세트를 활성화
            yield return new WaitForSeconds(spawnTime);         // 설정한 생성 시간마다 반복
        }
    }
    int NotActiveObs()
    {
        List<int> notActive = new List<int>();
        int x = 0;

        for(int i = 0; i < ObstaclePool.Count; i++)
            if (!ObstaclePool[i].activeSelf)                    // 생성되지 않은 장애물 세트의 인덱스를 저장
                notActive.Add(i);

        if (ObstaclePool.Count > 0) x = notActive[Random.Range(0, notActive.Count)];        // 생성되지 않은 장애물 세트 중 하나의 인덱스를 반환

        return x;
    }
}
