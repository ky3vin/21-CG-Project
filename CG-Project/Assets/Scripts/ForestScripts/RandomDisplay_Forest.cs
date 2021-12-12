using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDisplay_Forest : MonoBehaviour
{
    int SIZE = 10;
    int numOfChild = 63;
    int[] visibleStrawberries = new int[10];
    
    void Awake()
    {
        for (int i = 0; i < numOfChild; i++)
        {
            GameObject temp = transform.GetChild(i).gameObject;
            temp.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < SIZE; i++)
        {
            int randNum;
            randNum = Random.Range(0, numOfChild + 1);
            for (int j = 0; j < i; j++)
            {
                if (visibleStrawberries[j] == randNum)
                {
                    randNum = Random.Range(0, numOfChild + 1);
                }
                else
                {
                    visibleStrawberries[i] = randNum;
                }
            }
               
            Debug.Log(visibleStrawberries[i]);
        }

        for (int i = 0; i < SIZE; i++)
        {
            GameObject temp = transform.GetChild(visibleStrawberries[i]).gameObject;
            temp.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
