using UnityEngine;
using UnityEngine.SceneManagement;

public class VRMenu : MonoBehaviour
{
    // M�thode pour d�marrer la sc�ne "DemoScene"
    public void StartGame()
    {
        SceneManager.LoadScene("DemoScene");
    }

    // M�thode pour quitter l'application
    public void QuitGame()
    {
        #if UNITY_EDITOR
                Debug.Log("Quitter le jeu");
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                // En mode build, cela quittera l'application
                Application.Quit();
        #endif
    }
}
