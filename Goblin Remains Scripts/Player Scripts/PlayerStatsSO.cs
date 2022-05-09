using UnityEngine;

namespace GraesonBergen
{
    [CreateAssetMenu]
    public class PlayerStatsSO : ScriptableObject
    {
        [SerializeField] int _baseMaxHealth;
        [SerializeField] float _baseMoveSpeed;
        [SerializeField] float _baseAttackSpeed;
        [SerializeField] float _baseMoveSpeedMod = 1f;
        [SerializeField] float _baseAttackSpeedMod = 1f;
        [SerializeField] float _baseRotationFactor = 15f;
        [SerializeField] float _bombSpecialCooldown = 8f;

        public int CurrentMaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public float BombSpecialCooldown { get { return _bombSpecialCooldown; } }
        public float CurrentMoveSpeed { get; set; }
        public float CurrentAttackSpeed { get; set; }
        public float CurrentMoveSpeedMod { get; set; }
        public float CurrentAttackSpeedMod { get; set; }
        public float CurrentRotationFactor { get; set; }


        private void OnEnable()
        {
            CurrentMaxHealth = _baseMaxHealth;
            CurrentHealth = _baseMaxHealth;
            CurrentMoveSpeed = _baseMoveSpeed * _baseMoveSpeedMod;
            CurrentAttackSpeed = _baseAttackSpeed * _baseAttackSpeedMod;
            CurrentMoveSpeedMod = _baseMoveSpeedMod;
            CurrentAttackSpeedMod = _baseAttackSpeedMod;
            CurrentRotationFactor = _baseRotationFactor;
        }

        public void UpdateMaxHealth(int changeInHealth)
        {
            CurrentMaxHealth += changeInHealth;
            CurrentHealth += changeInHealth;
        }

        public void UpdateCurrentHealth(int changeInHealth)
        {
            CurrentHealth += changeInHealth;
            if (CurrentHealth > CurrentMaxHealth)
                CurrentHealth = CurrentMaxHealth;
        }

        public void UpdateMoveSpeed(float changeInMoveSpeedMod)
        {
            CurrentMoveSpeedMod += changeInMoveSpeedMod;
            CurrentMoveSpeed = _baseMoveSpeed * CurrentMoveSpeedMod;
        }

        public void UpdateAttackSpeed(float changeInAttackSpeedMod)
        {
            CurrentAttackSpeedMod += changeInAttackSpeedMod;
            CurrentAttackSpeed = CurrentAttackSpeed * CurrentAttackSpeedMod;
        }



    }
}