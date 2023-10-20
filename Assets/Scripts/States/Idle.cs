using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{
    public Idle(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }
    public override void Enter()
    {
        base.Enter();

        ps.rb.velocity = new Vector3(0, 0, 0);
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

        ps.CheckForMoveInput();

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }
}
