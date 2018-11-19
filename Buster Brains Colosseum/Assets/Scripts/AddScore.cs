using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour {

    public delegate void SendScore(int theScore);
    public static event SendScore onSendScore;

    public int score = 10;

    public void OnDestroy()
    {
        if(onSendScore != null)
        {
            onSendScore(score);
        }
    }
}
