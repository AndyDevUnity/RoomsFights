using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private float _health = 50f;
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void GetDamage(float amount)
    {
        _health -= amount;
        if (_health <= 0)
        {
            _animator.SetBool("dead", true);
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject, 5.4f);
    }

}
