using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject _dummy;
    [SerializeField] Transform _spawnPosition;
    [SerializeField] float _spawnRadius;

    private int _spawnsNumber = 10;

    public void SetNumberOfSpawns(int value)
    {
        _spawnsNumber = value;
    }

    public void SpawnObjects()
    {
        for (int i = 0; i < _spawnsNumber; i++)
        {
            var dummy = Instantiate(_dummy);
            dummy.transform.position = _spawnPosition.position + Random.insideUnitSphere * _spawnRadius;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(_spawnPosition.position, _spawnRadius);
    }

}
