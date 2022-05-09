using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GraesonBergen
{
    public class WaveSpawner : MonoBehaviour
    {
        public enum SpawnState {spawning, waiting, counting};
        [SerializeField]
        public TextMeshProUGUI _text;

        [System.Serializable]
        public class Wave
        {
            public string name;
            public Transform[] enemy;
            public int count;
            public float rate;
        }

        public Wave[] waves;
        private int _nextWave = 0;

        public Transform[] spawnPoints;

        public float _timeBetweenWaves = 5f;
        private float _waveCountdown = 0f;
        private float _searchCountdown = 1;

        private SpawnState state = SpawnState.counting;

        private void Start()
        {
            _waveCountdown = _timeBetweenWaves;

        }

        private void Update()
        {
            if (state == SpawnState.waiting)
            {
                if (!EnemyIsAlive())
                {
                    WaveCompleted();
                }
                else
                {
                    return;
                }
            }

            if (_waveCountdown <= 0 && state != SpawnState.spawning)
            {
                _text.text = waves[_nextWave].name;
                Debug.Log("STARTING: " + waves[_nextWave].name);
                StartCoroutine(SpawnWave(waves[_nextWave]));
            }
            else
            {
                _waveCountdown -= Time.deltaTime;
            }
        }

        IEnumerator SpawnWave(Wave wave)
        {
            state = SpawnState.spawning;

            for (int i = 0; i < wave.count; i++)
            {
                SpawnEnemy(wave.enemy[Random.Range(0, wave.enemy.Length)]);
                yield return new WaitForSeconds(1f / wave.rate);
            }

            state = SpawnState.waiting;
            yield break;
        }

        void SpawnEnemy(Transform _enemy)
        {
            Transform _spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(_enemy, _spawnPoint.position, Quaternion.identity);
        }

        bool EnemyIsAlive()
        {
            _searchCountdown -= Time.deltaTime;
            if (_searchCountdown <= 0f)
            {
                _searchCountdown = 1f;
                if (GameObject.FindGameObjectWithTag("Enemy") == null)
                {
                    return false;
                }
            }
            return true;
            

        }

        void WaveCompleted()
        {
            state = SpawnState.counting;
            _waveCountdown = _timeBetweenWaves;
            if (_nextWave + 1 > waves.Length -1)
            {
                _nextWave = 0;
            }
            else
            {
                _nextWave++;
            }
        }
    }
}
