using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class DebugController : MonoBehaviour
{
    private XRBaseController controller;

    void Start()
    {
        // Essayez de r�cup�rer le composant XR Controller
        if (TryGetComponent<XRBaseController>(out controller))
        {
            Debug.Log("Le bon type de contr�leur est attach� : " + controller.GetType().ToString());
        }
        else
        {
            Debug.LogWarning("Type de contr�leur incorrect ou composant manquant !");
        }
    }
}
