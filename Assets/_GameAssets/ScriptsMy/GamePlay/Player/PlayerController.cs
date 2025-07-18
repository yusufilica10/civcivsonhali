using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [Header("Player Orientation Settings")]

    [SerializeField]   private Transform _oriantationobject;


    [Header("Player Movement Settings")]

    [SerializeField] private Rigidbody _playerrigidbody;

    [SerializeField] private KeyCode _movementkey;

    private Vector3 _MoveDirection;

    [SerializeField] private float _movementSpeed;

    float _horizontalInput , _verticalInput;
    
    
    [Header("playerr jumping settings")]
   
    [SerializeField] private KeyCode _jumpKey ;
 
    [SerializeField] private float _jumpForce;

    [SerializeField] private bool _canJump;

    [SerializeField] private float _JumpCooldown;

    [Header("Player Height Settings")]

    [SerializeField] private float _PlayerHeight;

    [SerializeField] private LayerMask _GroundLayer;

    [SerializeField] private float _groundDrag;


    [Header("Player Sliding Settings")]

    [SerializeField] private KeyCode _slidekey;

    [SerializeField] private float _slideMultiplier;

    [SerializeField] private bool _isslide;

    [SerializeField] private float _Slidedrag;





    private void Awake()
    {
        _playerrigidbody = GetComponent<Rigidbody>();
        _playerrigidbody.freezeRotation = true; 
    }

    private void Update()
    {

          SetInputs();
        SetPlayerDrag();
        PlayerSpeedLimit();
    }

    private void SetInputs()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(_slidekey))
        {

            _isslide = true;


        }
        else if (Input.GetKeyDown(_movementkey))
        {

            _isslide= false;

        }


        else if (Input.GetKeyDown(_jumpKey) && _canJump && ÝsGrounded())
        {
            _canJump = false;
            SetPlayerjump();
            Invoke(nameof(Resetjumping), _JumpCooldown);
        }



    }

    private void PlayerSpeedLimit()
    {
        Vector3 flatvelocity = new Vector3(_playerrigidbody.linearVelocity.x,0 , _playerrigidbody.linearVelocity.z);

         if(flatvelocity.magnitude > _movementSpeed)
        {
            Vector3 limitedvelocity = flatvelocity.normalized * _movementSpeed;
            _playerrigidbody.linearVelocity = new Vector3(limitedvelocity.x, _playerrigidbody.linearVelocity.y, limitedvelocity.z);

        }

    }



    private void FixedUpdate()
    {
        SetPlayerMovement();
    }


    private void SetPlayerDrag()
    {

        if(_isslide)
        {

            _playerrigidbody.linearDamping = _Slidedrag;

        }
        else
        {
            _playerrigidbody.linearDamping= _groundDrag;

        }
    }



    private void SetPlayerMovement()
    {

        _MoveDirection = _oriantationobject.forward * _verticalInput + _oriantationobject.right * _horizontalInput;


        if (_isslide)
        {

            _playerrigidbody.AddForce( _MoveDirection.normalized * _movementSpeed * _slideMultiplier, ForceMode.Force);
        }

        else
        {

            _playerrigidbody.AddForce(_MoveDirection * _movementSpeed , ForceMode.Force);

        }


    
    }

    private void SetPlayerjump()
    {

        _playerrigidbody.linearVelocity = new Vector3(_playerrigidbody.linearVelocity.x, 0f, _playerrigidbody.linearVelocity.z);

        _playerrigidbody.AddForce(transform.up * _jumpForce,ForceMode.Impulse);  


         


    }

    private void Resetjumping()
    {
        
        _canJump = true;
    }

    private bool ÝsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, _PlayerHeight * 0.5f + 0.2f, _GroundLayer);
    }
}
