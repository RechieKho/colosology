using System.Collections;
using UnityEngine.SceneManagement;
using General.Data.HealthSystem;
using General.Data.AttackData;
using UnityEngine;

/* This namespace is use for:
 * store code about health system
 */
namespace General.Operation.HealthSystem 
{
    // This class is use for storing static health (health that can pass to other scene)
    public class StaticHealthSystem : MonoBehaviour
    {
        #region Variable
        public HealthData healthData;
        public StaticHealth health;
        #endregion
        
        #region Method

        private void Awake()
        {
            // load data if possible
            StaticHealth healthFromLoad = HealthStorage.loadData(gameObject.name);
            if(healthFromLoad != null)
            {
                health = healthFromLoad;
                return;
            }

            // else create one
            health = new StaticHealth(healthData, gameObject.name);
        }

        // This method will delete data in health Storage (Only use it when this script is lastly appear in scene)
        public void DeleteData()
        {
            HealthStorage.RemoveData(health);
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
        private HealthData _healthData;
        private int _currentHealth;
        private string _gameObjectName;
        #endregion

        #region Event
        public delegate void HealthChange();
        public delegate void Attacked(DamageData __damageData);
        public event HealthChange onDamaged;
        public event HealthChange onHeal;
        public event HealthChange onDead;
        public event Attacked onAttacked;
        #endregion

        #region Method
        // Public
        // constructor
        public StaticHealth(HealthData data, string gameObjectName)
        {
            _gameObjectName = gameObjectName;
            _healthData = data;
            _currentHealth = _healthData.maxHealth;
        }

        public void Damage(DamageData __damageData)
        {
            ReduceHealth(__damageData.Amount);
            onAttacked?.Invoke(__damageData);
        }

        public void IncreaseHealth(int __amount)
        {
            _currentHealth = Mathf.Clamp(_currentHealth += __amount, 0, _healthData.maxHealth);
            onHeal?.Invoke();
            SaveData();
        }

        public void ReduceHealth(int __amount)
        {
            _currentHealth = Mathf.Clamp(_currentHealth -= __amount, 0, _healthData.maxHealth);
            onDamaged?.Invoke();
            if (_currentHealth == 0) onDead?.Invoke();
            SaveData();
        }

        public void MaxHealth()
        {
            _currentHealth = _healthData.maxHealth;
            onHeal?.Invoke();
            SaveData();
        }

        // Private
        private void SaveData()
        {
            HealthStorage.StoreData(this);
        }
        
        #endregion
    }
}