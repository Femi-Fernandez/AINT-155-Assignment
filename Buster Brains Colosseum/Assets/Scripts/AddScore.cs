using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour {

    public delegate void SendScore(int theScore);
    public static event SendScore onSendScore;

    int score = 10;

    private bool scoreSent = false;
    public void OnAddScore()
    {
        if (onSendScore != null)
        {
            if (!scoreSent)
            {
                scoreSent = true;
                onSendScore(score);
            }
        }
    }
}
