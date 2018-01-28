using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour {

	public Transform parent;
	public List<AudioData> TruckKlaxon;
	public List<AudioData> CarKlaxon;
	public List<GameObject> obstaclesAnimLane1;
	public List<GameObject> obstaclesAnimLane2;
	public List<GameObject> obstaclesAnimLane3;
	public List<GameObject> obstaclesAnimLane4;
	public List<GameObject> obstaclesAnimLane5;

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Obstacle") {
			var lane = other.GetComponent<ObstacleController>().lane;
			List<GameObject> laneObstacles = new List<GameObject>();
			switch (lane)
			{
				case 1: 
					laneObstacles = obstaclesAnimLane1;
				break;
				case 2:
					laneObstacles = obstaclesAnimLane2;
				break;
				case 3:
					laneObstacles = obstaclesAnimLane3;
				break;
				case 4:
					laneObstacles = obstaclesAnimLane4;
				break;
				case 5:
					laneObstacles = obstaclesAnimLane5;
				break;
			}

			var i = Random.Range(0, laneObstacles.Count);
			var obj = Instantiate(laneObstacles[i], Vector3.zero, Quaternion.identity);
			obj.transform.parent = parent;
			obj.transform.localPosition = Vector3.back;
			obj.transform.localRotation = Quaternion.identity;
			obj.transform.localScale = Vector3.one;
		}		
	}
}
