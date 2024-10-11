using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerController : MonoBehaviour
{
    // Variables pour stocker les inputs des manettes
    private Vector2 leftJoystickInput;
    private Vector2 rightJoystickInput;

    // Références des contrôleurs
    public InputActionProperty leftControllerMove;
    public InputActionProperty rightControllerTurn;
    public InputActionProperty shootAction;

    // Variables pour le tir
    public GameObject bulletPrefab; // Le prefab de la balle
    public Transform barrelEnd; // Position d'où la balle sera tirée
    public float shootingForce = 1000f; // Force de propulsion

    // Référence à l'arme (pour vérifier si elle est grab)
    public XRGrabInteractable grabInteractable; // Référence à XR Grab Interactable

    // Vitesse de déplacement et de rotation
    public float moveSpeed = 5f;
    public float turnSpeed = 200f;

    void Update()
    {
        // Récupérer les inputs des joysticks
        leftJoystickInput = leftControllerMove.action.ReadValue<Vector2>();
        rightJoystickInput = rightControllerTurn.action.ReadValue<Vector2>();

        // Déplacer l'objet en fonction des inputs du joystick gauche
        Vector3 moveDirection = new Vector3(leftJoystickInput.x, 0, leftJoystickInput.y);

        // Utiliser transform.forward pour déplacer l'objet dans la direction qu'il fait face
        Vector3 forwardMovement = transform.forward * leftJoystickInput.y + transform.right * leftJoystickInput.x;

        transform.position += forwardMovement.normalized * moveSpeed * Time.deltaTime;

        // Tourner l'objet en fonction des inputs du joystick droit
        float rotationY = rightJoystickInput.x * turnSpeed * Time.deltaTime;

        // Appliquer la rotation autour de l'axe Y seulement
        transform.Rotate(0, rotationY, 0);

        if (shootAction.action.triggered)
        {
            Shoot();
        }

    }

    void Shoot()
    {
        // Vérifiez si l'arme est saisie avant de tirer
        if (grabInteractable.isSelected) // Vérifie si l'arme est en cours de saisie
        {
            // Crée une balle
            GameObject bullet = Instantiate(bulletPrefab, barrelEnd.position, barrelEnd.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Dirige la balle dans la direction de l'objet barrelEnd (le long de Z)
                rb.AddForce(barrelEnd.forward * shootingForce); // Applique la force dans la direction Z
            }
        }
    }
}
