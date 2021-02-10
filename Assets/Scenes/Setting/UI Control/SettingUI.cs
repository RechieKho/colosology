using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using General.Data.Scene;
using General.Operation.Scene;
using Game.Core;

namespace Scene.UI
{
    public class SettingUI : MonoBehaviour
    {
        public Slider main;
        public Slider effect;
        public Slider bgm;
        public Slider detail;

        private void Start()
        {
            main.value = Setting.MainVolume;
            effect.value = Setting.EffectVolume;
            bgm.value = Setting.BgmVolume;
            detail.value = Setting.Detail;
        }


        public SceneTransData sceneTransition;
        public void ToMenu() //  Back button
        {
            Setting.SaveData();
            QualitySettings.SetQualityLevel(Mathf.RoundToInt(Setting.Detail * 6), false);
            SceneDirector.LoadScene("Menu", sceneTransition);
        }

        public void SetMainVolume() // Main Sound
        {
            Setting.MainVolume = main.value;
            Audio.UpdateMain();
        }

        public void SetEffectVolume() // Effect Sound
        {
            Setting.EffectVolume = effect.value;
            Audio.UpdateEffect();
        }

        public void SetBgmVolume() // BGM Sound
        {
            Setting.BgmVolume = bgm.value;
            Audio.UpdateBGM();
        }

        public void SetDetail()
        {
            Setting.Detail = detail.value;
        }
    }

}
