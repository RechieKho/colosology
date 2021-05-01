using UnityEngine;

/* This namespace is use for:
 * store Attack classes
 */
namespace General.Attack 
{
    // This class is use for store the base data for other class in AttackData
    public class Attack_SO : ScriptableObject
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