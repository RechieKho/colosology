using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;

namespace Game.Core
{
    public static class Setting
    {
        private static float _mainVolume; 
        private static float _effectVolume;
        private static float _bgmVolume;

        private static float _detail; 

        #region Method
        // static methods
        public static void LoadData() // load data from saved file
        {
            _mainVolume = SaveGame.Load<float>("_mainVolume", 1);
            _effectVolume = SaveGame.Load<float>("_effectVolume", 1);
            _bgmVolume = SaveGame.Load<float>("_bgmVolume", 1);

            _detail = SaveGame.Load<float>("_detail", 1);
        }

        public static void SaveData() // save data to saved file
        {
            SaveGame.Save<float>("_mainVolume", _mainVolume);
            SaveGame.Save<float>("_effectVolume", _effectVolume);
            SaveGame.Save<float>("_bgmVolume", _bgmVolume);

            SaveGame.Save<float>("_detail", _detail);
        }
        #endregion

        #region Properties
        public static float MainVolume { get { return _mainVolume; } set { _mainVolume = value; } }
        public static float EffectVolume { get { return _effectVolume; } set { _effectVolume = value; } }
        public static float BgmVolume { get { return _bgmVolume; } set { _bgmVolume = value; } }
        
        public static float Detail { get { return _detail; } set { _detail = value; } }
        #endregion
    }
}