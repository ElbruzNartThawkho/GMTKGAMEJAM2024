using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [HideInInspector] public ColorfulEnemy enemy;
    [HideInInspector] public Transform player;
    [HideInInspector] public bool isRed;
    public float range = 8;

    void Start()
    {
        enemy = GetComponent<ColorfulEnemy>();
        player = Movement.Instance.transform;
    }

    void Update()
    {
        if (isRed && enemy.currentState is not AlertState)
        {
            enemy.ChangeState(new AlertState());
        }
        isRed = Vector3.Distance(player.position, transform.position) < range;
    }
}