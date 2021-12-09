using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battler : MonoBehaviour
{
    // HP
    public new string name;
    public int hp;

    public CommandSO selectCommand;
    public Battler target;
    public Battler enemy;

    public List<CommandSO> commands;
    public List<CommandSO> inventory = new List<CommandSO>();

    public string[] GetStringOfItem()
    {
        return GetStringOf(inventory);
    }

    public string[] GetStringOfCommands()
    {
        return GetStringOf(commands);
    }

    string[] GetStringOf(List<CommandSO> commands)
    {
        List<string> list = new List<string>();
        foreach (CommandSO command in commands)
        {
            list.Add(command.name);
        }
        return list.ToArray();
    }

    public void RemoveItem(CommandSO item)
    {
        inventory.Remove(item);
    }

    public void SetTarget()
    {
        if (selectCommand.targetType == CommandSO.TargetType.Self)
        {
            target = this;
        }
        else if (selectCommand.targetType == CommandSO.TargetType.Enemy)
        {
            target = enemy;
        }
    }
}
