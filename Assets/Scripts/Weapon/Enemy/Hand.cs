using UnityEngine;

public class Hand : MonoBehaviour
{
    private float _damage = 20f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<HeroHealth>().GetDamage(_damage);
        }
    }
}
