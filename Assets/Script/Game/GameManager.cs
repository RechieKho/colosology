using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    public class GameManager : MonoBehaviour
    {
        #region Variable
        private static GameManager _singleton;
        #endregion

        #region Method
        #region MonoBehaviour
        // Start is called before the first frame update
        void Start()
        {
            #region Create Singleton
            if(_singleton == null)
            {
                // assuming script is attach on some unknown object
                // create singleton
                InitOnce();
                // remove itself from gameObject
                Destroy(this);
            }
            #endregion
        }

        // Update is called once per frame
        void Update()
        {

        }
        #endregion

        // singleton
        private static void InitOnce()
        {
            if(_singleton == null)
            {
                _singleton = new GameObject("GameManager").AddComponent<GameManager>();
                DontDestroyOnLoad(_singleton);
            }
        }

        #endregion
    }
}
