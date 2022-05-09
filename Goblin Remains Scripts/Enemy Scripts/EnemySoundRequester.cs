using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraesonBergen
{
    public class EnemySoundRequester : MonoBehaviour
    {
        [SerializeField]
        AudioEvent_Channel _audioEvent_Channel;
        [SerializeField]
        AnimationEvent_Channel _footstep_Channel;
        
        

        //[SerializeField]
        //AudioEventSO _footstepAudioSO;
        [SerializeField]
        AudioEventSO _enemyHitAudioSO;



        private void Awake()
        {
            //_footstep_Channel.AnimationEvent += PlayFootstep;
        }

        public void PlayFootstep()
        {
            //_audioEvent_Channel.RaiseEvent(_footstepAudioSO, transform.position);
        }

        public void PlayEnemyHit()
        {
            Debug.Log("Played enemy hit sound effect.");
            _audioEvent_Channel.RaiseEvent(_enemyHitAudioSO, transform.position);
        }
    }
}
