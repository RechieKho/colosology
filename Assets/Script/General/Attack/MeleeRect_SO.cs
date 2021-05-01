using UnityEngine;

/* This namespace is use for:
 * storing melee data
 */
namespace General.Attack 
{
    // This class is use for storing data for melee attack which have rectangle hitbox
    public class MeleeRect_SO : Attack_SO
    {
        #region Variable
        public float stretch;
        public Vector2 size;
        public bool damageFromCentreOfHitBox;
        #endregion
    }
}