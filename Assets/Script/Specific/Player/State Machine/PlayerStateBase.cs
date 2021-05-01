
namespace Specific.Player
{
    public abstract class PlayerStateBase
    {
        public abstract void OnEnter(PlayerController player);

        public abstract void OnUpdate(PlayerController player);
        public abstract void OnFixedUpdate(PlayerController player);
        public abstract void OnExit(PlayerController player);
    }
}

