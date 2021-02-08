using General.Data.AttackData.Legacy;
using UnityEngine;

/* This namespace is use for:
 * store range attack data
 */
namespace General.Data.AttackData.Ranged 
{
    // This class is use for storing data for ranged attack which have circle hitbox
    public class RangedCircData : AtkData
    {
        #region Variable
        public bool destroyOnTrigger;
        public float maxLength;
        public float radius;
        #endregion
    }
}