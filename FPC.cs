using UnityEngine;

internal class FPC : MonoBehaviour
{
    [SerializeField] private float _gravity;
    [SerializeField] private float _sensHor = 9.0f;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed;
    private Animator _animator;
    private CharacterController _characterController;
    
    private void Start()
    {
        _characterController = GetComponent<CharacterController>(); //Получаем контроллер со сцены
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        
        // Рассчет составляющих вектора
        float deltaX = Input.GetAxis("Horizontal") * _speed;     // Нажатия на кнопки  A D
        float deltaZ = Input.GetAxis("Vertical") * _speed;       // Нажатия на кнопки  W S
        float deltaY = Input.GetAxis("Jump") * _jumpSpeed;       // Прыжок по пробелу
        // float deltaY = 0;
        // Работа с анимацией
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
        
        transform.Rotate(0,Input.GetAxis("Mouse X") * _sensHor, 0);
        Vector3 playerMovement = new Vector3(deltaX, deltaY , deltaZ);
        playerMovement = Vector3.ClampMagnitude(playerMovement, _speed);
        playerMovement.y += _gravity;
        playerMovement *= Time.deltaTime;
        playerMovement = transform.TransformDirection(playerMovement);
        _characterController.Move(playerMovement);
    }
}
