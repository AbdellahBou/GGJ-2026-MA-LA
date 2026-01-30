using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody playerRB;
    [SerializeField]
    private float moveSpeed = 5f;
    private InputAction moveAction;
    public InputActionAsset actions;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        
        // Find the "Move" action within the "Player" action map
        moveAction = actions.FindActionMap("Movement").FindAction("Move");

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
        //Debug.Log($"Move Direction: {moveDirection}");
        Vector3 movement = new Vector3(moveDirection.x, 0.0f, moveDirection.y);
        playerRB.AddForce(movement * moveSpeed);
    }
}
