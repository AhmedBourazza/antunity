using UnityEngine;

public class AntEnemy : MonoBehaviour
{
    public float speed = 3f;        // Enemy movement speed
    public Transform target;        // Target towards which the enemy moves
    public GameObject hitEffectPrefab; // Prefab for the visual effect when hit

    public float orbitSpeed = 50.0f;  // Vitesse de rotation autour de la cible
    public float moveSpeed = 2.0f;    // Vitesse de déplacement vers la cible
    public float orbitRadius = 2.5f;  // Rayon initial de l'orbite
    public float minOrbitRadius = 0.5f; // Rayon minimum d'approche

    private float angle;
    void Start()
    {
        // Place l'ennemi sur le cercle autour de la cible
        angle = Random.Range(0, 360); // Angle de départ aléatoire pour varier les positions
    }


    void Update()
    {
        if (target != null)
        {
            // Réduit progressivement le rayon de l'orbite pour se rapprocher de la cible
            orbitRadius = Mathf.Max(orbitRadius - moveSpeed * Time.deltaTime * 0.2f, minOrbitRadius);

            // Calcule la position en orbite en spirale autour de la banane
            angle += orbitSpeed * Time.deltaTime;
            float x = Mathf.Cos(angle * Mathf.Deg2Rad) * orbitRadius;
            float z = Mathf.Sin(angle * Mathf.Deg2Rad) * orbitRadius;

            // Positionne l'ennemi avec un mouvement combiné en spirale vers la banane
            Vector3 orbitPosition = target.position + new Vector3(x, 0, z);
            transform.position = Vector3.MoveTowards(transform.position, orbitPosition, moveSpeed * Time.deltaTime);

            // Optionnel : Oriente l'ennemi vers la banane
            transform.LookAt(target);
        }
    }


private void OnCollisionEnter(Collision collision)
    {
        // Check if the enemy is hit by a rocket
        if (collision.gameObject.CompareTag("Rocket"))
        {
            Die(); // Call die method
            ShowHitEffect(); // Show visual effect for being hit
            // Destroy(collision.gameObject); 
        }
    }

    void Die()
    {
        // Logic for destroying the enemy, possibly with visual effects or sounds
        Destroy(gameObject); // Destroy the enemy GameObject
    }

    void ShowHitEffect()
    {
        if (hitEffectPrefab != null)
        {
            // Instantiate hit effect at the enemy's position
            Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
        }
    }
}