using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GraesonBergen
{
    public class DebugHelper : MonoBehaviour
    {
        [SerializeField]
        GameObject[] _spawnPoints;
        [SerializeField]
        GameObject[] _enemies;
        [SerializeField]
        PlayerInputSO _playerInputSO;

        PlayerInput _playerInput;
        private bool _isDebug1Pressed;
        private int _randomSpawnPoint, _randomEnemy;


        private void Awake()
        {
            _playerInput = _playerInputSO.playerInput;
            _playerInput.Playing.Debug1.started += Debug1Input;
            _playerInput.Playing.Debug1.canceled += Debug1Input;
        }

        void Debug1Input(InputAction.CallbackContext context)
        {
            _isDebug1Pressed = context.ReadValueAsButton();
            if (_isDebug1Pressed)
            {
                Debug.Log("Spawned enemy.");
                SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            _randomSpawnPoint = Random.Range(0, _spawnPoints.Length);
            _randomEnemy = Random.Range(0, _enemies.Length);
            Instantiate(_enemies[_randomEnemy], _spawnPoints[_randomSpawnPoint].transform.position, Quaternion.identity);

        }
    }
}
