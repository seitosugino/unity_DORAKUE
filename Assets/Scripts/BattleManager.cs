using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] Battler player = default;
    [SerializeField] Battler enemy = default;
    enum Phase
    {
        StartPhase,
        ChooseCommandPhase,
        ExecutePhase,
        Result,
        End,
    }

    Phase phase;

    void Start()
    {
        phase = Phase.StartPhase;
        StartCoroutine(Battle());
    }

    IEnumerator Battle()
    {
        while (phase != Phase.End)
        {
            yield return null;
            switch (phase)
            {
                case Phase.StartPhase:
                    phase = Phase.ChooseCommandPhase;
                    break;
                case Phase.ChooseCommandPhase:
                    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
                    player.selectCommand = player.commands[1];
                    player.target = player;
                    enemy.selectCommand = enemy.commands[0];
                    enemy.target = enemy;

                    phase = Phase.ExecutePhase;
                    break;
                case Phase.ExecutePhase:
                    player.selectCommand.Execute(player, player.target);
                    enemy.selectCommand.Execute(enemy, enemy.target);
                    // どちらかが死亡したら
                    if (player.hp <= 0 || enemy.hp <= 0)
                    {
                        phase = Phase.Result;
                    }
                    else
                    {
                        phase = Phase.ChooseCommandPhase;
                    }
                    break;
                case Phase.Result:
                    phase = Phase.End;
                    break;
                case Phase.End:
                    break;

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
