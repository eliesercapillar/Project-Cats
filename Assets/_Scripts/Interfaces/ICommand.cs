using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand
{
    void Execute();
}

public abstract class PlayerCommand : ICommand
{
    public abstract void Execute();
}

public class FillMilkCommand : PlayerCommand
{
    public override void Execute()
    {

    }
}
