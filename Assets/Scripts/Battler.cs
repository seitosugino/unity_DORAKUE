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

    public CommandSO[] commands;
}
