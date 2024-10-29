using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;  // Pour gérer les scènes

public class ResultScreen : MonoBehaviour
{
    // Références aux objets UI pour afficher le score et le statut de réussite
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI resultText;
    public PlayerCollision playerCollision;
    void Start()
    {
        // Récupère le score enregistré
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        Debug.Log("Score récupéré: " + finalScore); // Ajoute un log pour vérifier la valeur récupérée

        // Affiche le score
        scoreText.text = "Score: " + finalScore;

        // Détermine si le joueur a réussi ou non
        if (finalScore == 10)
        {
            resultText.text = "You Win!";
        }
        else
        {
            resultText.text = "Game Over!";
        }
    }





    // Méthode pour quitter le jeu (bouton Quitter)
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
