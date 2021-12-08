using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCommandPhase : PhaseBase
{
    public override IEnumerator Execute(BattleContext battleContext)
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        int currentID = battleContext.windowBattleMenuCommand.currentID;
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
            next = new ChooseSpellCommandPhase();
        }
        else
        {
            next = new ChooseCommandPhase();
        }
        Debug.Log("ChooseCommandPhase");
    }
}
