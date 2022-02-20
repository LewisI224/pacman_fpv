using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    PATROL, CHASE, ATTACK
}
public class ghost_attack : MonoBehaviour
{
    private NavMeshAgent navAgent;
    private EnemyState enemyState;

    public float walkSpeed = 1f;
    public float attackSpeed = 4f;

    public float chaseDistance = 10f;
    private float currentChaseDistance;
    public float attackDistance = 1.8f;
    public float chaseAfterAttackDistance = 2f;

    public float patrolRadiusMin = 20f;
    public float patrolRadiusMax = 60f;
    public float patrolTime = 15f;
    public float patrolTimer;

    public float attackTimer;
    public float waitBeforeAttack;

    private Transform target;

    void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();

        target = GameObject.FindWithTag("Player").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyState = EnemyState.PATROL;
        patrolTimer = patrolTime;
        attackTimer = waitBeforeAttack;
        currentChaseDistance = chaseDistance;


    }

    // Update is called once per frame
    void Update()
    {   
        if(enemyState == EnemyState.PATROL)
        {
            patrol();
        }

        if (enemyState == EnemyState.ATTACK)
        {
            attack();
        }
        if (enemyState == EnemyState.CHASE)
        {
            chase();
        }
    }

    void patrol()
    {
        navAgent.isStopped = false;
        navAgent.speed = walkSpeed;
        patrolTimer += Time.deltaTime;
        //if weve been moving for a while
        if (patrolTimer > patrolTime)
        {
            //find a new destination
            setNewDest();
            //reset patrol timer
            patrolTimer = 0f;

        }
        //is the player close?
        if(Vector3.Distance(transform.position, target.position) <= chaseDistance)
        {
            enemyState = EnemyState.CHASE;
        }

        

    }

    void attack()
    {
        //stop the enemy moving
        navAgent.velocity = Vector3.zero;
        navAgent.isStopped = true;
        //wait
        attackTimer += Time.deltaTime;
        if(attackTimer > waitBeforeAttack)
        {   
            //munch the player
            attackTimer = 0f;
        }
        //has the player managed to run away?
        if(Vector3.Distance(transform.position, target.position) > (attackDistance + chaseAfterAttackDistance))
        {
            //chase again
            enemyState=EnemyState.CHASE;
        }
    }

    void chase()
    {   
        //chase player
        navAgent.isStopped = false;
        navAgent.speed = attackSpeed;
        //set dest as player position
        navAgent.SetDestination(target.position);

        //is the player really close?
        if (Vector3.Distance(transform.position, target.position) <= attackDistance)
        {
            enemyState = EnemyState.ATTACK;
            //reset chase distance
            if (chaseDistance != currentChaseDistance)
            {
                chaseDistance = currentChaseDistance;
            }
        } else if (Vector3.Distance(transform.position, target.position) > chaseDistance)
        {
            //player has ran away from ghost
            enemyState = EnemyState.PATROL;
            //reset patrol timer so new dest is calculated immediately
            patrolTimer = 20f;
            if (chaseDistance != currentChaseDistance)
            {
                chaseDistance = currentChaseDistance;
            }
        }

    }

    void setNewDest()
    {   
        //get a random radius between min and max
        float randRadius = Random.Range(patrolRadiusMin, patrolRadiusMax);
        //get a random direction
        Vector3 randDir = Random.insideUnitSphere * randRadius;
        randDir += transform.position;

        NavMeshHit navHit;
        //find navigable area
        NavMesh.SamplePosition(randDir, out navHit, randRadius, -1);
        navAgent.SetDestination(navHit.position);

    }
}
