using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject GameOverText;
    public Text ScoreText;
    public float ScrollSpeed { get; private set; }
    public bool bIsGameOver { get; private set; }
    public uint Score { get; private set; }
    void Awake()
    {
        if (Instance == null)
        {
            bIsGameOver = false;
            Instance = this;
            ScrollSpeed = -1.5f;
            Score = 0;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (bIsGameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            bIsGameOver = false;
        }
    }

    public void CatScored()
    {
        if (bIsGameOver)
        {
            return;
        }
        ++Score;
        ScoreText.text = $"Score : {Score}";
    }

    public void CatDied()
    {
        GameOverText.SetActive(true);
        bIsGameOver = true;
        Score = 0;
    }

}
