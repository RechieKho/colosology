using General.Data.AttackData.Legacy;
using UnityEngine;

/* This namespace is use for:
 * storing melee data
 */
namespace General.Data.AttackData.Melee 
{
    // This class is use for storing data for melee attack which have rectangle hitbox
    public class MeleeRectData : AtkData
    {
        #region Variable
        public float stretch;
        public Vector2 size;
        public bool damageFromCentreOfHitBox;
        #endregion
    }
}