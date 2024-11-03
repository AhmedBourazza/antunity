using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    // Compteur qui sera décrémenté
    public int counter = 10;

    // Tag de l'objet avec lequel le joueur doit entrer en collision
    public string targetTag = "SpecificObject"; // Changez ici pour qu'il corresponde au tag de vos bananes

    // Tag pour les ennemis
    public string enemyTag = "Enemy"; // Assurez-vous que vos ennemis ont ce tag

    // Référence au texte UI (Text ou TextMeshPro)
    public TextMeshProUGUI counterText;  // Utiliser TextMeshPro (sinon remplacer par 'Text' si tu utilises l'UI de base)

    // Compteur pour les roquettes restantes
    public int rocketCount = 10; // Nombre initial de roquettes

    // Référence au texte UI pour afficher le nombre de roquettes
    public TextMeshProUGUI rocketCounterText;


    // Score du joueur (basé sur le compteur restant)
    public int score;

    void Start()
    {
        // Initialise le texte avec la valeur actuelle du compteur
        UpdateCounterText();
        UpdateRocketCounterText(); // Met à jour le texte des roquettes
    }

    void Update()
    {
        // Exécuter le tir en appuyant sur une touche (ex. : espace pour tirer)
        if (Input.GetKeyDown(KeyCode.Space) && rocketCount > 0)
        {
            FireRocket();
        }
    }

    // Méthode pour tirer une roquette
    void FireRocket()
    {
        rocketCount--; // Décrémente le nombre de roquettes
        UpdateRocketCounterText(); // Met à jour le texte UI
        Debug.Log("Roquette tirée ! Roquettes restantes : " + rocketCount);

        // Code pour tirer la roquette ici (exemple de log pour l'instant)
        // Exemple : Instantiate(rocketPrefab, transform.position, transform.rotation);
    }

    // Méthode pour mettre à jour le texte UI avec la valeur actuelle du compteur
    public void UpdateCounterText()
    {
        counterText.text = "Counter: " + counter;
    }

    // Met à jour le texte du compteur de roquettes
    public void UpdateRocketCounterText()
    {
        if (rocketCounterText != null)
        {
            rocketCounterText.text = "Rockets: " + rocketCount;
        }
        else
        {
            Debug.LogWarning("rocketCounterText n'est pas assigné dans l'Inspector !");
        }
    }

    // Méthode appelée lorsque le joueur entre en collision avec un autre objet
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision détectée avec: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag(enemyTag))
        {
            Debug.Log("Joueur a touché un ennemi !");
            EndGame();
        }

        if (collision.gameObject.CompareTag(targetTag))
        {
            // Décrémente le compteur
            counter--;

            Debug.Log("Collision avec " + collision.gameObject.name + ". Compteur: " + counter);

            // Ajoute 6 au compteur de roquettes
            rocketCount += 6;
            UpdateRocketCounterText(); // Met à jour l'affichage des roquettes

            // Détruit l'objet après la collision
            Destroy(collision.gameObject);

            // Met à jour l'affichage du compteur
            UpdateCounterText();

            // Vérifie si le compteur est à zéro pour terminer le jeu
            if (counter <= 0)
            {
                EndGame();
            }
        }
    }

    // Méthode alternative si tu utilises un trigger collider
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(enemyTag))
        {
            Debug.Log("Joueur a touché un ennemi !");
            EndGame();
        }

        if (other.gameObject.CompareTag(targetTag))
        {
            counter--;

            Destroy(other.gameObject);

            UpdateCounterText();

            if (counter <= 0)
            {
                Debug.Log("Compteur atteint zéro, appel de EndGame");
                EndGame();
            }
        }
    }

    // Méthode appelée lorsque le jeu doit se terminer
    public void EndGame()
    {
        Debug.Log("EndGame() appelé. Score avant enregistrement: " + counter);

        score = 10 - counter;
        PlayerPrefs.SetInt("FinalScore", score);
        PlayerPrefs.Save();

        Debug.Log("Score enregistré: " + score);

        SceneManager.LoadScene("ResultScene");
    }
}