using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlockController : MonoBehaviour 
{
	public Text curScoreText;
	public Text bestScoreText;
	public GameObject ClearUI;
	public GameObject OverUI;

	private bool isPause = false;
	private bool isClear = false;
	private float curScore = 0.0f;
	private float bestScore = 0.0f;

	private NumberBlockManegement blockManegement;

	private void Start()
	{
		blockManegement = GetComponent<NumberBlockManegement>();
	}

	private void Update()
	{
		if(!isPause)
		{
			if(!(blockManegement.CanBlockMove() || blockManegement.IsBlockMove))
			{
				if(!(blockManegement.CanBlockMove() || blockManegement.IsBlockMove))
				{		
					if(!(blockManegement.CanBlockMove() || blockManegement.IsBlockMove))
				{	
					if(!(blockManegement.CanBlockMove() || blockManegement.IsBlockMove))
				{			
					Pause();

					OverUI.SetActive(true);
				}
				}
				}
			}

			if(Input.GetKeyDown(KeyCode.UpArrow))
			{
				blockManegement.ToUp();
			}
			else if(Input.GetKeyDown(KeyCode.DownArrow))
			{
				blockManegement.ToDown();
			}
			else if(Input.GetKeyDown(KeyCode.LeftArrow))
			{
				blockManegement.ToLeft();
			}
			else if(Input.GetKeyDown(KeyCode.RightArrow))
			{
				blockManegement.ToRight();
			}
		}
	}

	public void RestartButtonPush()
	{
		SceneManager.LoadScene("Game");
	}

	public void AddScore(int score)
	{
		curScore += score;
		curScoreText.text = curScore.ToString();

		if(score == 2048 && !isClear)
		{
			//클리어에 관련된 내용
			isClear = true;

			Pause();
			ClearUI.SetActive(true);	
		}
	}

	public void Pause()
	{
		isPause = true;
	}	

	public void Resume()
	{
		isPause = false;
	}
}
