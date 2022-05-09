using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GraesonBergen
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField]
        PlayerStatsSO _playerStats;

        Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        

        private void Update()
        {
            _slider.value = _playerStats.CurrentHealth;
        }
    }

}
