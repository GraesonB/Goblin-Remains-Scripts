using UnityEngine;

namespace GraesonBergen
{
    [CreateAssetMenu]
    public class WorldDataSO : ScriptableObject
    {
        [SerializeField] public float groundedGravity;
        [SerializeField] public float gravity;
    }
}