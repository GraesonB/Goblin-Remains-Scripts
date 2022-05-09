using UnityEngine;

namespace GraesonBergen
{
    public class MouseAim : MonoBehaviour
    {
        [SerializeField]
        LayerMask groundMask;
        [SerializeField]
        MousePositionSO mousePosition;

        private Camera mainCamera;
        


        // Start is called before the first frame update
        void Start()
        {
            mainCamera = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            Aim();
              
        }

        public (bool success, Vector3 position) GetMousePosition()
        {
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
            {
                return (success: true, position: hitInfo.point);
            }
            else
            {
                return (success: false, position: Vector3.zero);
            }
        }

        public void Aim()
        {
            var (success, position) = GetMousePosition();
            if (success)
            {
                mousePosition.SetMousePosition(position);

            }
        }
    }
}
