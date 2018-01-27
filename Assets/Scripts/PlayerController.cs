using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject topPlayer;
    public Transform[] topPositions;

    public GameObject frontPlayer;
    public Transform[] frontPositions;

    public int currentPosition;
    private bool isMoving;
	private bool isLocked;

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
		if(isLocked) { return; }

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
}
