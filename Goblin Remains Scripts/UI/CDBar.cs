using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GraesonBergen
{
    public class CDBar : MonoBehaviour
    {
        [SerializeField]
        VoidEvent_Channel _bombThrow_Channel;
        [SerializeField]
        PlayerStatsSO _playerStats;
        [SerializeField]
        GameObject _readyBar;

        Slider _slider;
        float _timePassed;

        private void Awake()
        {
            _bombThrow_Channel.OnEventRaised += PutOnCooldown;
            _slider = GetComponent<Slider>();
            _slider.maxValue = _playerStats.BombSpecialCooldown;
            _slider.minValue = 0;
            _readyBar.SetActive(true);
        }

        void PutOnCooldown()
        {
            StartCoroutine(CooldownCoroutine());
        }

        IEnumerator CooldownCoroutine()
        {
            _readyBar.SetActive(false);
            _timePassed = 0;

            while (_timePassed < _playerStats.BombSpecialCooldown)
            {

                _timePassed += Time.deltaTime;
                _slider.value = _timePassed;
                yield return null;
            }

            _readyBar.SetActive(true);
        }
    }
}
