// # System
using System.Collections;
using System.Collections.Generic;

// # Unity
using UnityEngine;

// # Project

public class LearningDataSpawner : MonoBehaviour
{
	[SerializeField]
	private GameObject learningDataObject;
	[SerializeField]
	private Transform  canvasParent;
	[SerializeField]
	private Transform  spawnPosition;
	[SerializeField]
	private int		   spawnTime;

	private void Start()
	{
		StartCoroutine(SpawnLearningData());
	}

	private IEnumerator SpawnLearningData()
	{
		WaitForSeconds waitForSeconds = new WaitForSeconds(spawnTime);

		while(true)
		{
			GameObject temp = Instantiate(learningDataObject, spawnPosition.position, Quaternion.identity);

			// 데이터 가져오기
			int moveSpeed   = GameManager.Instance.GetLearningData().moveSpeed;
			int learningExp = GameManager.Instance.GetLearningData().learningExp;

			// 생성된 오브젝트 설정
			temp.transform.SetParent(canvasParent);
			temp.GetComponent<LearningData>().Initialize(moveSpeed, learningExp);

			yield return waitForSeconds;
		}
	}

}
