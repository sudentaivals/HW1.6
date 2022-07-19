using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    [SerializeField] GameObject _sphere;
    [SerializeField] Transform _spawnPosition;
    [SerializeField] float _force;
    [SerializeField] Vector3 _direction;

    public void Spawn()
    {
        var sphere = Instantiate(_sphere);
        sphere.transform.position = _spawnPosition.position;
        sphere.GetComponent<Rigidbody>().AddForce(_direction * _force, ForceMode.Impulse);
        Destroy(sphere.gameObject, 5f);
    }
}
