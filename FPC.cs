using UnityEngine;

public class FPC : MonoBehaviour
{
    public float Gravity;
    public float SensHor = 9.0f;
    
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed;
    private Animator _animator;
    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>(); //получаем контроллер со сцены
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // рассчет составляющих вектора
        float deltaX = Input.GetAxis("Horizontal") * _speed; // нажатия на кнопки  A D
        float deltaZ = Input.GetAxis("Vertical") * _speed; // нажатия на кнопки  W S
        float deltaY = Input.GetAxis("Jump") * _jumpSpeed; // прыжок по пробелу
        // float deltaY = 0;

        // работа с анимацией
        if (Input.GetKey(KeyCode.Space))
        {
            _animator.SetBool("Jump", true);
        }
        else if (deltaX == 0 && deltaZ == 0)
        {
            _animator.SetFloat("Speed", 0);
        }
        else
        {
            _animator.SetFloat("Speed",  0.4f);
        }
       
        transform.Rotate(0,Input.GetAxis("Mouse X") * SensHor, 0);
        Vector3 playerMovement = new Vector3(deltaX, deltaY , deltaZ);
        playerMovement = Vector3.ClampMagnitude(playerMovement, _speed)
        playerMovement.y += Gravity;
        playerMovement *= Time.deltaTime;
        playerMovement = transform.TransformDirection(playerMovement);
        _characterController.Move(playerMovement);
    }
}