using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int score;
    private bool gameOver;
    private bool restart;

    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text textScore;
    public Text textGameOver;
    public Text textRestart;


    void Start()
    {
        restart = false;
        gameOver = false;
        textGameOver.text = string.Empty;
        textRestart.text = string.Empty;
        StartCoroutine(SpawnWaves());
        score = 0;
        UpdateScore();
    }

    void Update()
    {
        if(restart)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(0);
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];   
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            if(gameOver)
            {
                textRestart.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        UpdateScore();
    }

    public void GameOver()
    {
        textGameOver.text = "Game Over";
        gameOver = true;
    }

    void UpdateScore()
    {
        textScore.text = "Score:" + score;
    }

   
}