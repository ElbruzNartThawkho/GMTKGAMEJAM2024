using UnityEngine;
using UnityEngine.AI;

public abstract class Enemies : MonoBehaviour
{
    public Health health;
    public NavMeshAgent agent;
    private void OnEnable()
    {
        health = GetComponent<Health>();
        agent = GetComponent<NavMeshAgent>();
    }

}
