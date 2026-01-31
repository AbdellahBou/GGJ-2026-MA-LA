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


    private InputAction moveAction;
    private InputAction jumpAction;
    public InputActionAsset actions;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        
        // Find the "Move" action within the "Player" action map
        moveAction = actions.FindActionMap("Movement").FindAction("Move");
        jumpAction = actions.FindActionMap("Movement").FindAction("Jump");
        // Actions must be enabled to work
        moveAction.Enable();
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
        float jump = jumpAction.ReadValue<float>();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRB.AddForce(Vector3.up * jumpForce);
        }
        if(moveDirection.x < 0)
        {
            //transform.Rotate(Vector3.up * rotationAngel * rotationSpeed);
        }
        else
        {
            //transform.Rotate(Vector3.up * -rotationAngel * rotationSpeed);
        }
       Debug.Log($"Move Direction: {moveDirection}");
        Vector3 movement = new Vector3(moveDirection.x, 0.0f, moveDirection.y);
        playerRB.AddForce(movement * moveSpeed);
    }
}
