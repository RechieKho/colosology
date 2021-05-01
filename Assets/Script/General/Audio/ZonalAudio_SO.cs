using UnityEngine;
using UnityEngine.Audio;

namespace General.Audio
{
    public class ZonalAudio_SO : ScriptableObject
    {
        public AudioMixerGroup mixerGroup;
        public ZonalAudioInfo[] minorAudios;
    }

    [System.Serializable]
    public class ZonalAudioInfo : AudioInfo
    {
        [Range(0f, 1f)]
        public float spatialBlend = 1f;
        public float minDistance = 1f;
        public float maxDistance = 500f;
        public float doppler = 1;
    }
}