using UnityEngine;

public class ProjectileTrigger : MonoBehaviour
{
    [HideInInspector] public MagicGun magicGun;
    [SerializeField] float damage = 10;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
        magicGun.Effect(transform);
        gameObject.SetActive(false);
    }
}
