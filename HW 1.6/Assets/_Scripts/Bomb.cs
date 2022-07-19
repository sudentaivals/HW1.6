using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] float _explosionRadius;
    [SerializeField] float _explosionForce;
    [SerializeField] LayerMask _unitsToExplode;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Explode()
    {
        var dummies = Physics.OverlapSphere(transform.position, _explosionRadius, _unitsToExplode);
        foreach (var dummy in dummies)
        {
            var dummyRb = dummy.GetComponent<Rigidbody>();
            dummyRb.isKinematic = false;
            float distanceBetweenDummyAndBomb = (dummy.transform.position - transform.position).magnitude;
            float force = Mathf.Lerp(_explosionForce, 0, distanceBetweenDummyAndBomb / _explosionRadius);
            Vector3 direction = (dummy.transform.position - transform.position).normalized;
            dummyRb.AddForce(direction * force, ForceMode.Impulse);
            Destroy(dummy.gameObject, Random.Range(3f, 7f));
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;

        Gizmos.DrawWireSphere(transform.position, _explosionRadius);
    }
}
