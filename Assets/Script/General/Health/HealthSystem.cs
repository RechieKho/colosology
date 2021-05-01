using UnityEngine;
using General.Attack;
using General.Other;

/* This namespace is use for:
 * store code about health system
 */
namespace General.Health 
{
    // This class is use for normal health system (no need to pass data across scene)
    public class HealthSystem : MonoBehaviour
    {
        #region Variable
        public Health_SO healthData;
        public Health health;
        public bool isFreezable = true;
        #endregion

        #region method
        private void Awake()
        {
            health = new Health(healthData, isFreezable);
        }

        #endregion
    }

    public class Health
    {
        #region Property
        public int CurrentHealth { get { return _currentHealth; } }
        #endregion

        #region Variable
        // public
        private Health_SO _healthData;
        private int _currentHealth;
        private bool _isFreezing = false;
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
        // constructor
        public Health(Health_SO data, bool isFreezable)
        {
            _healthData = data;
            _currentHealth = _healthData.maxHealth;
            if(isFreezable) Freezer.trigger += Freeze;
        }

        public void Damage(Damage __damageData)
        {
            if (_isFreezing || _currentHealth == 0) return;
            ReduceHealth(__damageData.Amount);
            onAttacked?.Invoke(__damageData);
        }

        public void IncreaseHealth(int amount)
        {
            if (_isFreezing) return;
            _currentHealth = Mathf.Clamp(_currentHealth += amount, 0, _healthData.maxHealth);
            onHeal?.Invoke();
        }

        public void ReduceHealth(int amount)
        {
            if (_isFreezing || _currentHealth == 0) return;
            _currentHealth = Mathf.Clamp(_currentHealth -= amount, 0, _healthData.maxHealth);
            onDamaged?.Invoke();
            if (_currentHealth == 0) onDead?.Invoke();
        }

        public void MaxHealth()
        {
            if (_isFreezing) return;
            _currentHealth = _healthData.maxHealth;
            onHeal?.Invoke();
        }

        public void Freeze(bool __freeze)
        {
            _isFreezing = __freeze;
        }
        #endregion
    }
}