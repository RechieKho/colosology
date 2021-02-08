using UnityEngine;

/* This namespace is use for:
 * store AtkData class
 */
namespace General.Data.AttackData.Legacy 
{
    // This class is use for store the base data for other class in AttackData
    public class AtkData : ScriptableObject
    {
        #region Variable
        public Vector2 offset;
        public LayerMask targetLayer;
        public LayerMask blockingLayer;
        public bool atkMultiple;
        public bool reduceHealthOnly;
        public int damage;
        public float coolDown;
        #endregion
    }
}