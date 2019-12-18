using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    private float spawnRate = 1.5f;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTargets());
        score = 0;
        scoreText.text = string.Format(@"Score: {0}", score);
        gameOverText.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTargets()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);

            //updateScore(5);
            
        }
    }

    public void updateScore(int addScore)
    {
        score += addScore;
        scoreText.text = string.Format(@"Score: {0}", score);
        if (score < 0) ;
    }
}
