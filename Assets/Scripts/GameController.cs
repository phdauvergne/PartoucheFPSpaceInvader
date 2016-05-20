using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour 
{
    private List<GameObject> listOfClones = new List<GameObject>();

    // Type of ennemis
    public GameObject[] ennemiHazard;

    // Number of ennemis
    public int numberOfWaves;
    public int sizeOfWave;
    public Vector3 spawnValues;

    // Time in between waves/start/spawn
    public float spawnWait;
    public float startWait;
    public float waveWait;

    // GUI
    private int score = 0;
    public int hitPoints;
    private bool gameOver;
    private bool restart;
    
    // GUI
    public Text scoreText;
    public Text hitPointText;
    public Text gameOverText;
    public Text restartText;

	void Start ()
    {
        gameOver = false;
        restart = false;
        score = 0;

        restartText.text = "";
        gameOverText.text = "";
        
        updateScore();
        updateHitPoints();

        StartCoroutine(SpawnWaves());
	}
	
	void Update () 
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }

        // once the hit points is 0
        if (gameOver)
        {
            foreach (GameObject clone in listOfClones)
            {
                GameObject.Destroy(clone);
            }
            listOfClones.Clear();
            restartText.text = "Press 'R' to restart";
            restart = true;
            //break;
        }
	}

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while(!gameOver)
        {
            for (int i = 0; i < numberOfWaves; i++)
            {
                Vector3[] listSpawnPosition = new Vector3[sizeOfWave];
                Quaternion spawnRotation = Quaternion.identity;

                for (int j = 0; j < sizeOfWave; j++)
                {
                    // if multiple waves (vertically)
                    listSpawnPosition[j] = new Vector3(spawnValues.x, (spawnValues.y + (5.0f * j)), spawnValues.z);

                    // spawns at random different kind of waves
                    GameObject ennemi;
                    if (Random.Range(0.0f, 1.0f) > 0.25f)
                        ennemi = ennemiHazard[0];
                    else
                        ennemi = ennemiHazard[1];

                    // instantiation of different waves of ennemy
                    if (!gameOver)
                    { 
                        listOfClones.Add((GameObject) Instantiate(ennemi, listSpawnPosition[j], spawnRotation));

                        Debug.Log("Spawn a wave");
                    }
                }

                yield return new WaitForSeconds(spawnWait);
            }

            yield return new WaitForSeconds(waveWait);
        }
    }

    public void addScore(int value)
    {
        score += value;
        updateScore();
    }

    void updateScore()
    {
        scoreText.text = "Score : " + score;
    }

    
    void updateHitPoints()
    {
        hitPointText.text = "Hit points : " + hitPoints;
    }

    public void loseHitPoint()
    {
        if(hitPoints > 0)
            hitPoints--;

        updateHitPoints();

        if(hitPoints == 0)
        {
            GameOver();

            //Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over !";
        gameOver = true;
    }

    public bool getGameOver()
    {
        return gameOver;
    }
}
