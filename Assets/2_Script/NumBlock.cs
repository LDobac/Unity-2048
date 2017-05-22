using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NumBlock : MonoBehaviour
{
	public float blockMoveSpeed;

	public bool isMove = false;
	public int targetX = -1;
	public int targetY = -1;


	private const int basedNumber = 2; 

	private int blockNumber;
	private bool isCombine = false;
	private Color curColor;
	private SpriteRenderer spriteRenderer;
	private Text numberText;

    private void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		numberText = transform.GetChild(0).GetChild(0).GetComponent<Text>();

		blockNumber = basedNumber * Random.Range(1,3);
		numberText.text = blockNumber.ToString();

		curColor.r = 1.0f - ((float)blockNumber / 255.0f);
		curColor.b = 1.0f - ((float)blockNumber * 3 / 255.0f);
		curColor.g = 1.0f - ((float)blockNumber * 5 / 255.0f);
		curColor.a = 1.0f;
		spriteRenderer.color = curColor;
	}

	public void Combine()
	{
		blockNumber *= 2;
		numberText.text = blockNumber.ToString();

		curColor.r -= 0.03f;
		curColor.g -= 0.07f;
		curColor.b -= 0.05f;
		spriteRenderer.color = curColor;
	}

	public void Move(int tarX,int tarY)
	{
		isMove = true;

		targetX = tarX;
		targetY = tarY;
	}
	public void MoveEnd()
	{
		isMove = false;

		targetX = -1;
		targetY = -1;
	}

	public int BlockNumber
	{
		get
		{
			return blockNumber;
		}
	}

	public bool IsCombine
	{
		get
		{
			return isCombine;
		}
	}
}
