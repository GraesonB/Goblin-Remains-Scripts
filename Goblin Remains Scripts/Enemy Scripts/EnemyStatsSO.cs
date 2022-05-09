using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraesonBergen
{
    [CreateAssetMenu]
    public class EnemyStatsSO : ScriptableObject
    {
        [SerializeField] int baseMaxHealth;
        [SerializeField] float baseMoveSpeed;
        [SerializeField] float baseAttackSpeed;
        [SerializeField] float baseMoveSpeedMod = 1f;
        [SerializeField] float baseAttackSpeedMod = 1f;
        [SerializeField] float baseRotationFactor = 15f;

        public int CurrentMaxHealth { get; private set; }
        public int CurrentHealth { get; private set; }
        public float CurrentMoveSpeed { get; private set; }
        public float CurrentAttackSpeed { get; private set; }
        public float CurrentMoveSpeedMod { get; private set; }
        public float CurrentAttackSpeedMod { get; private set; }
        public float CurrentRotationFactor { get; private set; }


        private void OnEnable()
        {
            CurrentMaxHealth = baseMaxHealth;
            CurrentHealth = baseMaxHealth;
            CurrentMoveSpeed = baseMoveSpeed * baseMoveSpeedMod;
            CurrentAttackSpeed = baseAttackSpeed * baseAttackSpeedMod;
            CurrentMoveSpeedMod = baseMoveSpeedMod;
            CurrentAttackSpeedMod = baseAttackSpeedMod;
            CurrentRotationFactor = baseRotationFactor;
        }

        void UpdateMaxHealth(int changeInHealth)
        {
            CurrentMaxHealth += changeInHealth;
        }

        void UpdateCurrentHealth(int changeInHealth)
        {
            CurrentHealth += changeInHealth;
            if (CurrentHealth > CurrentMaxHealth)
                CurrentHealth = CurrentMaxHealth;
        }

        void UpdateMoveSpeed(float changeInMoveSpeedMod)
        {
            CurrentMoveSpeedMod += changeInMoveSpeedMod;
            CurrentMoveSpeed = CurrentMoveSpeed * CurrentMoveSpeedMod;
        }

        void UpdateAttackSpeed(float changeInAttackSpeedMod)
        {
            CurrentAttackSpeedMod += changeInAttackSpeedMod;
            CurrentAttackSpeed = CurrentAttackSpeed * CurrentAttackSpeedMod;
        }
    }
}