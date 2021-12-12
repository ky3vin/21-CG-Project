using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore_Forest : MonoBehaviour
{
    public Text txt;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        txt.text = score.ToString();
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Strawberry")
        {
            score += 1;
            txt.text = score.ToString();
        }
    }
}
