using UnityEngine;

public class EnemiesHealth : Health
{
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public override void Die()
    {
        animator.Play("died");
    }

    public override void Hit()
    {
        animator.Play("pushed");
    }
}
