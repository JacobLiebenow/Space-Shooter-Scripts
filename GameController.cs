using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
    public Vector3 spawnValues;
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    private bool gameOver;
    private bool restart;
    private int score;

    // Use this for initialization
    void Start() {
        score = 0;
        restartText.text = "";
        gameOverText.text = "";
        StartCoroutine (SpawnWaves());
        gameOver = false;
        restart = false;
        UpdateScore();
        
    }

    private void Update()
    {
        if (restart)
        {
            if(Input.GetKeyDown (KeyCode.R))
            {
                SceneManager.LoadScene("Main");
            }
        }
    }
    IEnumerator SpawnWaves () {

        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                SpawnAsteroid();
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if(gameOver)
            {
                restartText.text = "Press 'R' to Restart";
                restart = true;
                break;
            }
        }
	}

    void SpawnAsteroid ()
    {
        GameObject hazard = hazards[Random.Range(0, hazards.Length)];
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(hazard, spawnPosition, spawnRotation);
    }

    //Updates the int score value upon the destruction of an asteroid, and updates the GUI to display this
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        restartText.text = "Waiting...";
        gameOver = true;
    }
    
}
