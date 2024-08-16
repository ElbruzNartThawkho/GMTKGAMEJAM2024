using UnityEngine;

public class ProjectileTrigger : MonoBehaviour
{
    [HideInInspector] public MagicStaff magicStaff;
    [SerializeField] float damage = 10; 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Dummy"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
        magicStaff.Effect(transform);
        gameObject.SetActive(false);
    }
}
