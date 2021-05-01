using Specific.InputSystem;
using UnityEngine;
using General.Coroutine;
using General.Attack;

namespace Specific.Player
{
    public class PlayerDashState : PlayerStateBase
    {
        private Vector2 _dashDirection;
        public override void OnEnter(PlayerController player)
        {
            Debug.Log("Dash");

            _dashDirection = InputManager.MainInput.Player.Dash.ReadValue<Vector2>();

            StartDash(player);
            new Timer(Timer.Timing.scaledTime, player.dashDuration, false, isFreezable:true, timeOut: () => EndDash(player));
        }

        public override void OnExit(PlayerController player)
        {
            _dashDirection = Vector2.zero;
        }

        public override void OnFixedUpdate(PlayerController player)
        {

        }

        public override void OnUpdate(PlayerController player)
        {
            if (player.enemyDetection.IsDetected) player.attacker.Attack(_dashDirection) ;
        }

        private void StartDash(PlayerController player)
        {
            player.mController.RelativeBrake(player.move.endMultiply);
            player.mController.SetGravity(0);
            player.mController.ImmediateImpact(_dashDirection, player.dash, 0.5f);
        }

        private void EndDash(PlayerController player)
        {
            player.mController.SetGravity(1);
            player.mController.RelativeBrake(player.dash.endMultiply);
            player.dashCDCounter.StartCooldown();

            // Transition
            if (player.floorDetection.IsDetected)
            {
                if (InputManager.MainInput.Player.Move.ReadValue<float>() != 0) player.To(player.state.walkState); // To walk State
                else player.To(player.state.idleState);  // To idle state
            }
            else player.To(player.state.onAirState);
        }
    }
}

