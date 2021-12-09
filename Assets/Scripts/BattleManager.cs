using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] BattleContext battleContext;
    PhaseBase phaseState;

    void Start()
    {
        phaseState = new StartPhase();
        StartCoroutine(Battle());
    }

    IEnumerator Battle()
    {
        while (!(phaseState is EndPhase))
        {
            yield return phaseState.Execute(battleContext);
            phaseState = phaseState.next;
        }
        yield return phaseState.Execute(battleContext);

        yield break;
    }
}

[System.Serializable]
public struct BattleContext
{
    public Battler player;
    public Battler enemy;
    public WindowBattleMenuCommand windowBattleMenuCommand;
    public WindowBattleMenuCommand windowBattleSpellCommand;
    public WindowBattleMenuCommand windowBattleItemCommand;
    public void SetEnemy()
    {
        player.enemy = enemy;
        enemy.enemy = player;
    }
}
