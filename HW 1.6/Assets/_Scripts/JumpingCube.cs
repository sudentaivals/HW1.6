using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingCube : MonoBehaviour
{
    [SerializeField] float _groundCheckerRadius;
    [SerializeField] Vector3 _groundCheckerOffset;
    [SerializeField] LayerMask _groundMask;
    [SerializeField] float _jumpForce;

    private Collider[] _groundCollision = new Collider[1];
    private bool _jumpAvailable = true;
    private bool IsCubeOnGround => Physics.OverlapSphereNonAlloc(transform.position + _groundCheckerOffset, _groundCheckerRadius, _groundCollision, _groundMask) > 0;

    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (_jumpAvailable && Input.GetButtonDown("Jump") && IsCubeOnGround)
        {
            Jump();
        }
    }

    private void Jump()
    {
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        StartCoroutine(JumpCooldown());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position + _groundCheckerOffset, _groundCheckerRadius);
    }

    private IEnumerator JumpCooldown()
    {
        _jumpAvailable = false;
        yield return new WaitForSeconds(0.5f);
        _jumpAvailable = true;
    }
}
