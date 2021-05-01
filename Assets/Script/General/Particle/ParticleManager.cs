using System.Collections.Generic;
using UnityEngine;

namespace General.Particle
{
    #region Struct
    [System.Serializable]
    public struct ParticleInfo
    {
        public string name;
        public ParticleSystem particleSystem;
    }
    #endregion

    public class ParticleManager
    {
        

        #region Variable
        private IDictionary<string, ParticleSystem> particleSystems = new Dictionary<string, ParticleSystem>();
        #endregion

        public ParticleManager(ParticleInfo[] __particleInfos)
        {
            foreach (var particleInfo in __particleInfos)
            {
                AddParticleInfo(particleInfo);
            }
        }

        public void AddParticleInfo(ParticleInfo __particleInfo)
        {
            particleSystems.Add(__particleInfo.name, __particleInfo.particleSystem);
        }

        public void RemoveParticleInfo(string key)
        {
            // Checker
            if (!particleSystems.ContainsKey(key)) return;
            particleSystems.Remove(key);
        }

        public void Play(string key)
        {
            // Checker
            if (!particleSystems.ContainsKey(key)) return;
            particleSystems[key].Play();
        }

        public void Pause(string key)
        {
            // Checker
            if (!particleSystems.ContainsKey(key)) return;
            particleSystems[key].Pause();
        }

        public void Stop (string key)
        {
            // Checker
            if (!particleSystems.ContainsKey(key)) return;
            particleSystems[key].Stop();
        }
    }
}

