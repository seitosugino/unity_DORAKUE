using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HealItemSO : CommandSO
{
    [SerializeField] int healPoint;
    public override void Execute(Battler user, Battler target)
    {
        target.hp += healPoint;
        Debug.Log($"{target.name}{healPoint}:{target.hp}");
        user.RemoveItem(this);
    }
}
