using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;
    private float lookPlayerRange = 14f;
    private float attackRange = 5f;
    private float attackSpeed = 1.5f;
    private float attackTimer;

    [Header("Animation")]
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null) 
        { 
            target = player.transform; 
        }
    }

    private void Update()
    {
        if (target == null) return;

        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }

        float distanceToTarget = Vector2.Distance(transform.position, target.position);

        if (distanceToTarget <= attackRange)
        {
            if (attackTimer <= 0)
            {
                animator.SetTrigger("EnemyAttack"); // still bug
                attackTimer = attackSpeed;
            }
        }
        else
        {
            animator.SetTrigger("EnemyIdle");
        }

        if (distanceToTarget <= lookPlayerRange)
        {
            if (target.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (target.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }

    public void EnemyAttack()
    {
        Debug.Log("Enemy Attack");
    }

    private void OnDrawGizmos() // เส้นเอาไว้ดูระยะ
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookPlayerRange);
    }
}
