using UnityEngine;

public class FPSCameraControl : MonoBehaviour
{

    [SerializeField] private Transform _target;
    [SerializeField] private float _cameraSensibility;
    [SerializeField] private float _topClamp = 90f;
    [SerializeField] private float _bottomClamp = -90f;

    private float yaw;
    private float pitch;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        transform.position = _target.position;
        transform.forward = _target.forward;
    }

    private void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * _cameraSensibility;
        pitch -= Input.GetAxis("Mouse Y") * _cameraSensibility;
        pitch = Mathf.Clamp(pitch, _bottomClamp, _topClamp);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 desiredPosition = _target.position;
        transform.SetPositionAndRotation(desiredPosition, rotation);
    }

}
