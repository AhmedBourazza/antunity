using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;  // Pour g�rer les sc�nes

public class ResultScreen : MonoBehaviour
{
    // R�f�rences aux objets UI pour afficher le score et le statut de r�ussite
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI resultText;
    public PlayerCollision playerCollision;
    void Start()
    {
        // R�cup�re le score enregistr�
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        Debug.Log("Score r�cup�r�: " + finalScore); // Ajoute un log pour v�rifier la valeur r�cup�r�e

        // Affiche le score
        scoreText.text = "Score: " + finalScore;

        // D�termine si le joueur a r�ussi ou non
        if (finalScore == 10)
        {
            resultText.text = "You Win!";
        }
        else
        {
            resultText.text = "Game Over!";
        }
    }





    // M�thode pour quitter le jeu (bouton Quitter)
    public void QuitGame()
    {if (playerCollision != null)
        {
        }
            #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
            #else
                    Application.Quit();
            #endif
    }

 
 
}
