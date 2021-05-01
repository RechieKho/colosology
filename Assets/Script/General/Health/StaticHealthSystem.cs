using General.Attack;
using General.Other;
using UnityEngine;
using System.Collections.Generic;

/* This namespace is use for:
 * store code about health system
 */
namespace General.Health 
{
    // This class is use for storing static health (health that can pass to other scene)
    public class StaticHealthSystem : MonoBehaviour
    {
        #region Variable
        public Health_SO healthData;
        public StaticHealth health;
        public bool isFreezable = true;
        #endregion
        
        #region Method

        private void Awake()
        {
            // load data if possible
            StaticHealth healthFromLoad = StaticHealthStorage.loadData(gameObject.name);
            if(healthFromLoad != null)
            {
                health = healthFromLoad;
                return;
            }

            // else create one
            health = new StaticHealth(healthData, gameObject.name, isFreezable);
        }

        // This method will delete data in health Storage (Only use it when this script is lastly appear in scene)
        public void DeleteData()
        {
            StaticHealthStorage.RemoveData(health);
        }

        #endregion
    }

    // This class contain health data manipulation
    public class StaticHealth
    {
        #region Property
        public int CurrentHealth { get { return _currentHealth; } }
        public string GameObjectName { get { return _gameObjectName; } }
        #endregion

        #region Variable
        // public
        private Health_SO _healthData;
        private int _currentHealth;
        private string _gameObjectName;
        private bool _isFreezing;
        #endregion

        #region Event
        public delegate void HealthChange();
        public delegate void Attacked(Damage __damageData);
        public event HealthChange onDamaged;
        public event HealthChange onHeal;
        public event HealthChange onDead;
        public event Attacked onAttacked;
        #endregion

        #region Method
        // Public
        // constructor
        public StaticHealth(Health_SO data, string gameObjectName, bool isFreezable )
        {
            _gameObjectName = gameObjectName;
            _healthData = data;
            _currentHealth = _healthData.maxHealth;
            if(isFreezable) Freezer.trigger += Freeze;
        }

        public void Damage(Damage __damageData)
        {
            if (_isFreezing) return;
            ReduceHealth(__damageData.Amount);
            onAttacked?.Invoke(__damageData);
        }

        public void IncreaseHealth(int __amount)
        {
            if (_isFreezing) return;
            _currentHealth = Mathf.Clamp(_currentHealth += __amount, 0, _healthData.maxHealth);
            onHeal?.Invoke();
            SaveData();
        }

        public void ReduceHealth(int __amount)
        {
            if (_isFreezing) return;
            _currentHealth = Mathf.Clamp(_currentHealth -= __amount, 0, _healthData.maxHealth);
            onDamaged?.Invoke();
            if (_currentHealth == 0) onDead?.Invoke();
            SaveData();
        }

        public void MaxHealth()
        {
            if (_isFreezing) return;
            _currentHealth = _healthData.maxHealth;
            onHeal?.Invoke();
            SaveData();
        }

        // Private
        private void SaveData()
        {
            StaticHealthStorage.StoreData(this);
        }
        
        private void Freeze(bool __freeze)
        {
            _isFreezing = __freeze;
        }
        
        #endregion
    }

    // This class is use for store health data from static health system
    public static class StaticHealthStorage
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