using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public List<AudioData> punchlines;
    public List<AudioData> drifts;
    public AudioManager audioMngr;

    public GameObject topPlayer;
    public Transform[] topPositions;

    public GameObject frontPlayer;
    public Transform[] frontPositions;

    public int currentPosition;
    private bool isMoving;
    private bool isLocked;
    public LayerMask ennemyMask;

    public float minDelayPunchline = 5f;
    private float timerPunchline = 0f;
    private float timerDrifts = 0f;

    public PlayerDeath death;

    void Start()
    {
        currentPosition = Mathf.RoundToInt(topPositions.Length / 2);
        topPlayer.transform.position = topPositions[currentPosition].transform.position;
        frontPlayer.transform.position = frontPositions[currentPosition].transform.position;

        isMoving = false;
        isLocked = false;
    }

    void Update()
    {
        timerPunchline += Time.deltaTime;
        timerDrifts += Time.deltaTime;

        if (isLocked || death.isDead) { return; }

        var moveX = 0f;
        moveX = Input.GetAxis("Horizontal");

        if (Mathf.Abs(moveX) > 0.01f)
        {
            if (!isMoving)
            {
                isMoving = true;
                Move(moveX);
            }
        }
        else
        {
            isMoving = false;
        }
    }

    private void Move(float moveX)
    {
        var direction = moveX > 0 ? 1 : -1;

        CheckForObstacleOnLane();

        if (direction == 1 && currentPosition < topPositions.Length - 1)
        {
            currentPosition++;
        }
        else if (direction == -1 && currentPosition > 0)
        {
            currentPosition--;
        }
        PlayDrift();
        topPlayer.transform.position = topPositions[currentPosition].transform.position;
        frontPlayer.transform.position = frontPositions[currentPosition].transform.position;
    }

    private void PlayDrift()
    {
        if (timerDrifts < minDelayPunchline || audioMngr.efxSource.isPlaying) { return; }

        var randomVal = Random.value;

        if(randomVal < 0.15f) {
            timerDrifts = 0f;
            audioMngr.RandomizeSfx(drifts.ToArray());
        }

    }

    private void CheckForObstacleOnLane()
    {
        if (audioMngr.efxSource.isPlaying || timerPunchline < minDelayPunchline) { return; }

        var colliders = Physics2D.OverlapAreaAll(new Vector3(-7.3f, 5, 0), new Vector3(-3.85f, 0.75f, 0), ennemyMask);
        
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].GetComponent<ObstacleController>().lane == currentPosition)
            {
                timerPunchline = 0;
                audioMngr.RandomizeSfx(punchlines.ToArray());
            }
        }
    }
}
