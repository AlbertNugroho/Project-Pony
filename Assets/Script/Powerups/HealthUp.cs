using UnityEngine;

public class HealthUp : PowerUp
{
    [SerializeField] private float healAmount = 2f;

    public override void ApplyEffect(GameObject player)
    {
        Health hp = player.GetComponent<Health>();
        if (hp != null)
        {
            hp.AddHealth(healAmount);
        }
    }

    public override void RemoveEffect(GameObject player)
    {
        //do nothing
    }
}
