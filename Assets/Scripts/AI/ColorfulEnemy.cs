using System;
using System.Collections;
using UnityEngine;

public class ColorfulEnemy : Enemies
{

    public GameObject rangerThrowablePref;
    public static Action EnemyDied;
    public float rangeAttackWaitTime;
    public int damage;

    public IState currentState = new PatrolState();

    [HideInInspector] public Animator animator;
    [HideInInspector] public bool stillRangeAttack = false;
    public void RangeAttackWait()
    {
        StartCoroutine(PreparationForFire(rangeAttackWaitTime));
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void ChangeState(IState newState)
    {
        currentState?.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }

    IEnumerator PreparationForFire(float time)
    {
        stillRangeAttack = true;
        for (float i = 0; i <= time;)
        {
            i += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        GameObject gameObject = Instantiate(rangerThrowablePref, transform.position + Vector3.up, rangerThrowablePref.transform.rotation);
        gameObject.GetComponent<ThrowStats>().damage = damage;
        gameObject.GetComponent<Rigidbody>().AddForce((transform.forward + Vector3.up * 0.1f) * 30, ForceMode.Impulse);
        stillRangeAttack = false;
    }
    public void Died()
    {
        EnemyDied?.Invoke();
        Destroy(gameObject);
    }
}
