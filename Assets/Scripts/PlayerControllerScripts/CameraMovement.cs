using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    private Vector3 _offset;

    private RotationAxes _axes = RotationAxes.MouseXAndY;
    private float _sensitivityHor = 9.0f;
    private float _sensitivityVert = 9.0f;
    private float _minimumVert = -45.0f;
    private float _maximumVert = 45.0f;
    private float _rotationX = 0;   
    private enum RotationAxes 
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    private void Start()
    {
        _offset = transform.position - _playerTransform.position;

        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        body.freezeRotation = true;
    }
    private void Update() 
    {
        if (_axes == RotationAxes.MouseX) 
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * _sensitivityHor, 0);
        }
        else if (_axes == RotationAxes.MouseY) 
        {
            _rotationX -= Input.GetAxis("Mouse Y") * _sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, _minimumVert, _maximumVert);
            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else 
        {
            _rotationX -= Input.GetAxis("Mouse Y") * _sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, _minimumVert, _maximumVert);
            float delta = Input.GetAxis("Mouse X") * _sensitivityHor;
            float rotationY = transform.localEulerAngles.y + delta;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
    private void FixedUpdate()
    {
        transform.position = _playerTransform.position + _offset;
    }
}