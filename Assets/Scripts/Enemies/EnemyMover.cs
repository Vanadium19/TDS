using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;

    private Transform _transform;
    private Rigidbody _rigidbody;
    private Vector3 _direction;

    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _direction = Vector3.ProjectOnPlane(_target.position - _transform.position, Vector3.up).normalized;

        _rigidbody.velocity = _direction * _speed + Vector3.up * _rigidbody.velocity.y;
    }
}