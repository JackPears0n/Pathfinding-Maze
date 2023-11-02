using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GIdle : State
{
    public GIdle(GhostScript ghost, StateMachine sm) : base(ghost, sm)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        gs.CheckForHunt();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
