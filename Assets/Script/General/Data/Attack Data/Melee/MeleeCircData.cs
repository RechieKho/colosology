using General.Data.AttackData.Legacy;

/* This namespace is use for:
 * store melee data
 */
namespace General.Data.AttackData.Melee 
{
    // This class is use for storing data for melee attack with circle hitbox
    public class MeleeCircData : AtkData
    {
        #region Variable
        public float stretch;
        public float radius;
        public bool damageFromCentreOfHitBox;
        #endregion
    }
}