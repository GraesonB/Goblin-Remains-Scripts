using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraesonBergen
{
    public class ProjectileSpawner : MonoBehaviour
    {
        [SerializeField]
        GameObject _projectile;
        [SerializeField]
        Transform _projectileOrigin;

        public Transform ProjectileOrigin  {get { return _projectileOrigin;  } }

        [SerializeField]
        private float _shootForce, _upwardForce, _spread;

        public void SpawnProjectile(Vector3 target)
        {
            Vector3 directionNoSpread = target - _projectileOrigin.position;
            float x_spread = Random.Range(-_spread, _spread);
            float z_spread = Random.Range(-_spread, _spread);
            Vector3 directionWithSpread = directionNoSpread + new Vector3(x_spread, 0, z_spread);
            directionWithSpread.Normalize();

            GameObject currentProjectile = Instantiate(_projectile, _projectileOrigin.position, Quaternion.identity);
            currentProjectile.transform.forward = directionWithSpread.normalized;
            currentProjectile.GetComponent<Rigidbody>().AddForce(directionWithSpread * _shootForce, ForceMode.Impulse);
            currentProjectile.GetComponent<Rigidbody>().AddForce(Vector3.up * _upwardForce, ForceMode.Impulse);

        }

    }
}
