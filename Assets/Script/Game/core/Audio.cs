using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using General.Data.Audio;
using General.Operation.Audio;

namespace Game.Core
{
    public static class Audio
    {
        public static AudioMixer audioMixer;

        private static IDictionary<string, MinorAudioController> _audioControllers = new Dictionary<string, MinorAudioController>();

        public static void InsertAudio(MinorAudioRegistry __registry, string __identifier)
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

        public static void UpdateAll()
        {
            UpdateBGM();
            UpdateEffect();
            UpdateMain();
        }

        public static void UpdateBGM()
        {
            if (audioMixer == null) return;
            audioMixer.SetFloat("BGMVolume", ToDB(Setting.BgmVolume));
        }

        public static void UpdateEffect()
        {
            if (audioMixer == null) return;
            audioMixer.SetFloat("EffectVolume", ToDB(Setting.EffectVolume));
        }

        public static void UpdateMain()
        {
            if (audioMixer == null) return;
            audioMixer.SetFloat("MainVolume", ToDB(Setting.MainVolume));
        }

        public static float ToDB(float vol) //vol: 0 - 1
        {
            return (1 - Mathf.Sqrt(vol)) * -80f;
        }
    }
}