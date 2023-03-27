using UnityEngine;
public class PlayerController : MonoBehaviour
{
    //0.625 crouch(one cycle,1.25 both), 0.83 Death
    [SerializeField]
    float MoveSpeed = 2f, JumpForce = 4f, CentrePos, BigJumpForce = 5.5f,
        RightClamp = 2.3f, LeftClamp = -2.3f, CrouchTimer = 0, CrouchIdealTime = 1f;

    [SerializeField] bool IsMoving = false, IsJumping = false, IsCrouching = false;

    Rigidbody rb;

    bool CanJump = true;
    Vector3 TargetPos;
    Animator anim;
    float tempJumpForce;

    public bool InvertedControls = false;
    CapsuleCollider[] Cols;

    public delegate void HasEnded();
    public event HasEnded Ended;

    private void Start()
    {
        TargetPos = transform.position;
        Cols = GetComponents<CapsuleCollider>();
        CentrePos = transform.position.x;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        tempJumpForce = JumpForce;
        Ended += GameOver;
    }
    private void Update()
    {
        InputHandler();
    }

    private void FixedUpdate()
    {
        if (IsMoving)
        {
            Move();
        }
        if (IsCrouching)
            Crouch();
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, TargetPos, MoveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, TargetPos) < 0.2f)
        {
            IsMoving = false;
        }
    }

    void InputHandler()
    {
        if (Input.GetKeyDown(KeyCode.A) && !IsMoving)
        {
            //left
            if (!InvertedControls)
                InitiateMove(false);
            else
                InitiateMove(true);
        }
        if (Input.GetKeyDown(KeyCode.D) && !IsMoving)
        {
            //Right
            if (!InvertedControls)
                InitiateMove(true);
            else
                InitiateMove(false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //Down
            if (!InvertedControls)
            {
                if (!IsCrouching)
                {
                    IsCrouching = true;
                }
            }
            else
                Jump();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Up
            if (!InvertedControls)
                Jump();
            else
            {
                if (!IsCrouching)
                {
                    IsCrouching = true;
                }
            }
        }

    }

    void InitiateMove(bool IsRight)
    {
        if (transform.position.x < CentrePos - 0.5)//.5 is offset to avoid deciaml errors
        {
            //left pos
            if (IsRight)
            {
                IsMoving = true;
                TargetPos.x = CentrePos;
            }
        }

        if (transform.position.x > LeftClamp + 0.5 && transform.position.x < RightClamp - 0.5)//.5 is offset to avoid deciaml errors
        {
            //Centre pos
            if (IsRight)
            {
                IsMoving = true;
                TargetPos.x = RightClamp;
            }
            else
            {
                IsMoving = true;
                TargetPos.x = LeftClamp;
            }
        }

        if (transform.position.x > CentrePos + 0.5)//.5 is offset to avoid deciaml errors
        {
            //Right pos
            if (!IsRight)
            {
                IsMoving = true;
                TargetPos.x = CentrePos;
            }
        }
    }

    void Jump()
    {
        if (!IsJumping&&CanJump)
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            IsJumping = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        IsJumping = false;
        if (collision.collider.CompareTag("Obstacle"))
        {
            collision.collider.enabled = false;
            transform.parent = collision.gameObject.transform;
            Ended.Invoke();//invoke game over event
        }
    }

    void Crouch()
    {
        anim.SetBool("IsCrouching", true);

        CrouchTimer += Time.deltaTime;
        if (CrouchTimer > 0.3f)//0.6 f is animation time for crouching
        {

            Cols[0].enabled = false;
            Cols[1].enabled = true;//activate crouch collider when crouching
        }
        if (CrouchTimer > CrouchIdealTime + 0.3f)//0.6 f is animation time for crouching
        {

            anim.SetBool("IsCrouching", false);
        }
        if (CrouchTimer > CrouchIdealTime + 0.625f)
        {
            IsCrouching = false;
            Cols[0].enabled = true;//activate normal collider when crouch end
            Cols[1].enabled = false;
            CrouchTimer = 0f;
        }
    }

    public void IncreaseJump(bool State)
    {
        if (State)
        {
            JumpForce = BigJumpForce;
        }
        else
        {
            JumpForce = tempJumpForce;
        }
    }
    void GameOver()
    {
        anim.SetBool("IsDead", true);
        this.enabled = false;
    }

    public void ToggleJump(bool state)
    {
        if (state)
        {
            CanJump = true;
        }
        else
        {
            CanJump = false;
        }
    }
}
