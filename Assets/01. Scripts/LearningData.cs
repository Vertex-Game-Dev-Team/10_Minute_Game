// # System
using System.Collections;
using System.Collections.Generic;

// # Unity
using UnityEngine;

// # Project

public class LearningData : MonoBehaviour
{
    private int moveSpeed;
    private int learningExp;

	private void Update()
	{
		MoveTo();
	}

	public void Initialize(int moveSpeed, int learningExp)
    {
        this.moveSpeed   = moveSpeed;
        this.learningExp = learningExp;
    }

    private void MoveTo()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }
}
