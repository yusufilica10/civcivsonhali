using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Purchasing;

public class ThirdPersonController : MonoBehaviour
{
    [SerializeField]  private Transform _PlayerTransform;

    [SerializeField]  private Transform _orientationTransform;

    [SerializeField]  private Transform _PlayerVisualTransform;

    [SerializeField]  private float _rotationSpeed;



    private void Update()
    {
     
    Vector3 WiewDirection =_PlayerTransform.position - new Vector3(transform.position.x, _PlayerTransform.position.y,transform.position.z);

        _orientationTransform.forward = WiewDirection.normalized;

        float _horizontalInput = Input.GetAxisRaw("Horizontal");

        float _verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 inputDirection = _orientationTransform.forward * _verticalInput + _orientationTransform.right * _horizontalInput;


        if(inputDirection != Vector3.zero)
        {
            _PlayerVisualTransform.forward = Vector3.Slerp(_PlayerVisualTransform.forward, inputDirection.normalized, Time.deltaTime * _rotationSpeed);
        }
       


    }


    

}
