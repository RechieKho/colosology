using Specific.InputSystem;
using UnityEngine;

namespace Specific.Player
{
    public class PlayerIdleState : PlayerStateBase
    {
        public override void OnEnter(PlayerController player)
        {
            Debug.Log("Idle");        
        }

        public override void OnExit(PlayerController player)
        {
            
        }

        public override void OnFixedUpdate(PlayerController player)
        {
            player.mController.RelativeBrake(player.move.endMultiply, affectY:false);
        }

        public override void OnUpdate(PlayerController player)
        {
            if (InputManager.MainInput.Player.Move.ReadValue<float>() != 0) player.To(player.state.walkState); // To walk state
            if (!player.floorDetection.IsDetected) player.To(player.state.onAirState); // To onAir state
            if (InputManager.MainInput.Player.Dash.ReadValue<Vector2>() != Vector2.zero && !player.dashCDCounter.IsCoolDown) player.To(player.state.dashState); // To dash state
            if (InputManager.MainInput.Player.Jump.ReadValue<float>() == 1) player.To(player.state.jumpState); // To Jump State
        }
    }
}

