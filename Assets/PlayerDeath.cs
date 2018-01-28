using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

	public GameObject explosion;
	public SpriteRenderer myRenderer;
	public bool isDead;

	void Start() {
		isDead = false;
		myRenderer = GetComponent<SpriteRenderer>();
	}

	public void Die()
    {
		if(!isDead){
			myRenderer.sprite = null;
			Instantiate (explosion, transform.position, transform.rotation);
			isDead = true;
		}
    }
}
