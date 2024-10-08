using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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

        //For player movement. This function sets velocity with inputs.
        player.SetVelocity(xInput * player.moveSpeed, yInput * player.moveSpeed);

        //When there is no input, player changes state with idle.
        if (xInput == 0 && yInput == 0)
        {
            player.rb.velocity = Vector2.zero;
            stateMachine.ChangeState(player.idleState);
        }

        if (Input.GetMouseButtonDown(0))
            player.PlayerAttacks();
    }
}
