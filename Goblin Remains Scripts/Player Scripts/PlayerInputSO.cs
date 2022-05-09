using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraesonBergen
{
    [CreateAssetMenu]
    public class PlayerInputSO : ScriptableObject
    {
        public PlayerInput playerInput;
        private void OnEnable()
        {
            playerInput = new PlayerInput();
        }
    }
}
