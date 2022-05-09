using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraesonBergen
{
    public class Lob : MonoBehaviour
    {
        [SerializeField]
        GameObject _projectile;
        [SerializeField]
        Transform _projectileOrigin;
        [SerializeField]
        float _time;
       
        private float _torqueFloat1, _torqueFloat2, _torqueFloat3;

        public Transform ProjectileOrigin  {get { return _projectileOrigin;  } }

        public void LobIt(Vector3 target)
        {
            Vector3 direction = target - _projectileOrigin.position;
           

            GameObject currentProjectile = Instantiate(_projectile, _projectileOrigin.position, Quaternion.identity);
            currentProjectile.transform.forward = direction;
            Vector3 velocity = CalculateVelocity(target, _projectileOrigin.position, _time);
            currentProjectile.GetComponent<Rigidbody>().velocity = velocity;

            _torqueFloat1 = Random.Range(-30f, 30f);
            _torqueFloat2 = Random.Range(-30f, 30f);
            _torqueFloat3 = Random.Range(-30f, 30f);
            Vector3 _torque = new Vector3(_torqueFloat1, _torqueFloat2, _torqueFloat3);
            currentProjectile.GetComponent<Rigidbody>().AddTorque(_torque);
        }

        public Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
        {
            Vector3 distance = target - origin;
            Vector3 distanceXZ = distance;
            distanceXZ.y = 0f;

            // create float that represents distance
            float distY = distance.y;
            float distXZ = distanceXZ.magnitude;

            float velocityXZ = distXZ / time;
            float velocityY = distY / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

            Vector3 velocity = distanceXZ.normalized;
            velocity *= velocityXZ;
            velocity.y = velocityY;

            return velocity;

        }

    }
}
