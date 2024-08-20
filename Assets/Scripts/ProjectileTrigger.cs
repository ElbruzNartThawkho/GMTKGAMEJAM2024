using UnityEngine;

public class ProjectileTrigger : MonoBehaviour
{
    [HideInInspector] public MagicGun magicGun;
    [SerializeField] float damage = 10;
    [SerializeField] EnemyClass type;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.gameObject.GetComponent<ColorfulEnemy>().currentState is not AlertState)
            {
                collision.gameObject.GetComponent<ColorfulEnemy>().ChangeState(new AlertState());
            }
            if (collision.gameObject.GetComponent<Enemies>().enemyClass == type)
            {
                collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            }
            else
            {
                collision.gameObject.GetComponent<Health>().Heal(damage);
            }
        }
        magicGun.Effect(transform);
        gameObject.SetActive(false);
    }
}
