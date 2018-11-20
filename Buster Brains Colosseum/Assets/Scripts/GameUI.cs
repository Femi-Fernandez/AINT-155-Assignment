using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    public Slider healthBar;
    public Text scoreText;
    public Text comboText;

    public int playerScore = 10;
    public int playerCombo = 1;
    private float combotimer = 0f;
    public float comboResetTime = 3f;

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
        playerScore += theScore * playerCombo;
        combotimer = 0;
        scoreText.text = "Score: "  +  playerScore.ToString();
    }
    private void UpdateCombo(int theCombo)
    {
        playerCombo += theCombo;
        comboText.text = "Combo: " + playerCombo.ToString();
    }

    private void Update()
    {
        combotimer += Time.deltaTime;
        if (combotimer > comboResetTime)
        {
            playerCombo = 1;
        }
    }

}
