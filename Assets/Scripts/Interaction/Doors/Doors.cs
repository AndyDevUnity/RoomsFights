using UnityEngine;

public class Doors : MonoBehaviour
{
    [SerializeField] private Transform _door;
    [SerializeField] private GameObject _enemy;
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        InteractiveDoors();
    }
    private void InteractiveDoors()
    {
        if (_enemy == null)
            _animator.SetBool("isOpen", true);
    }
}
