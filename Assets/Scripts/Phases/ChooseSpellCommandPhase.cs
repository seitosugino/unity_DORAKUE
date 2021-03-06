using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseSpellCommandPhase : PhaseBase
{
    public override IEnumerator Execute(BattleContext battleContext)
    {
        yield return null;
        battleContext.windowBattleSpellCommand.CreateSelectableText(battleContext.player.GetStringOfCommands());
        battleContext.windowBattleSpellCommand.Open();
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int currentID = battleContext.windowBattleSpellCommand.currentID;
            battleContext.player.selectCommand = battleContext.player.commands[currentID];
            battleContext.player.SetTarget();
            battleContext.enemy.selectCommand = battleContext.enemy.commands[0];
            battleContext.enemy.SetTarget();
            next = new ExecutePhase();
        }
        else
        {
            next = new ChooseCommandPhase();
        }
        battleContext.windowBattleSpellCommand.gameObject.SetActive(false);
    }
}
