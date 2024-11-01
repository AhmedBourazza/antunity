using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;     // Prefab de l'ennemi (fourmi)
    public Transform spawnPoint;       // Point de d�part des ennemis
    public Transform target;           // Cible vers laquelle les ennemis se dirigent
    public float spawnInterval = 3f;   // Temps entre chaque apparition d'ennemi

    void Start()
    {
        // D�marre la g�n�ration d'ennemis en boucle
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        AntEnemy antEnemyScript = enemy.GetComponent<AntEnemy>();
        if (antEnemyScript != null)
        {
            antEnemyScript.target = target;  // D�finit la cible de l'ennemi
        }
    }
}
