using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlockController : MonoBehaviour 
{
	public Text curScoreText;
	public Text bestScoreText;

	private float curScore = 0.0f;
	private float bestScore = 0.0f;

	private NumberBlockManegement blockManegement;

	private void Start()
	{
		blockManegement = GetComponent<NumberBlockManegement>();
	}

	private void Update()
	{
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

		curScoreText.text = curScore.ToString();
		bestScoreText.text = bestScore.ToString();

	}

	public void RestartButtonPush()
	{
		SceneManager.LoadScene("Game");
	}	
}
