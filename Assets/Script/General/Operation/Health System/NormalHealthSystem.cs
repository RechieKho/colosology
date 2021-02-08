using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using General.Data.HealthSystem;
using General.Data.AttackData;

/* This namespace is use for:
 * store code about health system
 */
namespace General.Operation.HealthSystem 
{
    // This class is use for normal health system (no need to pass data across scene)
    public class NormalHealthSystem : MonoBehaviour
    {
        #region Variable
        public HealthData healthData;
        public NormalHealth health;
        #endregion

        #region method
        private void Awake()
        {
            health = new NormalHealth(healthData);
        }

        #endregion
    }

    public class NormalHealth
    {
        #region Property
        public int CurrentHealth { get { return _currentHealth; } }
        #endregion

        #region Variable
        // public
        private HealthData _healthData;
        private int _currentHealth;
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
        // constructor
        public NormalHealth(HealthData data)
        {
            _healthData = data;
            _currentHealth = _healthData.maxHealth;
        }

        public void Damage(DamageData __damageData)
        {
            ReduceHealth(__damageData.Amount);
            onAttacked?.Invoke(__damageData);
        }

        public void IncreaseHealth(int amount)
        {
            _currentHealth = Mathf.Clamp(_currentHealth += amount, 0, _healthData.maxHealth);
            onHeal?.Invoke();
        }

        public void ReduceHealth(int amount)
        {
            _currentHealth = Mathf.Clamp(_currentHealth -= amount, 0, _healthData.maxHealth);
            onDamaged?.Invoke();
            if (_currentHealth == 0) onDead?.Invoke();
        }

        public void MaxHealth()
        {
            _currentHealth = _healthData.maxHealth;
            onHeal?.Invoke();
        }

        #endregion
    }
}