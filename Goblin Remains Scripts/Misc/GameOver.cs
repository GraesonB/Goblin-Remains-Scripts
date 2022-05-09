using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GraesonBergen
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField]
        VoidEvent_Channel _playerDie_channel;
        [SerializeField]
        PlayerStatsSO _playerStats;

        private void Awake()
        {
            _playerDie_channel.OnEventRaised += EndGame;


        }

        void EndGame()
        {
            _playerStats.CurrentHealth = _playerStats.CurrentMaxHealth;
            SceneManager.LoadScene(2);
        }
    }
}
