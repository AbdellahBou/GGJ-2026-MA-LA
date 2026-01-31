using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] Transform playerPosition; 
    void Update()
    {
        transform.LookAt(playerPosition.position);
    }
}
