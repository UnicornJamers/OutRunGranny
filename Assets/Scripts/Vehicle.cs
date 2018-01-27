using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour {

	public float speed = 0f;
	public float lifeSpan = 10f;

	void Update() {

		lifeSpan -= Time.deltaTime;

		if(lifeSpan <= 0){
			Destroy(this.gameObject);
		}
		transform.Translate(0f, 0f, speed * Time.deltaTime);
	}
}
