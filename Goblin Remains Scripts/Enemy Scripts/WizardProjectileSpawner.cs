using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraesonBergen
{
    public class WizardProjectileSpawner : MonoBehaviour
    {
        [SerializeField]
        GameObject _projectile;
        [SerializeField]
        int _numberOfProjectiles;
        [SerializeField]
        float _angleStep, _radius, _castOffset, _timeOffset;
        [SerializeField]
        float _projectileY = 0.5f;
        

        float _angle, _plusAngle, _minusAngle;
        Vector3 _origin;
        Vector3 _zero = new Vector3(0, 0, 1);
       

        private void Awake()
        {
            _origin = gameObject.transform.position;
            _origin.y = _projectileY;
        }

        [SerializeField]
        private float _shootForce;

        public void Shotgun(Vector3 target, float offset)
        {
            _origin = gameObject.transform.position;
            _origin.y = _projectileY;
            Vector3 _directionToTarget = (target - _origin);
            _angle = Vector3.SignedAngle(_zero, _directionToTarget, Vector3.up);
            _angle += offset;

            GetDirectionAndFire(_angle);

            _plusAngle = _angle;
            _minusAngle = _angle;
            for (int i = 0; i < _numberOfProjectiles; i++)
            {
                _plusAngle += _angleStep;
                GetDirectionAndFire(_plusAngle);
                _minusAngle -= _angleStep;
                GetDirectionAndFire(_minusAngle);
            }
        }

        public void SpawnProjectile(Vector3 origin, Vector3 direction)
        {
            GameObject currentProjectile = Instantiate(_projectile, origin, Quaternion.identity);
            currentProjectile.transform.forward = direction.normalized;
            currentProjectile.GetComponent<Rigidbody>().velocity = new Vector3(direction.x, 0f, direction.z);
           
        }

        private void GetDirectionAndFire(float angle)
        {
            float projectileDirectionXposition = _origin.x + Mathf.Sin(angle * Mathf.PI / 180) * _radius;
            float projectileDirectionZposition = _origin.z + Mathf.Cos(angle * Mathf.PI / 180) * _radius;

            Vector3 projectileOrigin = new Vector3(projectileDirectionXposition, _projectileY, projectileDirectionZposition);

            Vector3 projectileVector = new Vector3(projectileDirectionXposition, 0, projectileDirectionZposition);
            Vector3 projectileDirection = (projectileVector - _origin).normalized * _shootForce;

            SpawnProjectile(projectileOrigin, projectileDirection);
            
        }

        //public IEnumerator FullCastCoroutine(Vector3 target)
        //{
        //    Shotgun(target, -_castOffset);
        //    yield return new WaitForSeconds(_timeOffset);
        //    Shotgun(target, 0f);
        //    yield return new WaitForSeconds(_timeOffset);
        //    Shotgun(target, _castOffset);
        //}
    }
}
