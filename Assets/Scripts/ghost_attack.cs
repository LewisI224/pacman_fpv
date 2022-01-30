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

    public float walkSpeed = 0.5f;
    public float attackSpeed = 4f;

    public float chaseDistance = 7f;
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
        if (patrolTimer > patrolTime)
        {
            setNewDest();
            patrolTimer = 0f;

        }
    }

    void attack()
    {

    }

    void chase()
    {

    }

    void setNewDest()
    {
        float randRadius = Random.Range(patrolRadiusMin, patrolRadiusMax);
        Vector3 randDir = Random.insideUnitSphere * randRadius;
        randDir += transform.position;

        NavMeshHit navHit;
        NavMesh.SamplePosition(randDir, out navHit, randRadius, -1);
        navAgent.SetDestination(navHit.position);

    }
}
