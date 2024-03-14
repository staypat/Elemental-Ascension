using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class GolemAI : MonoBehaviour
{
    // Start is called before the first frame update
    //Script written from tutorial: https://www.youtube.com/watch?v=UjkSFoLxesw
    public NavMeshAgent agent;
    public Transform player;
    public Animator animator;
    public LayerMask GroundLayer;
    public LayerMask PlayerLayer;

    // values for offset of attack from origin
    public int attack_x;
    public int attack_y;
    public int attack_z;

    public float health;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange;
    public float attackRange;
    public bool playerInSightRange;
    public bool playerInAttackRange;

    //Kiting
    public float kiteDist;

    //sfx
    public AudioClip[] attacks;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, PlayerLayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, PlayerLayer);
        if (!playerInSightRange && !playerInAttackRange)
        {
            animator.SetBool("IsWalking", true);
            // animator.SetBool("IsAttacking", false);
            Patroling();
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
        if (playerInSightRange && !playerInAttackRange)
        {
            animator.SetBool("IsWalking", true);
            // animator.SetBool("IsAttacking", false);
            ChasePlayer();
        }
        if (playerInSightRange && playerInAttackRange)
        {
            animator.SetBool("IsWalking", false);
            AttackPlayer();
        }
        if (playerInSightRange && Vector3.Distance(transform.position, player.position) < kiteDist)
        {
            animator.SetBool("IsWalking", true);
            // animator.SetBool("IsAttacking", false);
            KitePlayer();
        }
    }
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void Patroling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }
        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if(Physics.Raycast(walkPoint, -transform.up, 2f, GroundLayer))
        {
            walkPointSet = true;
        }
    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        // Calculate the direction to the player
        Vector3 directionToPlayer = (player.position - transform.position).normalized;

        // Calculate the rotation to look towards the player's position, but only on the x and y axes
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(directionToPlayer.x, 0f, directionToPlayer.z), Vector3.up);

        // Apply the rotation to the enemy
        transform.rotation = targetRotation;

        // transform.LookAt(player);
        if (!alreadyAttacked)
        {
            StartCoroutine(AttackCoroutine());
            //animator.SetBool("IsAttacking", true);
            //animator.SetTrigger("Attack");

            ////insert attack type here (shooting, sword, etc)

            //// Calculate the spawn position based on the offset values
            //Vector3 projectileSpawnPosition = transform.position + attack_x * transform.right + attack_y * transform.up + attack_z * transform.forward;

            //// Calculate the direction towards the player from the adjusted spawn position
            //Vector3 directionToPlayerAdjusted = (player.position - projectileSpawnPosition).normalized;

            //Rigidbody rb = Instantiate(projectile, projectileSpawnPosition, Quaternion.identity).GetComponent<Rigidbody>();
            //rb.velocity = directionToPlayerAdjusted * 32f;

            //// Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            //// rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            //// rb.AddForce(transform.up * 6f, ForceMode.Impulse);
            ////
            alreadyAttacked = true;
            ////animator.SetTrigger("Attack");
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private IEnumerator AttackCoroutine()
    {
        animator.SetBool("IsAttacking", true);
        animator.SetTrigger("Attack");

        // Play sfx based on name
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(attacks[0]);

        yield return new WaitForSeconds(1f);

        // Insert attack logic here (e.g., spawning projectiles)

        // Calculate the spawn position based on the offset values
        Vector3 projectileSpawnPosition = transform.position + attack_x * transform.right + attack_y * transform.up + attack_z * transform.forward;

        // Calculate the direction towards the player from the adjusted spawn position
        Vector3 directionToPlayerAdjusted = (player.position - projectileSpawnPosition).normalized;

        // Spawn and shoot the projectile
        Rigidbody rb = Instantiate(projectile, projectileSpawnPosition, Quaternion.identity).GetComponent<Rigidbody>();
        rb.velocity = directionToPlayerAdjusted * 32f;

        // Reset attack animation
        animator.SetBool("IsAttacking", false);
    }
    private void KitePlayer()
    {
        Vector3 kitePoint = transform.position - (player.position - transform.position).normalized * kiteDist;
        agent.SetDestination(kitePoint);
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Invoke(nameof(DestroyEnemy), 0.5f);
        }
    }
    public void DestroyEnemy()
    {
        this.gameObject.SetActive(false);
        GameManager.Instance.EnemyKilled();
    }

    //Visualizing attack and sight range
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
