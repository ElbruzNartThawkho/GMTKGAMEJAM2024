using UnityEngine;

public class AlertState : IState
{
    public void EnterState(ColorfulEnemy enemy)
    {

    }

    public void ExitState(ColorfulEnemy enemy)
    {

    }

    public void UpdateState(ColorfulEnemy enemy)
    {
        Vector3 player = enemy.fieldOfView.player.position; player.y = enemy.transform.position.y;
        Quaternion lookOnLook = Quaternion.LookRotation(player - enemy.transform.position);
        enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, lookOnLook, Time.deltaTime * 10);

        if (Vector3.Distance(enemy.transform.position, enemy.fieldOfView.player.position) <= enemy.fieldOfView.range * 0.375f &&
                        Mathf.Sqrt(Mathf.Pow(enemy.agent.velocity.x, 2) + Mathf.Pow(enemy.agent.velocity.z, 2)) > 0.1f)
        {
            enemy.agent.SetDestination(enemy.transform.position);
        }
        else if (Vector3.Distance(enemy.transform.position, enemy.fieldOfView.player.position) > enemy.fieldOfView.range)
        {
            enemy.agent.SetDestination(enemy.fieldOfView.player.position);
        }
        if (enemy.stillRangeAttack == false && Vector3.Distance(enemy.transform.position, enemy.fieldOfView.player.position) < enemy.fieldOfView.range)
        {
            enemy.RangeAttackWait();
        }
    }
}
