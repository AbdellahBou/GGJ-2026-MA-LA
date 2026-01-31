using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f; // Adjust in the Inspector
    public Transform playerBody; // Assign your Player GameObject here if the script is on the camera
    public float maxRange = 100f;
    public float minRange = -100f;
    private float _xRotation = 0f;

    void Start()
    {
        // Lock the cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get mouse input axes
        float mouseX = Input.GetAxis("Mouse X") ;
        float mouseY = Input.GetAxis("Mouse Y");
        mouseX = Mathf.Clamp(mouseX,minRange, maxRange) * mouseSensitivity * Time.deltaTime;
        mouseY = Mathf.Clamp(mouseY,minRange, maxRange) * mouseSensitivity * Time.deltaTime;
        // Vertical rotation (Pitch)
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(-90f, _xRotation, 90f); // Clamp rotation to prevent flipping upside down

        // Apply vertical rotation to the camera (or the object this script is attached to)
        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);

        // Horizontal rotation (Yaw) - only if a player body is assigned
        if (playerBody != null)
        {
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}