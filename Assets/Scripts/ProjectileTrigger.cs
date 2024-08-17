using UnityEngine;

public class ProjectileTrigger : MonoBehaviour
{
    [HideInInspector] public MagicGun magicGun;
    [SerializeField] float increaseSize = 10;
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag("Dummy"))
        //{
        //    collision.gameObject.GetComponent<Health>().TakeDamage(increaseSize);
        //}
        magicGun.Effect(transform);
        gameObject.SetActive(false);
    }
}
