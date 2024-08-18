using System;

public class HealthPlayer : Health
{
    public static Action GameOver;

    public override void Die()
    {
        GameOver?.Invoke();
    }

    public override void Hit()
    {
        CamShake.instance.ShakeCamera(2, 0.5f);
    }
}
