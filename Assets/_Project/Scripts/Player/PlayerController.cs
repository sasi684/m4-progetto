using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _staminaRegenDelay;

    private Camera _camera;
    private Rigidbody _rb;

    private Vector3 _direction;
    private bool _isSprinting;

    private StaminaController _staminaController;
    private float _lastStaminaConsumed;

    private GroundCheck _groundCheck;
    private bool _canDoubleJump;
    private bool _isJumping;

    private void Awake()
    {
        _camera = Camera.main;
        _rb = GetComponent<Rigidbody>();
        _staminaController = GetComponent<StaminaController>();
        _groundCheck = GetComponentInChildren<GroundCheck>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _direction = _camera.transform.forward * vertical + _camera.transform.right * horizontal;
        _direction = _direction.normalized;

        if (CanConsumeStamina())
        {
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
        else
        {
            _isSprinting = false;
            _isJumping = false;
        }

        if (CanGainStamina())
            _staminaController.GainStamina(25f * Time.deltaTime);
        Debug.Log(_isSprinting);
    }

    private void FixedUpdate()
    {
        Vector3 velocity;
        if (_isSprinting)
        {
            _staminaController.ConsumeStamina(40f * Time.fixedDeltaTime);
            _lastStaminaConsumed = Time.time;

            velocity = _direction * _moveSpeed * 2;
        }
        else
        {
            velocity = _direction * _moveSpeed;
        }
        _rb.velocity = new Vector3(velocity.x, _rb.velocity.y, velocity.z);

        RotatePlayer();
    }

    private void Jump()
    {
        _staminaController.ConsumeStamina(30f);
        _lastStaminaConsumed = Time.time;

        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        _isJumping = false;
    }

    private void RotatePlayer()
    {
        float cameraRotationYAxis = _camera.transform.rotation.eulerAngles.y;
        Quaternion targetRotation = Quaternion.Euler(0, cameraRotationYAxis, 0);
        _rb.MoveRotation(targetRotation);
    }

    private bool CanGainStamina()
    {
        return Time.time - _lastStaminaConsumed > _staminaRegenDelay;
    }

    private bool CanConsumeStamina()
    {
        return _staminaController.GetCurrentStamina() > 0;
    }

}
