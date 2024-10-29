
using UnityEngine;
using UnityEngine.UI; // Pour utiliser les boutons et UI
using UnityEngine.SceneManagement; // Pour gérer les scènes
public class PauseMenu : MonoBehaviour
{
    public PlayerCollision playerCollision; // Référence au script PlayerCollision

    public GameObject pauseMenu; // Panneau de menu de pause
    private bool isPaused = false;

    void Start()
    {
        // Assurez-vous que le menu de pause est désactivé au départ
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        // Vérifie si le joueur appuie sur la touche "Échap" pour activer/désactiver le menu de pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        Debug.Log("Resume called"); // Pour vérifier si cette méthode est appelée
        pauseMenu.SetActive(false); // Cache le menu de pause
        Time.timeScale = 1; // Reprend le temps du jeu
        isPaused = false; // Met à jour l'état de pause
    }

    public void Pause()
    {
        Debug.Log("Pause called"); // Pour vérifier si cette méthode est appelée
        pauseMenu.SetActive(true); // Affiche le menu de pause
        Time.timeScale = 0; // Met le temps du jeu en pause
        isPaused = true; // Met à jour l'état de pause
    }

    public void QuitGame()
    {
        Debug.Log("QuitGame() appelé."); // Pour vérifier que QuitGame est bien exécuté

        if (playerCollision != null) // Vérifie que la référence est bien assignée
        {
            playerCollision.EndGame(); // Appelle la méthode EndGame du script PlayerCollision
        }
        else
        {
            Debug.LogError("Référence à PlayerCollision manquante !");
        }
    }
}
