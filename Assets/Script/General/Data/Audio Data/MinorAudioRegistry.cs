using UnityEngine.Audio;
using UnityEngine;
using System.Collections.Generic;

/**
 * This SO saves all minor audio clips and its properties
 * **PS: minor audio means background audio stuff
 */
namespace General.Data.Audio
{
    public class MinorAudioRegistry : ScriptableObject
    {
        public AudioMixerGroup mixerGroup;
        public AudioInfo[] minorAudios;
    }

    [System.Serializable]
    public class AudioInfo
    {
        public string name;
        public AudioClip audio;
        public bool playOnAwake;
        public bool loop;
        [Range(0f, 1f)]
        public float volume = 1;
        [Range(-3f, 3f)]
        public float pitch = 1;
    }
}