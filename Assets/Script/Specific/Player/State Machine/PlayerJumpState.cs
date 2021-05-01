﻿using Specific.InputSystem;
using UnityEngine;

namespace Specific.Player
{
    public class PlayerJumpState : PlayerStateBase
    {
        public override void OnEnter(PlayerController player)
        {
            Debug.Log("Jump");
            player.mController.ImmediateImpact(Vector2.up, player.jump, 0);
        }

        public override void OnExit(PlayerController player)
        {
            player.mController.RelativeBrake(player.jump.endMultiply, affectX:false);
        }

        public override void OnFixedUpdate(PlayerController player)
        {
            float currentDirection = InputManager.MainInput.Player.Move.ReadValue<float>();

            if (currentDirection != 0) player.mController.ImmediateAccelerate(new Vector2(currentDirection, 0), player.move, 0, brakeAffectY: false);
            else player.mController.RelativeBrake(player.move.endMultiply, affectY: false);
        }

        public override void OnUpdate(PlayerController player)
        {
            if (player.mController.IsFalling || InputManager.MainInput.Player.Jump.ReadValue<float>() == 0) 
            {
                player.To(player.state.onAirState); // To onAirState
            }
            if (player.floorDetection.IsDetected)
            {
                if (InputManager.MainInput.Player.Move.ReadValue<float>() != 0) player.To(player.state.walkState); // To walk State
                else player.To(player.state.idleState);  // To idle state
            }
            if (InputManager.MainInput.Player.Dash.ReadValue<Vector2>() != Vector2.zero && !player.dashCDCounter.IsCoolDown) player.To(player.state.dashState); // To dash state
        }
    }
}

