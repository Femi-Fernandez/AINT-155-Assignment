using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    public Slider healthBar;
    public Text scoreText;
    public Text comboText;

    public int playerScore = 0;
    public int playerCombo = 0;

    private void OnEnable()
    {
        Player.OnUpdateHealth += UpdateHealthBar;
        AddScore.onSendScore += UpdateScore;
        ComboSystem.onSendCombo += UpdateCombo;
    }

    private void OnDisable()
    {
        Player.OnUpdateHealth -= UpdateHealthBar;
        AddScore.onSendScore -= UpdateScore;
        ComboSystem.onSendCombo -= UpdateCombo;
    }

    private void UpdateHealthBar(int health)
    {
        healthBar.value = health;
    }

    private void UpdateScore(int theScore)
    {
        playerScore += theScore;
        scoreText.text = "Score: " + playerScore.ToString();
    }
    private void UpdateCombo(int theCombo)
    {
        playerCombo += theCombo;
        comboText.text = "Combo: " + playerCombo.ToString();
    }
}
