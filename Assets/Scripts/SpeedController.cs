using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour {

	public GlobalSpeed speed;
	public float acceleration = .5f;
	
	void Update () {
		speed.minimalSpeed += acceleration * Time.deltaTime;
	}
}
