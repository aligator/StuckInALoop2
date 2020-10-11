using System.Collections.Generic;
using UnityEngine;

/**
 * EnemySpawnHandler is responsible for spawning the enemies.
 * For now the order of them is hardcoded.
 *
 * It is required to pass a Prefab for each enemy type which is used as base
 * for the types.
 */
public class EnemySpawnHandler : MonoBehaviour {
    /**
     * enemyPrefabs contains the prefabs for all possible enemy types.
     */
    [SerializeField] private GameObject[] enemyPrefabs;

    /**
     * List of enemies which have to be spawned in the given order.
     */
    private EnemyStartingStats[] enemiesToSpawn;

    /**
     * The time at which the last enemy has been spawned.
     */
    private float lastSpawnTime;

    /**
     * The index of the next enemy to be spawned.
     */
    private int nextEnemy;

    /**
     * Dictonary which maps all EnemyTypes to the passed prefabs.
     */
    private Dictionary<EnemyType, GameObject> possibleEnemies;

    /**
     * The x value behind which the enemies should be spawned.
     */
    private float screenEndX;

    /**
     * The full screen height to calculate the correct position of new enemies.
     */
    private float screenHeight;

    private void Start() {
        // Create the possibleEnemies map out of the passed GameObjects.
        possibleEnemies = new Dictionary<EnemyType, GameObject>();
        for (var i = enemyPrefabs.Length - 1; i >= 0; i--) possibleEnemies.Add((EnemyType) i, enemyPrefabs[i]);

        // Get the camera data to correctly place the enemies.
        var cam = GetComponentInChildren<Camera>();
        var vertExtent = cam.orthographicSize;
        var horzExtent = vertExtent * Screen.width / Screen.height;
        screenEndX = horzExtent;
        screenHeight = vertExtent * 2;

        // Hardcoded list of enemies to be spawned.
        enemiesToSpawn = new[] {
            new EnemyStartingStats(EnemyType.Weak, 1, 0.5f, 100, 2),
            new EnemyStartingStats(EnemyType.Medium, 1, 1f, 50, 1),
            new EnemyStartingStats(EnemyType.Strong, 1, 0f, 80, 1),
            new EnemyStartingStats(EnemyType.Weak, 1, 0.1f, 100, 1)
        };

        lastSpawnTime = 0;
        nextEnemy = 0;
    }

    // Update is called once per frame
    private void FixedUpdate() {
        // Stop spawning when all enemies are spawned.
        if (nextEnemy >= enemiesToSpawn.Length) return;

        // Wait until next enemy can be spawned.
        if (Time.fixedTime < lastSpawnTime + enemiesToSpawn[nextEnemy].spawnWaitTime) return;

        // Spawn a new enemy.
        SpawnEnemy(enemiesToSpawn[nextEnemy]);
        nextEnemy++;
        lastSpawnTime = Time.fixedTime;
    }

    /**
     * Spawns a new enemy with the given data.
     */
    private GameObject SpawnEnemy(EnemyStartingStats stats) {
        // Create the new enemy based on the given type.
        var newEnemy = Instantiate(possibleEnemies[stats.type]);

        // Get the sprite dimensions.
        var spriteRenderer = possibleEnemies[stats.type].GetComponent<SpriteRenderer>();
        var size = spriteRenderer.size;

        // Position the new enemy.
        newEnemy.transform.position = new Vector3(screenEndX + size.x / 2,
            (screenHeight - size.y) * stats.yPositionPercentage - screenHeight / 2 + size.y / 2, 0);

        // Apply a force.
        var rigid = newEnemy.GetComponent<Rigidbody2D>();
        rigid.AddForce(new Vector2(1, 0) * -stats.speed);
        return newEnemy;
    }

    private enum EnemyType {
        Weak,
        Medium,
        Strong
    }

    /**
     * EnemyStartingStats contains all data needed to spawn a new enemy.
     */
    private struct EnemyStartingStats {
        public readonly EnemyType type;

        public readonly float speed;

        public int damage;

        /**
         * yPositionPercentage is used to calculate the position for the new enemy out of the screen size.
         * 1.0f is at the top,
         * 0.0f is at the bottom.
         */
        public readonly float yPositionPercentage;

        /**
         * spawnWaitTime is the time between the last spawn and this one.
         */
        public readonly float spawnWaitTime;

        public EnemyStartingStats(EnemyType type, int damage, float yPositionPercentage, float speed,
            float spawnWaitTime) {
            this.type = type;
            this.damage = damage;
            this.yPositionPercentage = yPositionPercentage;
            this.speed = speed;
            this.spawnWaitTime = spawnWaitTime;
        }
    }
}