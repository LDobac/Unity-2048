using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NumBlock : MonoBehaviour
{
	public float blockMoveSpeed;


	private const int basedNumber = 2; 




	private bool isMove = false;
	private Vector3 targetPosition;
	private NumBlock combinedBlock = null;

	private int blockNumber;
	private bool isCombine = false; //합체를 하는 쪽의 객체 일경우 true
	private Color curColor;
	private SpriteRenderer spriteRenderer;
	private Text numberText;
	private Animator animator;

    private void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		animator = GetComponent<Animator>();

		numberText = transform.GetChild(0).GetChild(0).GetComponent<Text>();

		blockNumber = basedNumber * Random.Range(1,3);
		numberText.text = blockNumber.ToString();

		curColor.r = 1.0f - ((float)blockNumber / 255.0f);
		curColor.b = 1.0f - ((float)blockNumber * 3 / 255.0f);
		curColor.g = 1.0f - ((float)blockNumber * 5 / 255.0f);
		curColor.a = 1.0f;
		spriteRenderer.color = curColor;
	}

	private void Update()
	{
		if(isCombine)
		{
			if(combinedBlock != null && !isMove)
			{
				if(!combinedBlock.isMove)
				{
					Combine();
				}
			}
		}

		if(isMove)
		{
			float speed = blockMoveSpeed * Time.deltaTime;
            Vector3 current = transform.position;

            transform.position = Vector3.MoveTowards(current,targetPosition, speed);

			if(transform.position == targetPosition)
			{
				MoveEnd();
			}
		}
	}

	private void Combine()
	{
		blockNumber *= 2;
		numberText.text = blockNumber.ToString();

		curColor.r -= 0.03f;
		curColor.g -= 0.07f;
		curColor.b -= 0.05f;
		spriteRenderer.color = curColor;

		Destroy(combinedBlock.gameObject);

		animator.SetTrigger("Combine");	

		isCombine = false;
		combinedBlock = null;
	}

	public void CombineBlock(NumBlock block)
	{
		combinedBlock = block;
		combinedBlock.IsCombine = true;
		isCombine = true;
	}


	public void Move(Vector3 target)
	{
		isMove = true;

		targetPosition = target;
	}
	public void MoveEnd()
	{
		isMove = false;

		targetPosition.Set(-1,-1,-1);
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
		set
		{
			isCombine = value;
		}
	}

	public bool IsMove
	{
		get
		{
			return isMove;
		}
	}
}
