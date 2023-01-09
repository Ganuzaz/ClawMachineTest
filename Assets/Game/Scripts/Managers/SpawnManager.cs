using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    public GameObject dropzoneEndpoint;

    public List<GameObject> smallSpawner;
    public List<GameObject> bigSpawners;

    public List<GameObject> splitterBoundary;

    private PrizeDictionary db;

    private int prizeCount;

    private Dictionary<PrizeType, Queue<GameObject>> prizePool = new Dictionary<PrizeType, Queue<GameObject>>();

    public GameObject claw;
    public GameObject topCollider;

    public void DisableSplitterBoundary()
    {
        foreach(var splitter in splitterBoundary)
        {
            splitter.gameObject.SetActive(false);
        }
    }

    public void EnableSplitterBoundary()
    {
        foreach(var splitter in splitterBoundary)
        {
            splitter.gameObject.SetActive(true);
        }
    }

    void SpawnRandomFruit(Vector3 position)
    {
        var fruitType = (PrizeType)Random.Range(0, prizeCount);

        if (prizePool[fruitType].Count > 0)
        {
            var obj = prizePool[fruitType].Dequeue();
            obj.transform.position = position;
            obj.SetActive(true);
        }
        else
        {
            Instantiate(db[fruitType], position, Quaternion.identity);
        }

    }

    void OnPrizeGet(Hashtable table)
    {
        var currentPrize = (GameObject)table["prizeObject"];
        var prizeType = (PrizeType)table["prizeType"];

        currentPrize.gameObject.SetActive(false);
        prizePool[prizeType].Enqueue(currentPrize);

        SpawnRandomFruit(bigSpawners[0].transform.position);
    }


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        db = Resources.Load<DatabaseScriptableObject>("Database").prizeDictionary;
        prizeCount = Enum.GetNames(typeof(PrizeType)).Length;

        EventManager.instance.AddListener(EventEnums.PRIZE_ON_DROPPED, OnPrizeGet);

        for(int i = 0; i < prizeCount; i++)
        {
            prizePool.Add((PrizeType)i, new Queue<GameObject>());
        }



        StartCoroutine(InitialSpawnFruits());

    }

    IEnumerator InitialSpawnFruits()
    {
        for (int i = 0; i < smallSpawner.Count; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                SpawnRandomFruit(smallSpawner[i].transform.position);
            }
        }

        for (int i = 0; i < bigSpawners.Count; i++)
        {
            for (int j = 0; j < 30; j++)
            {
                SpawnRandomFruit(bigSpawners[i].transform.position);
                if (j % 8 == 0)
                    yield return null;
            }
        }
        StartCoroutine(enableClaw());
    }

    IEnumerator enableClaw()
    {
        yield return new WaitForSeconds(1f);
        topCollider.GetComponent<Collider>().enabled = false;
        claw.SetActive(true);
        DisableSplitterBoundary();

    }
    
}
