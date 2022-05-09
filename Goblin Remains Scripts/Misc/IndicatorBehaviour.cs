using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraesonBergen
{
    public class IndicatorBehaviour : MonoBehaviour
    {
        
        public void ScheduleDeath(float lifespan)
        {
            Invoke(nameof(Die), lifespan);

        }

        private void Die()
        {
            Destroy(gameObject);

        }
    }
}
