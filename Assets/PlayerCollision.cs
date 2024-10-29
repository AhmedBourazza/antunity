using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;  // Pour g�rer les sc�nes

public class PlayerCollision : MonoBehaviour
{
    // Compteur qui sera d�cr�ment�
    public int counter = 10;

    // Tag de l'objet avec lequel le joueur doit entrer en collision
    public string targetTag = "SpecificObject";

    // R�f�rence au texte UI (Text ou TextMeshPro)
    public TextMeshProUGUI counterText;  // Utiliser TextMeshPro (sinon remplacer par 'Text' si tu utilises l'UI de base)

    // Score du joueur (bas� sur le compteur restant)
    public int score;

    void Start()
    {
        // Initialise le texte avec la valeur actuelle du compteur
        UpdateCounterText();
    }

    // M�thode appel�e lorsque le joueur entre en collision avec un autre objet
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            // D�cr�mente le compteur
            counter--;

            Debug.Log("Collision avec " + collision.gameObject.name + ". Compteur: " + counter); // V�rifie la valeur du compteur

            // D�truit l'objet apr�s la collision
            Destroy(collision.gameObject);

            // Met � jour l'affichage du compteur
            UpdateCounterText();

            // V�rifie si le compteur est � z�ro pour terminer le jeu
            if (counter <= 0)
            {
                EndGame();
            }
        }
    }


    // M�thode alternative si tu utilises un trigger collider
   public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            // D�cr�mente le compteur
            counter--;

            // D�truit l'objet apr�s avoir d�clench� la collision
            Destroy(other.gameObject);

            // Met � jour l'affichage du compteur
            UpdateCounterText();

            // V�rifie si le compteur est � z�ro pour terminer le jeu
            if (counter <= 0)
            {
                Debug.Log("Compteur atteint z�ro, appel de EndGame");
                EndGame();
            }

        }
    }

    // M�thode pour mettre � jour le texte UI avec la valeur actuelle du compteur
    public void UpdateCounterText()
    {
        counterText.text = "Counter: " + counter;
    }

    // M�thode appel�e lorsque le jeu doit se terminer

    public void EndGame()
    {
        // Ajoute un message pour v�rifier que cette m�thode est bien appel�e
        Debug.Log("EndGame() appel�. Score avant enregistrement: " + counter);

        // Stocke le score
        score = 10 - counter; 
        PlayerPrefs.SetInt("FinalScore", score);
        PlayerPrefs.Save(); // Assurez-vous que les donn�es sont enregistr�es

        Debug.Log("Score enregistr�: " + score); // Pour v�rifier que le score est bien enregistr�

        // Charge la sc�ne des r�sultats
        SceneManager.LoadScene("ResultScene");
    }



}
