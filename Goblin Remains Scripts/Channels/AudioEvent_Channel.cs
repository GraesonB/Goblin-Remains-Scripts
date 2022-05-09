using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GraesonBergen
{
    [CreateAssetMenu]
    public class AudioEvent_Channel : ScriptableObject
    {
        public UnityAction<AudioEventSO, Vector3> OnAudioClipRequested;

        public void RaiseEvent(AudioEventSO audioEventSO, Vector3 position)
        {
            if (OnAudioClipRequested != null)
                OnAudioClipRequested.Invoke(audioEventSO, position);
        }

    }
}