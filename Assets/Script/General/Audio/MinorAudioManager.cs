using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace General.Audio
{
    public class MinorAudioManager : MonoBehaviour
    {
        #region Variable
        private static MinorAudioManager singleton;

        public IDictionary<MinorAudioController, AudioSource> audioSources = new Dictionary<MinorAudioController, AudioSource>();
        #endregion

        #region Method

        #region Manage Audio Source
        public static void AddAudioSource(MinorAudioController audioController)
        {
            // init singleton
            if(singleton == null)
            {
                singleton = new GameObject("AudioManager").AddComponent<MinorAudioManager>();
                DontDestroyOnLoad(singleton.gameObject);
            }

            // check whether AudioController is registered
            if (IsAudioRegistryExist(audioController)) return;
            else
            {
                // register audioController
                singleton.audioSources.Add(audioController, singleton.gameObject.AddComponent<AudioSource>());
                singleton.audioSources[audioController].enabled = false; // I am afraid that audio source will active before setting the values
                UpdateAudioSource(audioController);
                singleton.audioSources[audioController].enabled = true; // make it active
            }
        }

        public static void RemoveAudioSource(MinorAudioController audioController)
        {
            // check whether singleton exist
            if (singleton == null) return;

            if (IsAudioRegistryExist(audioController))
            {
                // remove audio source
                Destroy(singleton.audioSources[audioController]);
                singleton.audioSources.Remove(audioController);
            }
        }

        public static bool IsAudioRegistryExist(MinorAudioController audioController)
        {
            if (singleton == null) return false;
            else return singleton.audioSources.ContainsKey(audioController);
        }

        public static void UpdateAudioSource(MinorAudioController audioController)
        {
            // check whether singleton exist
            if (singleton == null) return;

            // Assign values
            AudioSource source = singleton.audioSources[audioController];
            source.clip = audioController.audioInfo.audio;
            source.playOnAwake = audioController.audioInfo.playOnAwake;
            source.loop = audioController.audioInfo.loop;
            source.volume = audioController.audioInfo.volume;
            source.pitch = audioController.audioInfo.pitch;
            source.outputAudioMixerGroup = audioController.mixerGroup;
        }
        #endregion

        #region Audio Player
        public static void PlayAudio(MinorAudioController audioController)
        {
            if (!IsAudioRegistryExist(audioController)) return;
            singleton.audioSources[audioController].Play();
        }

        public static void PauseAudio(MinorAudioController audioController)
        {
            if (!IsAudioRegistryExist(audioController)) return;
            singleton.audioSources[audioController].Pause();
        }

        public static void UnpauseAudio(MinorAudioController audioController)
        {
            if (!IsAudioRegistryExist(audioController)) return;
            singleton.audioSources[audioController].UnPause();
        }

        public static void StopAudio(MinorAudioController audioController)
        {
            if (!IsAudioRegistryExist(audioController)) return;
            singleton.audioSources[audioController].Stop();
        }
        #endregion

        #endregion
    }

    public class MinorAudioController
    {
        #region Variable
        public AudioMixerGroup mixerGroup;
        public AudioInfo audioInfo;
        #endregion

        #region Method
        public MinorAudioController(MinorAudio_SO registry, string name)
        {
            AssignAudio(registry, name);
        }

        #region manage Audio Info
        public void AssignAudio(MinorAudio_SO registry, string name)
        {
            // assign mixer group
            mixerGroup = registry.mixerGroup;

            // Find registry have the audio or not
            AudioInfo locatedAudioInfo = Array.Find(registry.minorAudios, minorAudio => minorAudio.name == name);
            if (locatedAudioInfo == null) Debug.LogError($"Audio selected ({name}) is not available in the registry, please set audioInfo again...");
            else
            {
                audioInfo = locatedAudioInfo;
                MinorAudioManager.AddAudioSource(this);
            }
        }

        public void ClearAudio()
        {
            // check whether audio info is null
            if (isAudioNull)
            {
                Debug.LogError("AUDIO INFO IS NOT ASSIGNED!!!");
                return;
            }
            MinorAudioManager.RemoveAudioSource(this);
        }

        public void SetVolume(float newVolume)
        {
            if (isAudioNull) return;
            audioInfo.volume = newVolume;
            MinorAudioManager.UpdateAudioSource(this);
        }

        public void SetPitch(float newPitch)
        {
            if (isAudioNull) return;
            audioInfo.pitch = newPitch;
            MinorAudioManager.UpdateAudioSource(this);
        }

        public void SetLoop(bool loop)
        {
            if (isAudioNull) return;
            audioInfo.loop = loop;
            MinorAudioManager.UpdateAudioSource(this);
        }
        #endregion

        #region Audio Player
        public void PlayAudio()
        {
            // check whether audio info is null
            if (isAudioNull)
            {
                Debug.LogError("AUDIO INFO IS NOT ASSIGNED!!!");
                return;
            }
            MinorAudioManager.PlayAudio(this);
        }

        public void PauseAudio()
        {
            // check whether audio info is null
            if (isAudioNull)
            {
                Debug.LogError("AUDIO INFO IS NOT ASSIGNED!!!");
                return;
            }
            MinorAudioManager.PauseAudio(this);
        }

        public void UnpauseAudio()
        {
            // check whether audio info is null
            if (isAudioNull)
            {
                Debug.LogError("AUDIO INFO IS NOT ASSIGNED!!!");
                return;
            }
            MinorAudioManager.UnpauseAudio(this);
        }

        public void StopAudio()
        {
            // check whether audio info is null
            if (isAudioNull)
            {
                Debug.LogError("AUDIO INFO IS NOT ASSIGNED!!!");
                return;
            }
            MinorAudioManager.StopAudio(this);
        }
        #endregion

        #endregion

        #region Properties
        public bool isAudioNull { get { return audioInfo == null; } }
        #endregion
    }
}

// NOTE: As long as you successfully instanciate a controller, the audio will played if the play on awake is checked
// NOTE: The forbidden thing is to instanciate controller MULTIPLE TIME without DELETING THE AUDIO SOURCE (please don't do stupid stuff)