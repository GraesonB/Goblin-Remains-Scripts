using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraesonBergen
{
    public class Ambiance : MonoBehaviour
    {
        [SerializeField]
        AudioEventSO _ambiance;

        AudioSource _source;

        private void Awake()
        {
            _source = GetComponent<AudioSource>();
        }

        private void Start()
        {
            _ambiance.PlayClip(_source);
        }
        // Start is called before the first frame update


        
    }
}
