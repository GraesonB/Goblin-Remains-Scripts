using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraesonBergen
{
    public class BombSFX : MonoBehaviour
    {
        [SerializeField]
        AudioEventSO _bombSound;

        [SerializeField]
        BombExplosion_Channel _channel;

        AudioSource _source;

        private void Awake()
        {
            _source = GetComponent<AudioSource>();
            _channel.OnEventRaised += PlaySound;
        }
        // Start is called before the first frame update

        void PlaySound(Vector3 yup)
        {
            _bombSound.PlayClip(_source);
        }

        
    }
}
