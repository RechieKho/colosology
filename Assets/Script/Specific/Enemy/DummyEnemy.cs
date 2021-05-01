using General.Health;
using UnityEngine;

namespace Specific.Enemy
{
    public class DummyEnemy : MonoBehaviour
    {
        public HealthSystem healthSystem;

        // Start is called before the first frame update
        void Start()
        {
            healthSystem.health.onAttacked += damage => {
                Debug.Log("Oof I got attacked");
            };
            healthSystem.health.onDead += () => {
                Debug.Log("I am dead");
            };
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

