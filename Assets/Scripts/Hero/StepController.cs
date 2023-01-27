using UnityEngine;

public class StepController : MonoBehaviour
{
    [SerializeField] private AudioClip _stepSound;
    private AudioSource _audioSrc;
    private CharacterController _heroController;

    void Start()
    {
        _audioSrc = GetComponent<AudioSource>();
        _heroController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        if (_heroController.isGrounded)
        {
            if (_heroController.velocity.magnitude > 0f)
            {
                if (!_audioSrc.isPlaying)
                {
                    _audioSrc.clip = _stepSound;
                    _audioSrc.Play();
                }
            }
        }
    }
}