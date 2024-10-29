using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class BazookaShooting : MonoBehaviour
{
    public GameObject rocketPrefab;   // The rocket to shoot
    public Transform barrelEnd;       // Where the rocket will be spawned
    public float fireForce = 2000f;   // The force of the shot
    public XRController rightHandController; // Reference to the right hand controller

    private bool canFire = true;       // Flag to control firing
    public float fireCooldown = 1f;    // Cooldown duration in seconds

    void Update()
    {
        // Check if the trigger button is pressed on the right hand and if we can fire
        if (rightHandController.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool isPressed) && isPressed && canFire)
        {
            FireRocket();
            StartCoroutine(FireCooldown());
        }
    }

    void FireRocket()
    {
        // Instantiate the rocket at the bazooka's barrel end
        GameObject rocket = Instantiate(rocketPrefab, barrelEnd.position, barrelEnd.rotation);
        Rigidbody rb = rocket.GetComponent<Rigidbody>();

        // Apply a forward force to the rocket
        rb.AddForce(barrelEnd.forward * fireForce);
    }

    private System.Collections.IEnumerator FireCooldown()
    {
        canFire = false;  // Set firing to false
        yield return new WaitForSeconds(fireCooldown);  // Wait for the cooldown period
        canFire = true;   // Set firing back to true
    }
}
