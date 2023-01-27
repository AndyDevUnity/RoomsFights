using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeroHealth : MonoBehaviour
{
    [SerializeField] private float _health;
    public Slider _healthBar;

    private void Update()
    {
        _healthBar.value = _health;
    }
    public void GetDamage(float amount)
    {
        _health -= amount;
        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
