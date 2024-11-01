using UnityEngine;

public class AntEnemy : MonoBehaviour
{
    public float speed = 3f;        // Enemy movement speed
    public Transform target;        // Target towards which the enemy moves
    public GameObject hitEffectPrefab; // Prefab for the visual effect when hit

    void Update()
    {
        // Move towards the target if it is assigned
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
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
