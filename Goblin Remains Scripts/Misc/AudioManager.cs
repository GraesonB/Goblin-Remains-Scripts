using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraesonBergen
{
    public class AudioManager : MonoBehaviour
    {
        [Header("Audio Sources")]
        [SerializeField]
        private AudioSource _musicSource, _ambianceSource;

        [Header("SO Channels")]
        [SerializeField]
        public AudioEvent_Channel _music_Channel;

        [SerializeField]
        AudioEventSO music, ambiance;


        private void Awake()
        {
       
           
      
        }

    }
}