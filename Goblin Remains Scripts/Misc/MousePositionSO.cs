using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraesonBergen
{
    [CreateAssetMenu]
    public class MousePositionSO : ScriptableObject
    {
        private Vector3 _mousePosition;
        public Vector3 MousePosition { get { return _mousePosition;  } }

        public void SetMousePosition(Vector3 mousePosition)
        {
            _mousePosition = mousePosition;
        }
    }
}