using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AttackCommandSO : CommandSO
{
    [SerializeField] int at;

    // CommandSOの上書き
    public override void Execute(Battler user, Battler target)
    {
        target.hp -= at;
        Debug.Log($"{target.name}へ{at}ダメージ:残りHP{target.hp}");
    }
}
