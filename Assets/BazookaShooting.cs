using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class BazookaShooting : MonoBehaviour
{
    public GameObject rocketPrefab;   // La rocket à tirer
    public Transform barrelEnd;       // Point de départ de la rocket
    public float fireForce = 2000f;   // Force de propulsion
    public XRBaseController rightHandController; // Référence au contrôleur droit

    public InputActionProperty rotationAction; // Référence à l'action de rotation (joystick droit)
    public InputActionProperty fireAction;     // Référence à l'action de tir (bouton A)

    private bool canFire = true;               // Flag pour le cooldown
    public float fireCooldown = 1f;            // Délai entre les tirs

    // Vitesse de rotation du bazooka
    public float rotationSpeed = 100f;

    void Update()
    {
        // Suivre la rotation du joystick droit pour tourner le bazooka sur l'axe Y
        Vector2 rotationInput = rotationAction.action.ReadValue<Vector2>();

        // Calculer la rotation sur l'axe Y uniquement en fonction de l'entrée du joystick
        float rotationAngle = rotationInput.x * Time.deltaTime * rotationSpeed;
        transform.Rotate(0, rotationAngle, 0);

        // Rotation avec les touches Q (gauche) et E (droite) pour le test clavier sur l'axe Y
        if (Keyboard.current.qKey.isPressed)
        {
            transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime); // Rotation vers la gauche sur l'axe Y
        }
        else if (Keyboard.current.eKey.isPressed)
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime); // Rotation vers la droite sur l'axe Y
        }

        // Vérifier si le bouton A est appuyé pour tirer, ou si la barre d'espace est pressée pour le test clavier
        if (fireAction.action.WasPressedThisFrame() && canFire || Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            FireRocket();
            StartCoroutine(FireCooldown());
        }
    }
    void FireRocket()
    {
        GameObject rocket = Instantiate(rocketPrefab, barrelEnd.position, barrelEnd.rotation);
        rocket.tag = "Rocket";  // Assigne le tag "Rocket" à la rocket
        Rigidbody rb = rocket.GetComponent<Rigidbody>();
        rb.AddForce(barrelEnd.forward * fireForce);
        Destroy(rocket, 10f); // Détruit la rocket après 5 secondes pour économiser les ressources
    }


    private System.Collections.IEnumerator FireCooldown()
    {
        canFire = false;
        yield return new WaitForSeconds(fireCooldown);  // Attendre avant de pouvoir tirer à nouveau
        canFire = true;
    }
}