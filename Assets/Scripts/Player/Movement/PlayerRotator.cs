using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
internal class PlayerRotator : MonoBehaviour
{
    private readonly float _angleError = 2.5f;

    [SerializeField] private float _angularSpeed = 180f;

    private float _speed;
    private Camera _camera;
    private Transform _transform;
    private Rigidbody _rigidbody;
    private Vector3 _lookPosition;
    private float _cursorPositionZ;

    private void Awake()
    {
        _camera = Camera.main;
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
        _speed = Mathf.Deg2Rad * _angularSpeed;
        _cursorPositionZ = _camera.transform.position.y;
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        CalculateLookPosition();

        float angle = Vector3.SignedAngle(_transform.forward, _lookPosition, Vector3.up);

        if (Mathf.Abs(angle) <= _angleError)
            _rigidbody.angularVelocity = Vector3.zero;
        else
            _rigidbody.angularVelocity = angle > 0 ? Vector3.up * _speed : Vector3.down * _speed;
    }

    private void CalculateLookPosition()
    {
        var mousePosition = Input.mousePosition;

        var cursorPosition = new Vector3(mousePosition.x, mousePosition.y, _cursorPositionZ);
        cursorPosition = _camera.ScreenToWorldPoint(cursorPosition);

        cursorPosition.y = _transform.position.y;
        _lookPosition = (cursorPosition - _transform.position).normalized;
    }
}