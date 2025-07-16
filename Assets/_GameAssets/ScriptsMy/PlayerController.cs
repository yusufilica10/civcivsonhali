using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    [SerializeField]   private Transform _oriantationobject;
   [SerializeField] private Rigidbody _rigidbody;
    private Vector3 _MoveDirection;

    float _horizontalInput , _verticalInput;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
          SetInputs();
    }

    private void SetInputs()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

    }

    private void FixedUpdate()
    {
        SetPlayerMovement();
    }

    private void SetPlayerMovement()
    {
        _MoveDirection = _oriantationobject.forward * _verticalInput + _oriantationobject.right * _horizontalInput;


        _rigidbody.AddForce(_MoveDirection * 10f, ForceMode.Force);
    }
}
