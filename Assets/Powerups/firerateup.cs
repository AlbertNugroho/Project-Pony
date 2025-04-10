using UnityEngine;

public class firerateup : PowerUp
{
    public override void ApplyEffect(GameObject player)
    {
        Shoot shoot = player.GetComponent<Shoot>();
        if (shoot != null)
        {
            shoot.fireRateUpStacks++;
            shoot.UpdateFireRateFromStacks();
        }
    }

    public override void RemoveEffect(GameObject player)
    {
        Shoot shoot = player.GetComponent<Shoot>();
        if (shoot != null)
        {
            shoot.fireRateUpStacks = Mathf.Max(0, shoot.fireRateUpStacks - 1);
            shoot.UpdateFireRateFromStacks();
        }
    }
}
