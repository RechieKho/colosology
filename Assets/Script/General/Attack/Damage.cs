using UnityEngine;

/* This namespace is use for:
 * storing data classes that is associate with attack
 */
namespace General.Attack 
{
    // This class is use for storing damage data
    public class Damage
    {
        #region Property
        public int Amount { get { return amount; } }
        public GameObject Attacker { get { return attacker; } }
        public Vector2 Direction { get { return direction; } }
        public float Force { get { return force; } }
        #endregion

        #region Variable
        private int amount;
        private GameObject attacker;
        private Vector2 direction;
        private float force;
        #endregion

        #region Method
        public Damage(int __amount, GameObject __attacker, Vector2 __direction, float __force = 1f)
        {
            amount = __amount;
            attacker = __attacker;
            direction = __direction;
            force = __force;
        }
        #endregion
    }
}