using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class State
{
    protected GhostScript gs;
    protected PlayerScript ps;

    protected StateMachine sm;

    //Constructor for the base
    protected State(GhostScript gs, StateMachine sm)
    {
        this.gs = gs;
        this.sm = sm;
    }

    protected State(PlayerScript ps, StateMachine sm)
    {
        this.ps = ps;
        this.sm = sm;
    }

    #region Common Methods
    public virtual void Enter()
    {
        //Debug.Log("This is base.enter");
    }

    public virtual void HandleInput()
    {
    }

    public virtual void LogicUpdate()
    {
    }

    public virtual void PhysicsUpdate()
    {
    }

    public virtual void Exit()
    {
    }
    #endregion
}
