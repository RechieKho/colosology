
/* This namespace is use for:
 * store melee data
 */
namespace General.Attack 
{
    // This class is use for storing data for melee attack with circle hitbox
    public class MeleeCirc_SO : Attack_SO
    {
        #region Variable
        public float stretch;
        public float radius;
        public bool damageFromCentreOfHitBox;
        #endregion
    }
}