using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Transform _hero;
    [SerializeField] private Transform _enemy;
    private Animator _animator;
    private float _attackRange = 3f;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Attack();
    }

    private void Attack()
    {
        float distance = Vector3.Distance(_enemy.position, _hero.position);
        if (distance < _attackRange)
        {
            _animator.SetBool("attack", true);
        }
        else
        {
            _animator.SetBool("attack", false);
        }
    }

}
