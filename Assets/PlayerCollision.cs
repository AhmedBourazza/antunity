using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;  // Pour gérer les scènes

public class PlayerCollision : MonoBehaviour
{
    // Compteur qui sera décrémenté
    public int counter = 10;

    // Tag de l'objet avec lequel le joueur doit entrer en collision
    public string targetTag = "SpecificObject";

    // Référence au texte UI (Text ou TextMeshPro)
    public TextMeshProUGUI counterText;  // Utiliser TextMeshPro (sinon remplacer par 'Text' si tu utilises l'UI de base)

    // Score du joueur (basé sur le compteur restant)
    public int score;

    void Start()
    {
        // Initialise le texte avec la valeur actuelle du compteur
        UpdateCounterText();
    }

    // Méthode appelée lorsque le joueur entre en collision avec un autre objet
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            // Décrémente le compteur
            counter--;

            Debug.Log("Collision avec " + collision.gameObject.name + ". Compteur: " + counter); // Vérifie la valeur du compteur

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
        if (other.gameObject.CompareTag(targetTag))
        {
            // Décrémente le compteur
            counter--;

            // Détruit l'objet après avoir déclenché la collision
            Destroy(other.gameObject);

            // Met à jour l'affichage du compteur
            UpdateCounterText();

            // Vérifie si le compteur est à zéro pour terminer le jeu
            if (counter <= 0)
            {
                Debug.Log("Compteur atteint zéro, appel de EndGame");
                EndGame();
            }

        }
    }

    // Méthode pour mettre à jour le texte UI avec la valeur actuelle du compteur
    public void UpdateCounterText()
    {
        counterText.text = "Counter: " + counter;
    }

    // Méthode appelée lorsque le jeu doit se terminer

    public void EndGame()
    {
        // Ajoute un message pour vérifier que cette méthode est bien appelée
        Debug.Log("EndGame() appelé. Score avant enregistrement: " + counter);

        // Stocke le score
        score = 10 - counter; 
        PlayerPrefs.SetInt("FinalScore", score);
        PlayerPrefs.Save(); // Assurez-vous que les données sont enregistrées

        Debug.Log("Score enregistré: " + score); // Pour vérifier que le score est bien enregistré

        // Charge la scène des résultats
        SceneManager.LoadScene("ResultScene");
    }



}
