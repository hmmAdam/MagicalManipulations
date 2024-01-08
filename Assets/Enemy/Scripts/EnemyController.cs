using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 3f;
    public float attackRange = 1.5f;
    public float attackCooldown = 2f;

    private Transform player;
    private bool isAttacking = false;
    private bool isMoving = true;
    private float attackTimer = 0f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (!isAttacking)
        {
            if (isMoving)
            {
                Patrol();
            }

            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= attackRange)
            {
                Attack();
            }
        }
        else
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackCooldown)
            {
                isAttacking = false;
                attackTimer = 0f;
            }
        }
    }

    void Patrol()
    {
        // Implement patrolling behavior (e.g., moving back and forth)
        // Example: Move left and right along the x-axis
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        // Change direction when reaching a certain point (e.g., a boundary)
        if (transform.position.x <= 10)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f); // Flip sprite
            isMoving = true;
        }
        else if (transform.position.x >= 10)
        {
            transform.localScale = new Vector3(1f, 1f, 1f); // Flip sprite
            isMoving = false;
        }
    }

    void Attack()
    {
        // Implement attack behavior (e.g., damaging the player)
        // Example: Deal damage to the player
        Debug.Log("Enemy attacking!");

        // Add code to damage the player
        player.GetComponent<PlayerHealth>().TakeDamage(15);

        isAttacking = true;
    }
}
