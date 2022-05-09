using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraesonBergen
{
    public class FootSFX : MonoBehaviour
    {
        [SerializeField]
        AudioEventSO _footsteps;

        [SerializeField]
        AnimationEvent_Channel _channel;

        AudioSource _source;

        private void Awake()
        {
            _source = GetComponent<AudioSource>();
            _channel.AnimationEvent += PlaySound;
        }
        // Start is called before the first frame update

        void PlaySound()
        {
            _footsteps.PlayClip(_source);
        }

        
    }
}
