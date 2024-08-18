using UnityEngine;
using UnityEngine.AI;

public abstract class Enemies : MonoBehaviour
{
    public Health health;
    public NavMeshAgent agent;
    public FieldOfView fieldOfView;
    public EnemyClass enemyClass;

    private void OnEnable()
    {
        health = GetComponent<Health>();
        agent = GetComponent<NavMeshAgent>();
    }
}
public enum EnemyClass
{
    red = 0,
    green = 1,
    blue = 2
}
