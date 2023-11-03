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
                ObstaclePool.Add(CreateObject(Obstacles[i], transform));        // ������ ��ֹ� ��Ʈ�� ������Ʈ Ǯ�� �߰�
    }
    void Start()
    {
        StartCoroutine(CreateObs());
    }

    GameObject CreateObject(GameObject obj, Transform parent)
    {
        GameObject temp = Instantiate(obj);

        temp.transform.SetParent(parent);
        temp.SetActive(false);                                  // ��ֹ� ��Ʈ�� ��Ȱ��ȭ

        return temp;
    }
    IEnumerator CreateObs()
    {
        while (true)
        {
            ObstaclePool[NotActiveObs()].SetActive(true);       // ������ ��ֹ� ��Ʈ�� Ȱ��ȭ
            yield return new WaitForSeconds(spawnTime);         // ������ ���� �ð����� �ݺ�
        }
    }
    int NotActiveObs()
    {
        List<int> notActive = new List<int>();
        int x = 0;

        for(int i = 0; i < ObstaclePool.Count; i++)
            if (!ObstaclePool[i].activeSelf)                    // �������� ���� ��ֹ� ��Ʈ�� �ε����� ����
                notActive.Add(i);

        if (ObstaclePool.Count > 0) x = notActive[Random.Range(0, notActive.Count)];        // �������� ���� ��ֹ� ��Ʈ �� �ϳ��� �ε����� ��ȯ

        return x;
    }
}
