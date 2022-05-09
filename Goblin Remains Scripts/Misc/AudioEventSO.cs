using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GraesonBergen
{
    [CreateAssetMenu]
    public class AudioEventSO : ScriptableObject
    {
        [SerializeField]
        MasterSoundSO _masterSoundSO;
        public AudioClip[] audioClips;

        [Header("Volume")]
        [SerializeField]
        float _volumeRange;
        [Range(0f,1f)]
        public float volume;

        [Header("Pitch")]
        [SerializeField]
        float _pitchRange;
        [Range(0f,2f)]
        public float pitch, useless;

        public void PlayClip(AudioSource source)
        {
            if (audioClips.Length == 0) return;

            source.clip = audioClips[Random.Range(0, audioClips.Length)];
            source.volume = Random.Range(volume -_volumeRange, volume + _volumeRange) * _masterSoundSO.masterVolume;
            source.pitch = Random.Range(pitch - _pitchRange, pitch + _pitchRange);
            source.Play();
            
        }



    }
}