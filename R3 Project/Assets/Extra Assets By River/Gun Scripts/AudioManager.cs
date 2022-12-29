using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;
using NeoFPS;

namespace River
{
    public class AudioManager : MonoBehaviour
    {
        [Foldout("Audio Stuff", true)]
        [SerializeField] private bool Enable;
        [SerializeField, ReadOnly] private AudioTimeScalePitchBend AudioPitchBlend;

        public static AudioManager instance;

        public static bool _UpdatePitchOnShoot;

        void Awake()
        {
            if(instance==null)instance = this;
        }
        public void Initialize()
        {
            _UpdatePitchOnShoot = Enable;
            if (_UpdatePitchOnShoot) 
            { 
                var _AudioPitchBlend = GameObject.FindObjectsOfType<AudioTimeScalePitchBend>();
                foreach(AudioTimeScalePitchBend a in _AudioPitchBlend)
                {
                    if(a.gameObject.name == "PlayerCameraSpring")
                    {
                        AudioPitchBlend = a;
                    }
                }
            }
            
        }

        public void UpdatePitch(float Pitch)
        {
            if (_UpdatePitchOnShoot) { AudioPitchBlend.OnTimeScaleChanged(Pitch); }
        }




    }
}
