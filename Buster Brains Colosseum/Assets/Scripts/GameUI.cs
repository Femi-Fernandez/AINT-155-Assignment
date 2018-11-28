using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    public Slider healthBar;
    public Text scoreText;
    public Text comboText;
    public Slider comboBar;
  
    public int playerScore = 10;
    public int playerCombo = 1;
    private float combotimer = 0f;
    public float comboResetTime = 1.5f;

    private void start()
    {
        comboBar.value = 0;
    }

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
        playerCombo = 1;
    }

    private void UpdateScore(int theScore)
    {
        playerScore += theScore * playerCombo;
        combotimer = comboResetTime;
        scoreText.text = "Score: "  +  playerScore.ToString();
    }
    private void UpdateCombo(int theCombo)
    {
        playerCombo += theCombo;
        comboText.text = "Combo: " + playerCombo.ToString();
    }

    private void Update()
    {
        comboBar.value = combotimer;
        combotimer -= Time.deltaTime;
        if (0 > combotimer)
        {
            playerCombo = 1;
        }
    }

}
