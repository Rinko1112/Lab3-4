using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab của hình tròn (Enemy)
    public Transform player; // Vị trí của Player
    public float spawnInterval = 3f; // Thời gian tạo enemy (cứ 3s tạo 1 cái)
    public float spawnDistance = 5f; // Khoảng cách tạo enemy

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), spawnInterval, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (player == null) return;

        // Random vị trí xung quanh Player
        Vector2 spawnPos = (Vector2)player.position + Random.insideUnitCircle.normalized * spawnDistance;

        // Tạo Enemy
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
