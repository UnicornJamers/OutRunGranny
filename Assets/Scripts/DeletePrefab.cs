using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePrefab : MonoBehaviour {

	public float lifespan = 2f;

	void Update () {
		lifespan -= Time.deltaTime;
		if(lifespan <= 0f) {
			Destroy(gameObject);
		}		
	}
}
