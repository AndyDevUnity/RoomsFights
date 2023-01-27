using UnityEngine;

public class HeroMover : MonoBehaviour
{
    [SerializeField] private CharacterController _heroController;
    [SerializeField] private float _speed;
    [SerializeField] private float _sprintSpeed;
    [SerializeField] private float _jumpForce;
    private Vector3 _move;
    private Vector3 _velocity;

    [SerializeField] private Transform _checkGround;
    [SerializeField] private LayerMask _groundLayer;
    private float _groundDistance = 0.5f;
    private float _gravity = -18;
    private bool _isGround;

    private void Awake()
    {
        _heroController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
        Run();
        Sprint();
        Jump();
    }

    private void Run()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _move = transform.right * horizontal + transform.forward * vertical;
        _heroController.Move(_move * _speed * Time.deltaTime);
    }

    private void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _heroController.Move(_move * _sprintSpeed * Time.deltaTime);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
            _velocity.y = _jumpForce;
    }

    private void CheckGround()
    {
        _velocity.y += _gravity * Time.deltaTime;
        _heroController.Move(_velocity * Time.deltaTime);

        _isGround = Physics.CheckSphere(_checkGround.position, _groundDistance, _groundLayer);
        if (_isGround && _velocity.y < 0)
        {
            _velocity.y -= 1f;
        }
    }
}
