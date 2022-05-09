using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraesonBergen
{
    public class PlayerSoundRequester : MonoBehaviour
    {
        [Header("Channels")]
        [SerializeField]
        AudioEvent_Channel _audioEvent_Channel;
        [SerializeField]
        AnimationEvent_Channel _footstep_Channel;
        [SerializeField]
        TakeDamage_Channel _playerTakeDamage_Channel;
        [SerializeField]
        BombExplosion_Channel _bombExplosion_Channel;

        [Header("SFX")]
        [SerializeField]
        AudioEventSO _footstepAudioSO;
        [SerializeField]
        AudioEventSO _playerHitAudioSO;
        [SerializeField]
        AudioEventSO _bombExplosionAudioSO;
       



        private void Awake()
        {
            _footstep_Channel.AnimationEvent += PlayFootstep;
            _playerTakeDamage_Channel.OnEventRaised += PlayPlayerHit;
            _bombExplosion_Channel.OnEventRaised += PlayBombExplosion;

        }

        public void PlayFootstep()
        {
            _audioEvent_Channel.RaiseEvent(_footstepAudioSO, transform.position);
        }

        public void PlayPlayerHit(int projectileID, int damage)
        {
            Debug.Log("Played player hit sound effect.");
            _audioEvent_Channel.RaiseEvent(_playerHitAudioSO, transform.position);
        }

        public void PlayBombExplosion(Vector3 position)
        {
            Debug.Log("Played bomb explosion sound effect.");
            _audioEvent_Channel.RaiseEvent(_bombExplosionAudioSO, position);
        }
    }
}
