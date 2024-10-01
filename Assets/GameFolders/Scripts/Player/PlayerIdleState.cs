using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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

    public override void Update()
    {
        base.Update();

        //When player got input, player starts move state
        if (xInput != 0 || yInput != 0)
            stateMachine.ChangeState(player.moveState);

        if (Input.GetMouseButtonDown(0))
            player.PlayerAttacks();
    }
}
