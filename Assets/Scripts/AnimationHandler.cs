using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour {

	public Transform parent;
	public List<GameObject> obstaclesAnim;

	private int maxLane;
	private Animator animtor;
	
	void Awake() {
		animtor = GetComponent<Animator>();
		maxLane = GameObject.FindGameObjectsWithTag("PlayerPoint").Length;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Obstacle") {
			var lane = other.GetComponent<ObstacleController>().lane;
			var obj = Instantiate(obstaclesAnim[lane], Vector3.zero, Quaternion.identity);
			obj.transform.parent = parent;
			obj.transform.localPosition = Vector3.back;
			obj.transform.localRotation = Quaternion.identity;
			obj.transform.localScale = Vector3.one;
		}		
	}
}
