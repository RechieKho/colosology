using System;
using UnityEngine.Audio;
using UnityEngine;

namespace General.Audio
{
    public class ZonalAudioManager
    {
        #region Variable
        private AudioMixerGroup _mixerGroup;
        public  ZonalAudioInfo audioInfo;
        private AudioSource _audioSource;
        private GameObject _gameObject;
        #endregion

        #region Method
        // Constructor
        public ZonalAudioManager(ZonalAudio_SO registry, string name, GameObject __gameObject)
        {
            _gameObject = __gameObject;
            AssignAudio(registry, name);
        }

        #region manage Audio Info
        public void AssignAudio(ZonalAudio_SO registry, string name)
        {
            // assign mixer group
            _mixerGroup = registry.mixerGroup;

            // Find registry have the audio or not
            ZonalAudioInfo locatedAudioInfo = Array.Find(registry.minorAudios, minorAudio => minorAudio.name == name);
            if (locatedAudioInfo == null) Debug.LogError($"Audio selected ({name}) is not available in the registry, please set audioInfo again...");
            else
            {
                audioInfo = locatedAudioInfo;
                AddAudioSource();
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

            RemoveAudioSource();
        }

        public void SetVolume(float newVolume)
        {
            if (isAudioNull) return;
            audioInfo.volume = newVolume;
            UpdateAudioSource();
        }

        public void SetPitch(float newPitch)
        {
            if (isAudioNull) return;
            audioInfo.pitch = newPitch;
            UpdateAudioSource();
        }

        public void SetLoop(bool loop)
        {
            if (isAudioNull) return;
            audioInfo.loop = loop;
            UpdateAudioSource();
        }

        public void SetSpatialBlend(float newSpatialBlend)
        {
            if (isAudioNull) return;
            audioInfo.spatialBlend = newSpatialBlend;
            UpdateAudioSource();
        }

        public void SetMinDistance(float newMinDistance)
        {
            if (isAudioNull) return;
            audioInfo.minDistance = newMinDistance;
            UpdateAudioSource();
        }

        public void SetMaxDistance(float newMaxDistance)
        {
            if (isAudioNull) return;
            audioInfo.maxDistance = newMaxDistance;
            UpdateAudioSource();
        }

        public void SetDoppler(float newDoppler)
        {
            if (isAudioNull) return;
            audioInfo.doppler = newDoppler;
            UpdateAudioSource();
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
            _audioSource.Play();
        }

        public void PauseAudio()
        {
            // check whether audio info is null
            if (isAudioNull)
            {
                Debug.LogError("AUDIO INFO IS NOT ASSIGNED!!!");
                return;
            }
            _audioSource.Pause();
        }

        public void UnpauseAudio()
        {
            // check whether audio info is null
            if (isAudioNull)
            {
                Debug.LogError("AUDIO INFO IS NOT ASSIGNED!!!");
                return;
            }
            _audioSource.UnPause();
        }

        public void StopAudio()
        {
            // check whether audio info is null
            if (isAudioNull)
            {
                Debug.LogError("AUDIO INFO IS NOT ASSIGNED!!!");
                return;
            }
            _audioSource.Stop();
        }
        #endregion

        #region AudioSource Controller
        private void AddAudioSource()
        {
            // create AudioSource
            if(_audioSource == null)
            {
                _audioSource = _gameObject.AddComponent<AudioSource>();
            }

            _audioSource.enabled = false;
            UpdateAudioSource();
            _audioSource.enabled = true;
        }

        private void RemoveAudioSource()
        {
            // check whether AudioSource exist
            if (_audioSource == null) return;

            UnityEngine.Object.Destroy(_audioSource);
        }

        private void UpdateAudioSource()
        {
            // check is AudioSource exist
            if (_audioSource == null) return;

            // Assign ValuesAudio
            _audioSource.clip = audioInfo.audio;
            _audioSource.playOnAwake = audioInfo.playOnAwake;
            _audioSource.loop = audioInfo.loop;
            _audioSource.volume = audioInfo.volume;
            _audioSource.pitch = audioInfo.pitch;
            _audioSource.outputAudioMixerGroup = _mixerGroup;
            _audioSource.spatialBlend = audioInfo.spatialBlend;
            _audioSource.minDistance = audioInfo.minDistance;
            _audioSource.maxDistance = audioInfo.maxDistance;
            _audioSource.dopplerLevel = audioInfo.doppler;
        }
        #endregion

        #endregion

        #region Properties
        public bool isAudioNull { get { return audioInfo == null; } }
        #endregion
    }
}
