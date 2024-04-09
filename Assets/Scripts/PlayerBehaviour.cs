using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float speed;
    [SerializeField] private float attackRate = 2f;
    private float nextAttackTime = 0f;
    private bool IsGrounded;
    [SerializeField] private LayerMask layerMask;

    public float RotateSpeed = 30f;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        CheckForGrounded();
    }
    private void CheckForGrounded()
    {
        Collider[] groundColliders = Physics.OverlapSphere(transform.position, 0.07f, layerMask);
        if (groundColliders.Length != 0) IsGrounded = true;
        else IsGrounded = false;
    }
    void Update()
    {
        //MoveCharacter(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));

        // Move Character By Animator's Root Motion
        animator.SetFloat("Forward", Input.GetAxis("Vertical"));
        animator.SetFloat("Strafe", Input.GetAxis("Horizontal"));

        #region Bug
        //if (Time.time >= nextAttackTime)    // Left Or Right Punch
        //{
        //    Debug.Log("Can Attack");
        //    if (Input.GetButtonDown("Fire1"))
        //    {
        //        Debug.Log("Left Punch");
        //        animator.SetTrigger("LeftPunch");
        //    }
        //    else if (Input.GetButtonDown("Fire2"))
        //    {
        //        Debug.Log("Right Punch");
        //        animator.SetTrigger("RightPunch");
        //    }
        //    nextAttackTime = Time.time + 1f / attackRate;
        //    Debug.Log(Time.time);
        //    Debug.Log(nextAttackTime);
        //}
        #endregion

        if (IsGrounded) // If Player Is Grounded Than Only Allow Jump   
        {
            if (Input.GetButtonDown("Jump"))
            {
                animator.SetTrigger("Jump");
            }
            else if (Input.GetButtonDown("Fire1"))
            {
                animator.SetTrigger("LeftPunch");
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                animator.SetTrigger("RightPunch");
            }
        }
    }
}