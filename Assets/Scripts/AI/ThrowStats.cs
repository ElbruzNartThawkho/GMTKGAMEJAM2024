using UnityEngine;

public class ThrowStats : MonoBehaviour
{
    [HideInInspector] public int damage;
    private void Start()
    {
        Destroy(gameObject, 8);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
        Destroy(gameObject, 0.1f);
    }
}