using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    public Slider healthBar;
    public Text scoreText;
    public Text comboText;
    public Slider comboBar;
    public Image reloadTimer;
    public Text ZombieCounterText;
    public Image playerHealth;
    public Text BulletCount;

  
    public int playerScore = 10;
    public int playerCombo = 1;
    private float combotimer = 0f;
    public float comboResetTime = 1.5f;
    public float reloadTime = 1.5f;
    public bool reloading = false;
    private GameObject[] getCount;
    public int bulletcount = 30;

    private void start()
    {
        comboBar.value = 0;
        reloadTimer.fillAmount = 1.0f;
        bulletcount = 30;
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
        PlayerPrefs.SetInt("Score", playerScore);
    }

    private void UpdateHealthBar(int health)
    {
        float healthtofloat = (float)health;
        float imagefill = (healthtofloat / 100);
        print(imagefill);
        print(health);
        playerHealth.fillAmount = imagefill;
    }

    private void UpdateScore(int theScore)
    {
        playerScore += theScore * playerCombo;
        
        scoreText.text = "Score: "  +  playerScore.ToString();
    }
    private void UpdateCombo(int theCombo)
    {
        playerCombo += theCombo;
        combotimer = comboResetTime;
        comboText.text = "Combo: " + playerCombo.ToString();
    }

    private void Update()
    {
        comboBar.value = combotimer;
        combotimer -= Time.deltaTime;
        if (0 > combotimer)
        {
            playerCombo = 1;
            comboText.text = "Combo: " + playerCombo.ToString();
        }

        if (reloading == true)
        {
            reloadTimer.fillAmount += 1.0f / reloadTime * Time.deltaTime;   
        }
  
        getCount = GameObject.FindGameObjectsWithTag("Enemy");
        int count = getCount.Length;

        ZombieCounterText.text = "Zombies alive: " + count;
    }

    public void BulletCounterReset()
    {
        bulletcount = 30;
        BulletCount.text = bulletcount + "/30 bullets left.";
    }

    public void BulletCounter()
    {
        bulletcount = bulletcount - 1;
        BulletCount.text = bulletcount + "/30 bullets left.";
    }

    public void reloadtimerCountdown()
    {
        reloading = true;
        reloadTimer.fillAmount = 0.0f;
    }

}
