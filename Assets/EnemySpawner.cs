using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Le prefab de l'ennemi à instancier
    public float spawnInterval = 2.0f; // Temps entre les spawn d'ennemis

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Récupérer toutes les bananes avec le tag "Banana"
            GameObject[] bananas = GameObject.FindGameObjectsWithTag("SpecificObject");

            // S'assurer qu'il y a au moins une banane dans la scène
            if (bananas.Length > 0)
            {
                // Choisir une banane aléatoire
                GameObject targetBanana = bananas[Random.Range(0, bananas.Length)];
                Vector3 spawnPoint = targetBanana.transform.position; // Point de spawn au niveau de la banane

                // Instancier un ennemi à la position de la banane
                Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
            }

            // Attendre avant de respawn
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
