using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboSystem : MonoBehaviour {

    public delegate void SendCombo(int theCombo);
    public static event SendCombo onSendCombo;

    public int combo = 1;

    public void OnDestroy()
    {
        if (onSendCombo != null)
        {
            onSendCombo(combo);
        }
    }
}
