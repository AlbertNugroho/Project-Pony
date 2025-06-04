using UnityEngine;

public class TripleShotUp : PowerUp
{
    public int bulletBonus = 2; // how many extra bullets this power-up gives

    public override void ApplyEffect(GameObject player)
    {
        Shoot shoot = player.GetComponent<Shoot>();
        if (shoot != null)
        {
            shoot.AddExtraBullets(bulletBonus);
        }
    }

    public override void RemoveEffect(GameObject player)
    {
        Shoot shoot = player.GetComponent<Shoot>();
        if (shoot != null)
        {
            shoot.AddExtraBullets(-bulletBonus);
        }
    }
}
