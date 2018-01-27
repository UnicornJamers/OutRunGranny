using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathRay : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		Destroy(other.gameObject, 0.1f);	
	}
}
