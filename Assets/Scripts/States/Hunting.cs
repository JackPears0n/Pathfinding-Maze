using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunting : State
{
    public Hunting(GhostScript ghost, StateMachine sm) : base(ghost, sm)
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

    }

    public override void PhysicsUpdate()
    {
        if (!gs.agent.pathPending && gs.agent.remainingDistance < 0.5F)
        {
            gs.GoToTarget();
        }

    }
}
