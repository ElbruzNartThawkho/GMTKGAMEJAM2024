using UnityEngine;

public class MagicGun : Weapons
{
    public GameObject projectile, effect;
    public float power;
    ObjectPooling projectilePool, effectPool;
    //Animator animator;

    private void Start()
    {
        projectilePool = gameObject.AddComponent<ObjectPooling>();
        effectPool = gameObject.AddComponent<ObjectPooling>();
        //animator = GetComponent<Animator>();
    }
    public override void Shoot(Transform transform)
    {
        //animator.Play("Shoot");
        GameObject currentProjectile = projectilePool.PoolRequest(projectile);
        currentProjectile.GetComponent<ProjectileTrigger>().magicGun = this;
        currentProjectile.GetComponent<Rigidbody>().velocity = Vector3.zero;
        currentProjectile.transform.position = transform.position;
        currentProjectile.transform.rotation = projectile.transform.rotation;
        currentProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * power, ForceMode.Impulse);
    }

    public override void Effect(Transform transform)
    {
        GameObject currentEffect = effectPool.PoolRequest(effect);
        currentEffect.transform.position = transform.position;
    }
}
