using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    private Camera _camera;
    private Rigidbody _rb;

    private Vector3 _direction;
    private bool _isSprinting;

    private GroundCheck _groundCheck;
    private bool _canDoubleJump;
    private bool _isJumping;

    private void Awake()
    {
        _camera = Camera.main;
        _rb = GetComponent<Rigidbody>();
        _groundCheck = GetComponentInChildren<GroundCheck>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _direction = _camera.transform.forward * vertical + _camera.transform.right * horizontal;
        _direction = _direction.normalized;
        _isSprinting = Input.GetKey(KeyCode.LeftShift);

        _isJumping = Input.GetButtonDown("Jump");
        if (_isJumping)
        {
            if (_groundCheck.IsGrounded)
            {
                Jump();
                _canDoubleJump = true;
            }
            else if (_canDoubleJump)
            {
                Jump();
                _canDoubleJump = false;
            }
        }
    }

    private void FixedUpdate()
    {
        Vector3 velocity;
        if (_isSprinting)
            velocity = _direction * _moveSpeed * 2;
        else
            velocity = _direction * _moveSpeed;
        _rb.velocity = new Vector3(velocity.x, _rb.velocity.y, velocity.z);

        float cameraRotationYAxis = _camera.transform.rotation.eulerAngles.y;
        Quaternion targetRotation = Quaternion.Euler(0, cameraRotationYAxis, 0);
        _rb.MoveRotation(targetRotation);
    }

    private void Jump()
    {
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        _isJumping = false;
    }

}
