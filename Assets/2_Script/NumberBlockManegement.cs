using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NumberBlockManegement : MonoBehaviour
{
    public GameObject numberBlockPrefab;

    private GameObject[,] numBlockBase;
    private GameObject[,] numBlocks;

    private void Awake()
    {
        numBlockBase = new GameObject[4,4];
        numBlocks = new GameObject[4,4];
    }

    private void Start ()
    {
		for(int i = 0 ; i < 4 ; i++)
        {
            for(int j = 0 ; j < 4 ; j++)
            {
                numBlockBase[i,j] = transform.GetChild(i).GetChild(j).gameObject;
            }
        }

        GameStart();
	}
	
	private void Update ()
    {
	}

    public void GameStart()
    {
        for(int i = 0 ; i < 2 ;i++)
        {
            CreateNumberBlock();
        }
    }

    public bool CreateNumberBlock()
    {
        if(CheckArrayElementNull(numBlocks))
        {
            return false;
        }


        for(;;)
        {
            int x = Random.Range(0,4);
            int y = Random.Range(0,4);

            if(numBlocks[y, x] == null)
            {
                numBlocks[y, x] = Instantiate(numberBlockPrefab,numBlockBase[y,x].transform.position,Quaternion.identity);

                break;
            }
        }

        return true;
    }

    private bool CheckArrayElementNull(GameObject[,] array)
    {
        for(int i = 0 ; i < array.GetLength(0) ; i++)
        {
            for(int j = 0 ; j < array.GetLength(1) ; j++)
            {
                if(array[i,j] == null)
                {
                    return false;
                }
            }
        }

        return true;
    }
}
