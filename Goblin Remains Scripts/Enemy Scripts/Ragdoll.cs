using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraesonBergen
{
    public class Ragdoll : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Invoke(nameof(Die), 5f);
        }

        
        void Die()
        {
            Destroy(gameObject);
        }
    }
}
