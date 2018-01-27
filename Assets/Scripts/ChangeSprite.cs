using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{

    public Sprite sprite;
	public bool flipIt;

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player") {

			var renderObj = other.GetComponent<SpriteRenderer>();
			renderObj.flipX = flipIt;
			renderObj.sprite = sprite;
		}		
	}
}
