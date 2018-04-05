using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreforCoin : MonoBehaviour
{

    public static float CoinScore = 0.0f;
    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 2;
    private int scoreToNextLevel = 100;
    private bool isDeath = false;
    public Text scoreText;
    public DeathMenu deathMenu;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isDeath)
        {
            return;
        }
        scoreText.text = ((int)CoinScore).ToString();
    }


    public void OnDeath()
    {
        isDeath = true;
        PlayerPrefs.SetFloat("Coin Score", CoinScore);
        deathMenu.ToggleEndMenu(CoinScore);
        ScoreforCoin.CoinScore = 0;
    }
}
