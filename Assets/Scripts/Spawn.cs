using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public List<GameObject> objectsToSpawn;
    float spawnRate;
    public bool canSpawn = false;
    public float maxTimeBetweenSpawns = 5f;
    public float minTimeBetweenSpawns = 1f;
    public int maxRoadSynchroneSpawn = 3;
    public Transform parent;

	private int[] indexes = new int[10] {1, 1, 1, 1, 1, 2, 2, 2, 3, 3};
    private float timeCounter;

    void Awake()
    {
        timeCounter = minTimeBetweenSpawns;
    }

    void Update()
    {
        if (canSpawn)
        {
            if (timeCounter <= 0)
            {
                SpawnRandom();
                timeCounter = RandomTime();
            }
            else
            {
                timeCounter -= Time.deltaTime;
            }
        }
    }

    float RandomTime()
    {
        return Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
    }

    void SpawnRandom()
    {
        if (spawnPoints.Count > 0 && objectsToSpawn.Count > 0)
        {
            int synchroSpawn = indexes[Random.Range(0, indexes.Length)];
            List<int> randomPositionIndexes = new List<int>(synchroSpawn);
            List<int> randomObjectIndexes = new List<int>(synchroSpawn);

            for (int i = 0; i < synchroSpawn; i++)
            {
                var pos = Random.Range(0, spawnPoints.Count);
				randomPositionIndexes.Add(pos);
				var obj = Random.Range(0, objectsToSpawn.Count);
				randomObjectIndexes.Add(obj);
            }

            for (int i = 0; i < synchroSpawn; i++)
            {
                var obj = SpawnXAt(objectsToSpawn[randomObjectIndexes[i]], spawnPoints[randomPositionIndexes[i]]);
                obj.transform.parent = parent;
				obj.GetComponent<ObstacleController>().lane = randomPositionIndexes[i]+1;
            }
        }
    }

    GameObject SpawnXAt(GameObject x, Transform t)
    {
        return Instantiate(x, t.position, t.rotation);
    }
}
