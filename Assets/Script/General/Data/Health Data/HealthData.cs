using UnityEngine;
using General.Data.Other;

/* This namespace is use for:
 *
 */
namespace General.Data.HealthSystem 
{
    // This class is use for storing variable
    public class HealthData : ScriptableObject
    {
        #region Variable
        [Range(AttributeData.Range.MinMaxHealth, AttributeData.Range.MaxMaxHealth)]public int maxHealth;
        #endregion
    }
}