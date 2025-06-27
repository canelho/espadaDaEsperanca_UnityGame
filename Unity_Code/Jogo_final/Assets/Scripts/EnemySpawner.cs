using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float minSpawnDelay = 10f;
    public float maxSpawnDelay = 20f;
    public int maxSpawnCount = 10; // Número máximo de spawns
    private int currentSpawnCount = 0; // Contador de spawns atual

    private Transform[] spawnPoints;

    private void Start()
    {
        spawnPoints = new Transform[transform.childCount];
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            spawnPoints[i] = transform.GetChild(i);
        }

        Invoke("SpawnEnemy", GetRandomSpawnDelay());
    }

    private void SpawnEnemy()
    {
        int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomSpawnIndex];

        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

        currentSpawnCount++;

        if (currentSpawnCount >= maxSpawnCount)
        {
            Invoke("CheckEnemiesInGame", 13f); // Verifica após 13 segundos
        }
        else
        {
            Invoke("SpawnEnemy", GetRandomSpawnDelay());
        }
    }

    private void CheckEnemiesInGame()
    {
        // Verifica se não há inimigos em jogo antes de fazer a transição
        if (GameObject.FindWithTag("Enemy") == null)
        {
            Debug.Log("Transição para a cena de vitória");
            SceneManager.LoadScene("Vitória");
        }
        else
        {
            Debug.Log("Ainda há inimigos em jogo");
        }
    }

    private float GetRandomSpawnDelay()
    {
        return Random.Range(minSpawnDelay, maxSpawnDelay);
    }
}
