using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;
    private float lookPlayerRange = 14f;
    private float attackRange = 3f;
    private float attackSpeed = 1.5f;
    private float attackTimer;
    private bool isAttacking;

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
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }

        if (target == null) return;

        float distanceToTarget = Vector2.Distance(transform.position, target.position);

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

        if (distanceToTarget <= attackRange)
        {
            if (attackTimer <= 0 && !isAttacking)
            {
                isAttacking = true;
                animator.SetTrigger("EnemyAttack");
            }
        }
    }

    public void EnemyAttack()
    {
        PlayerHP playerHP = target.GetComponent<PlayerHP>();
        playerHP.TakeDamage(1);
        Debug.Log("Enemy Attack");
        animator.SetTrigger("EnemyIdle");
        attackTimer = attackSpeed;
        isAttacking = false;
    }

    private void OnDrawGizmos() // เส้นเอาไว้ดูระยะ
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookPlayerRange);
    }
}
