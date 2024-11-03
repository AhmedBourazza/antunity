using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    // Compteur qui sera d�cr�ment�
    public int counter = 10;

    // Tag de l'objet avec lequel le joueur doit entrer en collision
    public string targetTag = "SpecificObject"; // Changez ici pour qu'il corresponde au tag de vos bananes

    // Tag pour les ennemis
    public string enemyTag = "Enemy"; // Assurez-vous que vos ennemis ont ce tag

    // R�f�rence au texte UI (Text ou TextMeshPro)
    public TextMeshProUGUI counterText;  // Utiliser TextMeshPro (sinon remplacer par 'Text' si tu utilises l'UI de base)

    // Compteur pour les roquettes restantes
    public int rocketCount = 10; // Nombre initial de roquettes

    // R�f�rence au texte UI pour afficher le nombre de roquettes
    public TextMeshProUGUI rocketCounterText;


    // Score du joueur (bas� sur le compteur restant)
    public int score;

    void Start()
    {
        // Initialise le texte avec la valeur actuelle du compteur
        UpdateCounterText();
        UpdateRocketCounterText(); // Met � jour le texte des roquettes
    }

    void Update()
    {
        // Ex�cuter le tir en appuyant sur une touche (ex. : espace pour tirer)
        if (Input.GetKeyDown(KeyCode.Space) && rocketCount > 0)
        {
            FireRocket();
        }
    }

    // M�thode pour tirer une roquette
    void FireRocket()
    {
        rocketCount--; // D�cr�mente le nombre de roquettes
        UpdateRocketCounterText(); // Met � jour le texte UI
        Debug.Log("Roquette tir�e ! Roquettes restantes : " + rocketCount);

        // Code pour tirer la roquette ici (exemple de log pour l'instant)
        // Exemple : Instantiate(rocketPrefab, transform.position, transform.rotation);
    }

    // M�thode pour mettre � jour le texte UI avec la valeur actuelle du compteur
    public void UpdateCounterText()
    {
        counterText.text = "Counter: " + counter;
    }

    // Met � jour le texte du compteur de roquettes
    public void UpdateRocketCounterText()
    {
        if (rocketCounterText != null)
        {
            rocketCounterText.text = "Rockets: " + rocketCount;
        }
        else
        {
            Debug.LogWarning("rocketCounterText n'est pas assign� dans l'Inspector !");
        }
    }

    // M�thode appel�e lorsque le joueur entre en collision avec un autre objet
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision d�tect�e avec: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag(enemyTag))
        {
            Debug.Log("Joueur a touch� un ennemi !");
            EndGame();
        }

        if (collision.gameObject.CompareTag(targetTag))
        {
            // D�cr�mente le compteur
            counter--;

            Debug.Log("Collision avec " + collision.gameObject.name + ". Compteur: " + counter);

            // Ajoute 6 au compteur de roquettes
            rocketCount += 6;
            UpdateRocketCounterText(); // Met � jour l'affichage des roquettes

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
        if (other.gameObject.CompareTag(enemyTag))
        {
            Debug.Log("Joueur a touch� un ennemi !");
            EndGame();
        }

        if (other.gameObject.CompareTag(targetTag))
        {
            counter--;

            Destroy(other.gameObject);

            UpdateCounterText();

            if (counter <= 0)
            {
                Debug.Log("Compteur atteint z�ro, appel de EndGame");
                EndGame();
            }
        }
    }

    // M�thode appel�e lorsque le jeu doit se terminer
    public void EndGame()
    {
        Debug.Log("EndGame() appel�. Score avant enregistrement: " + counter);

        score = 10 - counter;
        PlayerPrefs.SetInt("FinalScore", score);
        PlayerPrefs.Save();

        Debug.Log("Score enregistr�: " + score);

        SceneManager.LoadScene("ResultScene");
    }
}