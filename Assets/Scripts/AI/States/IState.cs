public interface IState
{
    void EnterState(ColorfulEnemy enemy);
    void UpdateState(ColorfulEnemy enemy);
    void ExitState(ColorfulEnemy enemy);
}
