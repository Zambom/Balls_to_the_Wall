using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    public int lives = 3;
    public int pointsUnit = 5;
    public int startPoints = 0;
    public int bricks = 384;
    public float resetDelay = 1f;
    public Text livesText;
    public Text pointsText;
    public GameObject gameOver;
    public GameObject winner;
    public GameObject wallPrefab;
    public GameObject paddle;
    public static GM instance = null;

    private GameObject clonePaddle;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        Setup();
    }

    public void Setup()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
    }

    void CheckGameOver()
    {
        if (bricks < 1)
        {
            winner.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }

        if (lives < 1)
        {
            gameOver.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }
    }

    void Reset()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(Application.loadedLevel);
    }

    public void LoseLife()
    {
        lives--;
        livesText.text = "Lives: " + lives;
        Destroy(clonePaddle);
        Invoke("SetupPaddle", resetDelay);
        CheckGameOver();
    }

    void SetupPaddle()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
    }

    public void DestroyBrick()
    {
        bricks--;
        startPoints += pointsUnit;
        pointsText.text = "Points: " + startPoints;
        CheckGameOver();
    }
}
