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

    public BattleContext(Battler player, Battler enemy, WindowBattleMenuCommand windowBattleMenuCommand, WindowBattleMenuCommand windowBattleSpellCommand)
    {
        this.player = player;
        this.enemy = enemy;
        this.windowBattleMenuCommand = windowBattleMenuCommand;
        this.windowBattleSpellCommand = windowBattleSpellCommand;
    }
}
