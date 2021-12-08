using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseSpellCommandPhase : PhaseBase
{
    public override IEnumerator Execute(BattleContext battleContext)
    {
        yield return null;
        battleContext.windowBattleSpellCommand.Open();
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape));
        int currentID = battleContext.windowBattleSpellCommand.currentID;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentID == 0)
            {
                battleContext.player.selectCommand = battleContext.player.commands[0];
                battleContext.player.target = battleContext.enemy;
                battleContext.enemy.selectCommand = battleContext.enemy.commands[0];
                battleContext.enemy.target = battleContext.player;
                next = new ExecutePhase();
            }
            else if (currentID == 1)
            {
                battleContext.player.selectCommand = battleContext.player.commands[0];
                battleContext.player.target = battleContext.player;
                battleContext.enemy.selectCommand = battleContext.enemy.commands[0];
                battleContext.enemy.target = battleContext.player;
                next = new ExecutePhase();
            }
            else
            {
                battleContext.windowBattleMenuCommand.Select();
                next = new ChooseCommandPhase();
            }
        }
        else
        {
            next = new ChooseCommandPhase();
        }
        battleContext.windowBattleSpellCommand.gameObject.SetActive(false);
    }
}
