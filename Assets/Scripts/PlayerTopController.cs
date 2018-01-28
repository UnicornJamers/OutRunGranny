using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTopController : MonoBehaviour
{

	public PlayerController controller;
	public PlayerDeath death;
	public LayerMask ennemyMask;
	public List<AudioData> punchlines;
	public AudioData explosion;	
	public AudioManager audioMngr;
	public float minDelayPunchline;

	private float timer = 0f;

    void FixedUpdate()
    {
		var colliders = Physics2D.OverlapAreaAll(new Vector3(-8,1,0), new Vector3(-6.5f,4.25f,0), ennemyMask);

		timer += Time.deltaTime;

		if(colliders.Length == 0 || audioMngr.efxSource.isPlaying || timer < minDelayPunchline) { return; }

		timer = 0f;
		var random = Random.value;
		random += 0.1f * colliders.Length;

		if(random > 0.6f) {
			audioMngr.RandomizeSfx(punchlines.ToArray());
		}
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.transform.tag == "Obstacle")
        {
			audioMngr.StopAll();
			audioMngr.PlaySingle(explosion);
			death.Die();
        }
    }
}
