using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceApplierTrigger : MonoBehaviour
{
    [SerializeField] float _force;
    [SerializeField] Vector3 _direction;
    private void OnTriggerEnter(Collider other)
    {
        var rb = other.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.AddForce(_direction * _force, ForceMode.Impulse);
    }
}
