using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characters;


    private void Start()
    {
        int chosen = PlayerPrefs.GetInt("selectedCharacter");
        for (int i = 0; i < characters.Length; ++i)
        {
            if (i != chosen) characters[i].SetActive(false);
        }
    }
}
