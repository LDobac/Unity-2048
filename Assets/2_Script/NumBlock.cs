using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NumBlock : MonoBehaviour
{
	private const int basedNumber = 2; 

	private int blockNumber;
	private Color curColor;
	private SpriteRenderer spriteRenderer;
	private Text numberText;

    private void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		numberText = transform.GetChild(0).GetChild(0).GetComponent<Text>();

		blockNumber = basedNumber * Random.Range(1,2);
		numberText.text = blockNumber.ToString();

		curColor = new Color(0.08f + ((float)blockNumber / 10.0f) ,0.05f,0.05f,1.0f);
	}

	public void CombineBlock(NumBlock other)
	{
		blockNumber *= 2;
		numberText.text = blockNumber.ToString();

		curColor.r += ((float)blockNumber / 10.0f);
		spriteRenderer.color = curColor;
	}
}
