// # System
using System.Collections;
using System.Collections.Generic;

// # Unity
using UnityEngine;

// # Project

public class GameManager : Singleton<GameManager>
{
	private int   money;

	[Header("�н� ���� ����")]
	[SerializeField]
	private int[] targetLearningLevelExp;
	private int   learningLevel;
	private int   currentlearningLevelExp;
	private int   maxlearningLevelExp;
	
	public int Money 
	{ 
		get {  return money; } 
		set
		{
			money = value;

			if(money < 0)
				money = 0;
		}
	}
	public int LearningLevel
	{ 
		get { return learningLevel; }
		set
		{
			learningLevel = value;

			if(learningLevel < 0)
				learningLevel = 0;
		}
	}

}
