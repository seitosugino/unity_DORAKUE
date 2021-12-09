using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseItemCommandPhase : PhaseBase
{
    public override IEnumerator Execute(BattleContext battleContext)
    {
        yield return null;
        battleContext.windowBattleItemCommand.CreateSelectableText(battleContext.player.GetStringOfItem());
        battleContext.windowBattleItemCommand.Open();
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int currentID = battleContext.windowBattleItemCommand.currentID;
            battleContext.player.selectCommand = battleContext.player.inventory[currentID];
            battleContext.player.SetTarget();
            battleContext.enemy.selectCommand = battleContext.enemy.commands[0];
            battleContext.enemy.SetTarget();
            next = new ExecutePhase();
        }
        else
        {
            next = new ChooseCommandPhase();
        }
        battleContext.windowBattleItemCommand.gameObject.SetActive(false);
    }
}