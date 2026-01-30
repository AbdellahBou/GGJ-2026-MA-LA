using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private Vector3 offset = new Vector3(0, 5, -10);
 
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = playerTransform.position +  offset;
    }
}
