using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour 
{
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
	}	
}
