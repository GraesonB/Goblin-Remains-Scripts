using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GraesonBergen
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        public event Action playerTakesDamage;
        public event Action playerDies;
        public event Action playerCrit;
        public event Action enemyTakesDamage;
        public event Action playerOneHP;
        public event Action playerItemPickup;



        bool isPlaying = false;

        private void Awake()
        {
            instance = this;
        }

        private void Update()
        {

        }

        public void PlayerTakesDamage()
        {
            playerTakesDamage?.Invoke();
        }

        public void PlayerDies()
        {

            playerDies?.Invoke();
        }

        public void PlayerCrit()
        {
            playerCrit?.Invoke();

        }

        public void EnemyTakesDamage()
        {
            enemyTakesDamage?.Invoke();
        }

        public void PlayerOneHP()
        {
            playerOneHP?.Invoke();
        }

        public void PlayerItemPickup()
        {
            playerItemPickup?.Invoke();
        }

    }
}