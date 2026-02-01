using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Rigidbody projectile;
    public GameObject shootVFX;
    // Adjust shooting force/speed in the Inspector
    public float force = 10f;
    // Assign the empty GameObject at the barrel end as the spawn point
    public Transform barrelEnd;

    void Update()
    {
        // Check for left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate the projectile at the barrel end's position and rotation
        Rigidbody clone;
        clone = Instantiate(projectile, barrelEnd.position, barrelEnd.rotation);
        GameObject shooting = Instantiate(shootVFX, barrelEnd.position, barrelEnd.rotation);
        // Give the cloned object an initial velocity in its forward direction
        clone.linearVelocity = barrelEnd.TransformDirection(Vector3.forward * force);

        // Optional: Destroy the bullet after 2 seconds to prevent scene clutter
        Destroy(clone.gameObject, 2);
        Destroy(shooting, 1);
    }
}
