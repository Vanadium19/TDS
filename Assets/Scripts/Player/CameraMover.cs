using UnityEngine;

internal class CameraMover : MonoBehaviour
{
    [SerializeField] private float _absolutePositionX = 186f;
    [SerializeField] private float _absolutePositionZ = 142f;
    [SerializeField] private Transform _target;

    private Transform _transform;
    private Vector3 _position;
    private float _lagX;
    private float _lagZ;

    private void Awake()
    {
        _transform = transform;
        _lagX = _target.position.x - _transform.position.x;
        _lagZ = _target.position.z - _transform.position.z;
    }

    private void LateUpdate()
    {
        _position = new Vector3(_target.position.x - _lagX, _transform.position.y, _target.position.z - _lagZ);

        ClampPosition();

        _transform.position = _position;
    }

    private void ClampPosition()
    {
        _position.x = Mathf.Clamp(_position.x, -_absolutePositionX, _absolutePositionX);
        _position.z = Mathf.Clamp(_position.z, -_absolutePositionZ, _absolutePositionZ);
    }
}