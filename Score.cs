using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Score : MonoBehaviour
{
    //public Text scoreText;

    public TextMeshProUGUI scoreText;
    public int Scor=0;

    public void scoreupdate()
    {
        Scor++;
        scoreText.text = "" + Scor;
    }

   
}
