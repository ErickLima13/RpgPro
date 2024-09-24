using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform cam;
    private CharacterController characterController;
    private Animator animator;
    private MeleeController meleeController;

    private Vector3 direction;
    private Vector3 moveDir;

    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    public float movementSpeed;
    private bool isWalk;

    [Header("Jump Controller")]
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public bool isGrounded;
    public bool isLanding;
    private Vector3 velocity;
    private float gravity = -19.62f;
    public float jumpHeight;

    [Header("Attack System")]
    private bool isReceivedInput;
    public bool isAttack;
    private int idCombo;

    public bool isDefense;

    private void Start()
    {
        cam = Camera.main.transform;
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        meleeController = GetComponent<MeleeController>();

        animator.SetBool("isSit", true);

        //Cursor.lockState = CursorLockMode.Locked;
       // Cursor.visible = false;
    }

    private void Update()
    {
        GetInputs();
        ApplyGravity();
        MoveCharacter();
        Jump();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.3f, whatIsGround);
    }

    private void GetInputs()
    {
        if (!isAttack && !isLanding)
        {
            direction = new Vector3(Input.GetAxis("Horizontal"),
                0, Input.GetAxis("Vertical"));
        }
        else
        {
            direction = Vector3.zero;
        }


        if (Input.GetButtonDown("Fire1") && !isReceivedInput && !isDefense  && GameManager.Instance.idEquip > 0)
        {
            isReceivedInput = true;
            isAttack = true;

            if (!isGrounded)
            {
                idCombo = 6; // attack in Air
            }
            else
            {
                idCombo++;
            }
           
            animator.SetInteger("idCombo", idCombo);
        }


        //sistema de defesa
        if (Input.GetMouseButtonDown(1))
        {
            isDefense = true;
            animator.SetBool("defend", isDefense);
        }

        if (Input.GetMouseButtonUp(1))
        {
            isDefense = false;
            animator.SetBool("defend", isDefense);
        }

    }

    public void CheckCombo()
    {
        isReceivedInput = false;
        meleeController.CheckTargets();
    }

    public void OnExitCombo()
    {
        idCombo = 0;
        isAttack = false;
        animator.SetInteger("idCombo", idCombo);
        isReceivedInput = false;
    }

    public void MasterHit()
    {
        meleeController.CheckTargets();
    }

    private void MoveCharacter()
    {
        if (!isAttack)
        {
            if (direction.magnitude > 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z
               ) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                    targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0, angle, 0);
                moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
                isWalk = true;
            }
            else
            {
                isWalk = false;
            }
        }
        else
        {
            isWalk = false;
        }

        characterController.Move(moveDir.normalized * movementSpeed
               * direction.magnitude * Time.deltaTime);

        animator.SetBool("isWalk", isWalk);
    }

    private void ApplyGravity()
    {
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        animator.SetBool("isGrounded", isGrounded);
    }

    private void JumpEnd(bool value)
    {
        isLanding = value;
    }

}
