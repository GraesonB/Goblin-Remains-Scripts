using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraesonBergen
{
    public class Music : MonoBehaviour
    {
        [SerializeField]
        AudioEventSO _music;

        AudioSource _source;

        private void Awake()
        {
            _source = GetComponent<AudioSource>();
        }

        private void Start()
        {
            _music.PlayClip(_source);
        }
        // Start is called before the first frame update


        
    }
}
