using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

	public GameObject explosion;
	public Spawn spawner;
	public SpriteRenderer myRenderer;
	public GameObject playerTop;
	public bool isDead;

	void Start() {
		isDead = false;
		myRenderer = GetComponent<SpriteRenderer>();
	}

	public void Die()
    {
		if(!isDead){
			myRenderer.sprite = null;
			GameObject KBoom = Instantiate (explosion, transform.position, transform.rotation);
			isDead = true;
			Destroy(KBoom, 1f);
			spawner.canSpawn = false;
			playerTop.GetComponent<SpriteRenderer>().sprite = null;
		}
    }
}
