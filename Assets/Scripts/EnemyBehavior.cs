using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float health;
    [SerializeField] private float damage;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float walkingSpeed;
    [SerializeField] private GameObject trump;


    private NavMeshAgent navMeshAgent;
    private float timeSinceLastAttack;


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, trump.transform.position) < 20)
        {
            navMeshAgent.destination = trump.transform.position;
            if(Vector3.Distance(transform.position, trump.transform.position) < 1)
            {
                Attack();
            }
        }
        timeSinceLastAttack += Time.deltaTime;
    }
    private void Attack()
    {
        if (timeSinceLastAttack > attackCooldown)
        {
            trump.GetComponent<PlayerBehavior>().ApplyDamage(damage);
            timeSinceLastAttack = 0f;
        }
    }
}
