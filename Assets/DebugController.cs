using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class DebugController : MonoBehaviour
{
    private XRBaseController controller;

    void Start()
    {
        // Essayez de récupérer le composant XR Controller
        if (TryGetComponent<XRBaseController>(out controller))
        {
            Debug.Log("Le bon type de contrôleur est attaché : " + controller.GetType().ToString());
        }
        else
        {
            Debug.LogWarning("Type de contrôleur incorrect ou composant manquant !");
        }
    }
}
