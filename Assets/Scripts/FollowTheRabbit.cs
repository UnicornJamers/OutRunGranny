using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTheRabbit : MonoBehaviour {
	
	public Transform parent;

	public float followSpeed = 10f;

	void Update () {
		parent.position = Vector3.Lerp(parent.position, transform.position, followSpeed * Time.deltaTime);
	}
}
