using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn_Forest : MonoBehaviour
{
    int SIZE = 7;
    int numOfChild = 15;
    int[] spawnEnemies = new int[7];

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
                if (spawnEnemies[j] == randNum)
                {
                    randNum = Random.Range(0, numOfChild + 1);
                }
                else
                {
                    spawnEnemies[i] = randNum;
                }
            }

            Debug.Log(spawnEnemies[i]);
        }

        for (int i = 0; i < SIZE; i++)
        {
            GameObject temp = transform.GetChild(spawnEnemies[i]).gameObject;
            temp.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
