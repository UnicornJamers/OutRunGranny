﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public List<AudioData> punchlines;
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
    private float timer;

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
        timer += Time.deltaTime;

        if (isLocked) { return; }

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
        topPlayer.transform.position = topPositions[currentPosition].transform.position;
        frontPlayer.transform.position = frontPositions[currentPosition].transform.position;
    }

    private void CheckForObstacleOnLane()
    {
        if (audioMngr.efxSource.isPlaying || timer < minDelayPunchline) { return; }

        var colliders = Physics2D.OverlapAreaAll(new Vector3(-7.5f, 1, 0), new Vector3(-6, 4.25f, 0), ennemyMask);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].GetComponent<ObstacleController>().lane == currentPosition + 1)
            {
                timer = 0;
                audioMngr.RandomizeSfx(punchlines.ToArray());
            }
        }
    }
}
