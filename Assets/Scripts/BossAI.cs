using UnityEngine;

public class BossAI : MonoBehaviour
{
    [SerializeField]
    private int BossHealth = 100;
    [SerializeField]
    private Rigidbody bossRB;
    [SerializeField]
    private Transform playerPosition;
    [SerializeField]
    private int bossTriggerRange = 10;
    int randomVal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bossRB = GetComponent<Rigidbody>();
        bossRB.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(playerPosition.position, transform.position);
        if (distance < bossTriggerRange)
        {
            Attack();
        }
        
    }

    void Attack()
    {
        randomVal = Random.Range(0, BossHealth);
        if (randomVal < BossHealth / 2)
        {
            ShootingAttack();
        }
        else
        {
            ScreamingAttack();
        }
    }

    void ShootingAttack()
    {
        Debug.Log("Shooting Attack");
    }

    void ScreamingAttack()
    {
        Debug.Log("Screaming Attack");
    }
}
