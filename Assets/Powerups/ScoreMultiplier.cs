using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMultiplier : PowerUp
{
    public override void ApplyEffect(GameObject player)
    {
        ScoreManager sm = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        sm.activeMultipliers++;
        sm.RecalculateMultiplier();
    }

    public override void RemoveEffect(GameObject player)
    {
        ScoreManager sm = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        sm.activeMultipliers = Mathf.Max(0, sm.activeMultipliers - 1);
        sm.RecalculateMultiplier();
    }

}
