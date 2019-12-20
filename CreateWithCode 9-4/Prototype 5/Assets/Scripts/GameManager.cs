using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI titleScreen;
    public bool isGameActive;
    private float spawnRate = 1.5f;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        Menu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTargets()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);

            //updateScore(5);
            
        }
    }

    public void UpdateScore(int addScore)
    {
        score += addScore;
        scoreText.text = string.Format(@"Score: {0}", score);
        if (score < 0) ;
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        StopCoroutine(SpawnTargets());
    }

    public void StartGame(int difficulty) // 0 - 3
    {
        switch (difficulty)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
        }

        isGameActive = true;
        StartCoroutine(SpawnTargets());
        score = 0;
        scoreText.text = string.Format(@"Score: {0}", score);
        gameOverText.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(false);
    }

    public void Menu()
    {
        isGameActive = false;
        score = 0;
        scoreText.text = string.Format(@"Score: {0}", score);
        gameOverText.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(true);
    }
}
