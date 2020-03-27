using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static bool startGame = false;
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    public Text waveCountDownTimerText;

    private float countDown = 2f;
    private int waveNumber = 1;
  
    void Update () {
        if (startGame) {
            if (countDown <= 0f) {
                StartCoroutine(SpawnWave());
                countDown = timeBetweenWaves;
                startGame = false;
            }
            countDown -= Time.deltaTime;
            if (countDown >= 0f && startGame) {
                waveCountDownTimerText.text = Mathf.Round(countDown).ToString();
            } else {
                waveCountDownTimerText.text = "";
            }
        }
    }

    IEnumerator SpawnWave () {
        // Spawn the waves 
        waveNumber++;
        for (int i = 0; i < waveNumber; i++) {
            SpawnEnemy(i);
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy (int id) {
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation).gameObject;
        enemy.name = id.ToString();
    }
}
