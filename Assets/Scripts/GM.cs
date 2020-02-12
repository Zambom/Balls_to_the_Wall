using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public GameObject howToPlay;
    public GameObject wallPrefab;
    public GameObject paddle;
    public GameObject deathParticles;
    public static GM instance = null;

    private GameObject clonePaddle;
    private GameObject particlesClone;

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
        Instantiate(wallPrefab, transform.position, Quaternion.identity);

        Destroy(howToPlay, 8f);
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
        SceneManager.LoadScene("SampleScene");
    }

    public void LoseLife()
    {
        lives--;
        livesText.text = "Lives: " + lives;
        particlesClone = Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
        Destroy(clonePaddle);
        Invoke("SetupPaddle", resetDelay);
        CheckGameOver();
    }

    void SetupPaddle()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
        Destroy(particlesClone);
    }

    public void DestroyBrick()
    {
        bricks--;
        startPoints = startPoints + pointsUnit;
        pointsText.text = "Points: " + startPoints;
        CheckGameOver();
    }
}
