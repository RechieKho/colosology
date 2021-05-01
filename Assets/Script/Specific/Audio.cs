using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using General.Audio;

namespace Specific
{
    public static class Audio
    {
        public static AudioMixer audioMixer;

        private static IDictionary<string, MinorAudioController> _audioControllers = new Dictionary<string, MinorAudioController>();

        public static void InsertAudio(MinorAudio_SO __registry, string __identifier)
        {
            MinorAudioController audioController = new MinorAudioController(__registry, __identifier);
            if (!audioController.isAudioNull) _audioControllers.Add(__identifier, audioController);
        }

        public static MinorAudioController GetController(string __identifier)
        {
            return _audioControllers.ContainsKey(__identifier)?_audioControllers[__identifier]:null;
        }

        public static void SetAudioMixer(AudioMixer __audioMixer)
        {
            audioMixer = __audioMixer;
        }

        #region Updator
        public static void UpdateAll()
        {
            UpdateBGM();
            UpdateEffect();
            UpdateMain();
        }
        
        public static void UpdateBGM()
        {
            if (audioMixer == null) return;
            audioMixer.SetFloat("BGMVolume", ToDB(Setting.bgmVolume.value));
        }

        public static void UpdateEffect()
        {
            if (audioMixer == null) return;
            audioMixer.SetFloat("EffectVolume", ToDB(Setting.effectVolume.value));
        }

        public static void UpdateMain()
        {
            if (audioMixer == null) return;
            audioMixer.SetFloat("MainVolume", ToDB(Setting.mainVolume.value));
        }
        #endregion

        private static float ToDB(float vol) //vol: 0 - 1; To decible
        {
            return (1 - Mathf.Sqrt(vol)) * -80f;
        }
    }
}