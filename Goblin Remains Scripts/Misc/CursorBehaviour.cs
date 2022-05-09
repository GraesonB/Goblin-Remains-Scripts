using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraesonBergen
{
    public class CursorBehaviour : MonoBehaviour
    {
        [SerializeField]
        MousePositionSO _mousePositionSO;
        [SerializeField]
        VoidEvent_Channel _specialHold;
        [SerializeField]
        GameObject _bombRangeIndicator;
        [SerializeField]
        float _indicatorYOffset;

        Vector3 _cursorIndicatorPosition;
        bool _indicatorActive;

        private void Awake()
        {
            _specialHold.OnEventRaised += BombRangeIndicatorEnable;
            _specialHold.OnEventCanceled += BombRangeIndicatorDisable;
        }

        private void Update()
        {
            if (_indicatorActive)
                UpdateIndicatorPositions();
           
        }

        private void BombRangeIndicatorEnable()
        {
            _indicatorActive = true;
            _bombRangeIndicator.SetActive(true);
        }

        private void BombRangeIndicatorDisable()
        {
            _indicatorActive = false;
            _bombRangeIndicator.SetActive(false);
        }

        private void UpdateIndicatorPositions()
        {
            _cursorIndicatorPosition = _mousePositionSO.MousePosition;
            _cursorIndicatorPosition.y = _indicatorYOffset;
            _bombRangeIndicator.transform.position = _cursorIndicatorPosition;
        }
    }
}
