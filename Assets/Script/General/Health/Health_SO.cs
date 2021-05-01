using UnityEngine;
using General.Other;

/* This namespace is use for:
 *
 */
namespace General.Health 
{
    // This class is use for storing variable
    public class Health_SO : ScriptableObject
    {
        #region Variable
        [Range(AttributeData.Range.MinMaxHealth, AttributeData.Range.MaxMaxHealth)]public int maxHealth;
        #endregion
    }
}