using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody playerRB;
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float rotationAngel = 5f;
    [SerializeField]
    private float jumpForce = 25f;
    [SerializeField]
    private Animator myAnimator;
    [SerializeField]
    private Transform cameraHolder;
    private CharacterController controller;

    public float mouseSensitivity;
    private float xRotation = 0f;
    private InputAction moveAction;
    private InputAction jumpAction;
    public InputActionAsset actions;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        myAnimator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        // Find the "Move" action within the "Player" action map
        moveAction = actions.FindActionMap("Movement").FindAction("Move");
        jumpAction = actions.FindActionMap("Movement").FindAction("Jump");
        // Actions must be enabled to work
        moveAction.Enable();
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Item")
        {
            Debug.Log("Entred");
            Destroy(collider.gameObject);
        }
    }
    void OnEnable()
    {
        if (moveAction != null) moveAction.Enable();
    }

    void OnDisable()
    {
        if (moveAction != null) moveAction.Disable();
    }

    // Update is called once per frame
    void FixedUpdate() // Use FixedUpdate for physics-based movement
    {
        Vector2 moveDirection = moveAction.ReadValue<Vector2>();
        myAnimator.SetFloat("XAxe",  moveDirection.x);
        myAnimator.SetFloat("YAxe",  moveDirection.y);
        float jump = jumpAction.ReadValue<float>();
        HandleMouseLook(); HandleMovement();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRB.AddForce(Vector3.up * jumpForce);
        }
        
        //Debug.Log($"Move Direction: {moveDirection}");
        Vector3 movement = new Vector3(moveDirection.x, 0.0f, moveDirection.y);
        playerRB.AddForce(movement * moveSpeed);
    }
    void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * moveSpeed * Time.deltaTime);
    }
    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cameraHolder.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
