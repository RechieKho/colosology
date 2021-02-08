using UnityEngine;
using System.Collections.Generic;

/* This namespace is use for:
 * store code about health system
 */
namespace General.Operation.HealthSystem 
{
    // This class is use for store health data from static health system
    public static class HealthStorage
    {
        #region Variable
        private static IDictionary<string, StaticHealth> health = new Dictionary<string, StaticHealth>();
        #endregion

        #region Method
        public static void StoreData(StaticHealth staticHealth)
        {
            // store data
            if (health.ContainsKey(staticHealth.GameObjectName))
            {
                // Update data
                health[staticHealth.GameObjectName] = staticHealth;
            }
            else
            {
                // add data
                health.Add(staticHealth.GameObjectName, staticHealth);
            }
        }

        public static void RemoveData(StaticHealth staticHealth)
        {
            // remove data
            if (health.ContainsKey(staticHealth.GameObjectName)) health.Remove(staticHealth.GameObjectName);
        }

        public static StaticHealth loadData(string GameObjectName)
        {
            // return data
            if (health.ContainsKey(GameObjectName))
            {
                StaticHealth staticHealth = health[GameObjectName];
                return staticHealth;
            }
            else return null;
        }

        #endregion
    }
}