using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    public string spawnTag = "Spawn";
	public GameObject[] obstacles;
	public Transform parent;

    private List<GameObject> spawnPoints;
	private int lastYPos;
	private float lastTimePos;
	private float timer;

    void Awake()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag(spawnTag).ToList();
		lastTimePos = 0;
		timer = 0f;
    }

    void Update()
    {

		if(timer > 0.1f) {
			timer = 0f;
			var obstacle = obstacles[Random.Range(0, obstacles.Length)];
			var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)].transform;

			Instantiate(obstacle, spawnPoint.position, spawnPoint.rotation, parent);
		}
		
		timer += Time.deltaTime;
    }
}
