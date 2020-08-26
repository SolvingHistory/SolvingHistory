using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _jumpSpeed = 0.5f;
    [SerializeField] private float _gravity = 2f;
    
    CharacterController _characterController;
    private Vector3 _moveDirection;
    static Animator anim;
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;

    void Awake() => _characterController = GetComponent<CharacterController>();
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 inputDirection = new Vector3(horizontal, 0, vertical);
        Vector3 transformDirection = transform.TransformDirection(inputDirection);
        
        Vector3 flatMovement = _moveSpeed * Time.deltaTime * transformDirection;

        _moveDirection = new Vector3(flatMovement.x, _moveDirection.y , flatMovement.z);

        if (PlayerJumped)
            _moveDirection.y = _jumpSpeed;
        else if (_characterController.isGrounded)
            _moveDirection.y = 0f;
        else
            _moveDirection.y -= _gravity * Time.deltaTime;

        _characterController.Move(_moveDirection);
    }
    private bool PlayerJumped => _characterController.isGrounded && Input.GetKey(KeyCode.Space);
     void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        
        transform.Translate(0,0,translation);
        transform.Rotate(0,rotation,0);
        
        if(Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("isJumping");
        }
         //Walking
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isIdle", false);
            anim.SetBool("isRunning", false);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isIdle", false);
            anim.SetBool("isRunning", false);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isIdle", false);
            anim.SetBool("isRunning", false);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isIdle", false);
            anim.SetBool("isRunning", false);
        }
        else if (Input.GetKey(KeyCode.C))
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isRunning", true);
        }
        else
        {
            //Is Idle
            anim.SetBool("isWalking", false);
            anim.SetBool("isIdle", true);
            anim.SetBool("isRunning", false);
        }
}
}