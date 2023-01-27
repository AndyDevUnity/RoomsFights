using UnityEngine;
using UnityEngine.AI;

public class EnemyMover : MonoBehaviour
{
    private NavMeshAgent _agent;
    [SerializeField] private Transform _hero;
    [SerializeField] private Transform _enemy;
    private Animator _animator;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        StopMove();
    }


    private void Move()
    {
        float distance = Vector3.Distance(_enemy.position, _hero.position);
        if (distance <= 9f)
        {
            _agent.SetDestination(_hero.position);
        }
    }

    private void StopMove()
    {
        if (_animator.GetBool("dead") == true)
        {
            _agent.isStopped = true;
            _enemy.LookAt(_hero.position);
        }
    }
}
