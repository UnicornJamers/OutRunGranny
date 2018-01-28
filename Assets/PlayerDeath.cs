using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

	public GameObject explosion;
	public SpriteRenderer myRenderer;

	void Start() {
		myRenderer = GetComponent<SpriteRenderer>();
	}

	public void Die()
    {
		myRenderer.sprite = null;
		Instantiate (explosion, transform.position, transform.rotation);
    }
}
