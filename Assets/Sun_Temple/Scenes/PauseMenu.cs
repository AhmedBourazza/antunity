
using UnityEngine;
using UnityEngine.UI; // Pour utiliser les boutons et UI
using UnityEngine.SceneManagement; // Pour g�rer les sc�nes
public class PauseMenu : MonoBehaviour
{
    public PlayerCollision playerCollision; // R�f�rence au script PlayerCollision

    public GameObject pauseMenu; // Panneau de menu de pause
    private bool isPaused = false;

    void Start()
    {
        // Assurez-vous que le menu de pause est d�sactiv� au d�part
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        // V�rifie si le joueur appuie sur la touche "�chap" pour activer/d�sactiver le menu de pause
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
        Debug.Log("Resume called"); // Pour v�rifier si cette m�thode est appel�e
        pauseMenu.SetActive(false); // Cache le menu de pause
        Time.timeScale = 1; // Reprend le temps du jeu
        isPaused = false; // Met � jour l'�tat de pause
    }

    public void Pause()
    {
        Debug.Log("Pause called"); // Pour v�rifier si cette m�thode est appel�e
        pauseMenu.SetActive(true); // Affiche le menu de pause
        Time.timeScale = 0; // Met le temps du jeu en pause
        isPaused = true; // Met � jour l'�tat de pause
    }

    public void QuitGame()
    {
        Debug.Log("QuitGame() appel�."); // Pour v�rifier que QuitGame est bien ex�cut�

        if (playerCollision != null) // V�rifie que la r�f�rence est bien assign�e
        {
            playerCollision.EndGame(); // Appelle la m�thode EndGame du script PlayerCollision
        }
        else
        {
            Debug.LogError("R�f�rence � PlayerCollision manquante !");
        }
    }
}
