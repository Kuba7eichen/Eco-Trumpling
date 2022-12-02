using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private float _attackCooldown;
    [SerializeField] private float _walkingSpeed;
    [SerializeField] private GameObject _trump;


    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    private float _timeSinceLastAttack;
    private bool _dead = false;


    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_health<=0)
        {
            _dead = true;
            _animator.SetTrigger("isDead");
        }
        if (!_dead)
        {
            if (Vector3.Distance(transform.position, _trump.transform.position) < 20)
            {
                _animator.SetTrigger("trumpInProximity");
                _navMeshAgent.destination = _trump.transform.position;
                if (Vector3.Distance(transform.position, _trump.transform.position) < 1)
                {
                    Attack();
                }
            }
        }
        _timeSinceLastAttack += Time.deltaTime;
    }
    private void Attack()
    {
        if (_timeSinceLastAttack > _attackCooldown)
        {
            _animator.SetTrigger("hittingTrump");
            _trump.GetComponent<PlayerBehavior>().ApplyDamage(_damage);
            _timeSinceLastAttack = 0f;
        }
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
    }
}
