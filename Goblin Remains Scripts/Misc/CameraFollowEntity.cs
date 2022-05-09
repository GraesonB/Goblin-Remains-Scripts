using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraesonBergen
{
    public class CameraFollowEntity : MonoBehaviour
    {
        [SerializeField]
        Transform entity_transform;
        [SerializeField]
        MousePositionSO mousePosition;
        


        // Update is called once per frame
        void Update()
        {
            Vector3 currentPosition = transform.position;
            Vector3 playerMouseAvg = (entity_transform.position + (mousePosition.MousePosition/16));

            currentPosition.x += (playerMouseAvg.x - currentPosition.x) / 15;
            currentPosition.z += (playerMouseAvg.z - currentPosition.z) / 15;
            transform.position = currentPosition;
           

        }


    }
}
