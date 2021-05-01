using Specific.InputSystem;
using UnityEngine;

namespace Specific.Player
{
    public class PlayerWalkState : PlayerStateBase
    {
        public override void OnEnter(PlayerController player)
        {
            Debug.Log("Walking");
        }

        public override void OnExit(PlayerController player)
        {
        }

        public override void OnFixedUpdate(PlayerController player)
        {
            float currentDirection = InputManager.MainInput.Player.Move.ReadValue<float>();

            player.mController.ImmediateAccelerate(currentDirection>0f?Vector2.right:Vector2.left, player.move, 0); // This will always move, but it is better than keep init Vector 2 right?
        }

        public override void OnUpdate(PlayerController player)
        {
            if (InputManager.MainInput.Player.Move.ReadValue<float>() == 0) player.To(player.state.idleState); // To idle state
            if (!player.floorDetection.IsDetected) player.To(player.state.onAirState); // To onAir State
            if (InputManager.MainInput.Player.Dash.ReadValue<Vector2>() != Vector2.zero && !player.dashCDCounter.IsCoolDown) player.To(player.state.dashState); // To dash state
            if (InputManager.MainInput.Player.Jump.ReadValue<float>() == 1) player.To(player.state.jumpState); // To jump state
        }
    }
}

