using UnityEngine;

public class FPSCameraControl : MonoBehaviour
{

    [SerializeField] private Transform _target;
    [SerializeField] private float _topClamp = 90f;
    [SerializeField] private float _bottomClamp = -90f;

    private float _yaw;
    private float _pitch;
    private float _mouseSensitivity = 5f;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        transform.position = _target.position;
        transform.forward = _target.forward;

        PlayerPrefs.SetFloat("MouseSensitivity", _mouseSensitivity);
    }

    private void LateUpdate()
    {
        _yaw += Input.GetAxis("Mouse X") * _mouseSensitivity;
        _pitch -= Input.GetAxis("Mouse Y") * _mouseSensitivity;
        _pitch = Mathf.Clamp(_pitch, _bottomClamp, _topClamp);

        Quaternion rotation = Quaternion.Euler(_pitch, _yaw, 0);
        Vector3 desiredPosition = _target.position;
        transform.SetPositionAndRotation(desiredPosition, rotation);
    }

    public void UpdateMouseSensitivity(float sensitivity) => _mouseSensitivity = sensitivity;

}
