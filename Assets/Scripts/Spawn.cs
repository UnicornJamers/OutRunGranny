using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public List<GameObject> objectsToSpawn;
    public List<Sprite> carSprites;
    public List<Sprite> truckSprites;
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

            var typeRand = Random.value;

            for (int i = 0; i < synchroSpawn; i++)
            {
                var pos = Random.Range(0, spawnPoints.Count);
				randomPositionIndexes.Add(pos);
				var idx = typeRand > 0.5f ? 0 : 1;
				randomObjectIndexes.Add(idx);
            }

            for (int i = 0; i < synchroSpawn; i++)
            {
                var obj = SpawnXAt(objectsToSpawn[randomObjectIndexes[i]], spawnPoints[randomPositionIndexes[i]]);
                obj.transform.parent = parent;
                var obstaclCtrl = obj.GetComponent<ObstacleController>();
				obstaclCtrl.lane = randomPositionIndexes[i];
                obstaclCtrl.type = typeRand > 0.5f ? VehicleType.Car : VehicleType.Truck;
                var objRenderer = obj.GetComponent<SpriteRenderer>();
                objRenderer.flipX = true;
                objRenderer.sprite = typeRand > 0.5f ? carSprites[Random.Range(0, carSprites.Count)] : truckSprites[Random.Range(0, truckSprites.Count)];
            }
        }
    }

    GameObject SpawnXAt(GameObject x, Transform t)
    {
        return Instantiate(x, t.position, t.rotation);
    }
}
