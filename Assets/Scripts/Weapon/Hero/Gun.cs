using UnityEngine;

public class Gun : MonoBehaviour
{
    private float _damage = 10f;
    private float _fireRange = 100f;
    private float _nextTime = 0f;
    private float _shotRate = 0.6f;
    private Animator _animator;
    [SerializeField] private Camera _camera;
    [SerializeField] private ParticleSystem _muzzleFlash;
    [SerializeField] private GameObject _hitEffect;
    [SerializeField] private AudioSource _audioSrc;
    [SerializeField] private AudioClip _shotSound;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > _nextTime)
        {
            Shot();
            _nextTime = Time.time + _shotRate;
            _animator.SetBool("attack", true);
        }
        else
        {
            _animator.SetBool("attack", false);
        }
    }

    private void Shot()
    {
        RaycastHit _hit;

        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out _hit, _fireRange))
        {
            Debug.Log(_hit.transform.name);

            EnemyHealth target = _hit.transform.GetComponent<EnemyHealth>();
            if (target != null)
            {
                target.GetDamage(_damage);
                GameObject impact = Instantiate(_hitEffect, _hit.point, Quaternion.LookRotation(_hit.normal));
                Destroy(impact, 3f);
            }
            _audioSrc.PlayOneShot(_shotSound);
            _muzzleFlash.Play();
        }
    }
}
