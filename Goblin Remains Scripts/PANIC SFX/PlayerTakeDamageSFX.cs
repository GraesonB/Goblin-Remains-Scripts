using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraesonBergen
{
    public class PlayerTakeDamageSFX : MonoBehaviour
    {
        [SerializeField]
        AudioEventSO _damageSFX;

        [SerializeField]
        TakeDamage_Channel _channel;

        AudioSource _source;

        private void Awake()
        {
            _source = GetComponent<AudioSource>();
            _channel.OnEventRaised += PlaySound;
        }
        // Start is called before the first frame update

        void PlaySound(int a, int l)
        {
            _damageSFX.PlayClip(_source);
        }

        
    }
}
