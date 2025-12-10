using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public GameObject enemyPrefab;

    public GameObject CreateEnemy()
    {
        float randomX = Random.Range(-8f, 8f);
        float randomY = Random.Range(-4f, 4f);
        Vector2 spawnPos = new Vector2(randomX, randomY);

        return Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}