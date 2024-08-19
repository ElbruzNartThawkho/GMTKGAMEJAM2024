using System;
using UnityEngine;

public class EnemiesHealth : Health
{
    [SerializeField] GameObject deathEffect;
    public static Action EnemyDied;
    //Animator animator;
    private void Start()
    {
        FPSGameManager.instance.EnemyCountIncrease();
        //animator = GetComponent<Animator>();
    }
    private void Update()
    {
        // Sa�l�k de�eriyle ters orant�l� olarak hedef �l�e�i hesapla (Mathf.Lerp kullanarak)
        float targetSize = 2 - (currentHealth / maxHealth);

        // Mevcut �l�e�i hedef �l�e�e Lerp ile yakla�t�r (Vector3.Lerp kullanarak)
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(targetSize, targetSize, targetSize), Time.deltaTime);
    }
    public override void Die()
    {
        Destroy(Instantiate(deathEffect, transform.position, deathEffect.transform.rotation), 2);
        EnemyDied?.Invoke();
        Destroy(gameObject);
    }

    public override void Hit()
    {
        //animator.Play("pushed");
    }
}
