// # System
using System.Collections;
using System.Collections.Generic;

// # Unity
using UnityEngine;

// # Project

public class GameManager : Singleton<GameManager>
{
	private int				 money;

	[Header("�н� ���� ����")]
	[SerializeField]
	private LearningDataSO[] learningDataList;
	[SerializeField]
	private int[]			 targetLearningLevelExp;
	private int				 learningLevel;
	private int				 currentlearningExp;
	private int				 maxlearningExp;
	
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
	}

	private void Start()
	{
		// �ִ� ����ġ �����ϱ�
		maxlearningExp = targetLearningLevelExp[learningLevel + 1];	
	}

	public LearningDataSO GetLearningData()
	{
		return learningDataList[learningLevel];
	}

	public void GetExp(int exp)
	{
		if(learningLevel >= learningDataList.Length)
			return;

		currentlearningExp += exp;
		
		 if(currentlearningExp >= maxlearningExp)
		{
			learningLevel++;
			currentlearningExp = 0;
            maxlearningExp     = targetLearningLevelExp[learningLevel + 1];
		}
	}
}
