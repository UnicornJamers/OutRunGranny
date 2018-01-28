using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour {

	public Transform parent;
	public GameObject[] obstaclesCar;
	public GameObject[] obstaclesTruck;

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Obstacle") {
			var obstacleCtrl = other.GetComponent<ObstacleController>();
			var lane = obstacleCtrl.lane;
			var type = obstacleCtrl.type;
			GameObject obstacle;
			if(type == VehicleType.Car)
			{
				obstacle = obstaclesCar[lane];
			} else {
				obstacle = obstaclesTruck[lane];
			}

			var obj = Instantiate(obstacle, Vector3.zero, Quaternion.identity);
			obj.transform.parent = parent;
			obj.transform.localPosition = Vector3.back;
			obj.transform.localRotation = Quaternion.identity;
			obj.transform.localScale = Vector3.one;
		}		
	}
}
