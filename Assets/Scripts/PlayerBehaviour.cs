using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float speed;
    [SerializeField] private float attackRate = 2f;
    private float nextAttackTime = 0f;
    private bool IsGrounded;
    private RaycastHit raycastHit;
    [SerializeField] private LayerMask layerMask;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        //CheckForGrounded();
        IsGrounded = Physics.SphereCast(new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z), 1f, Vector3.down, out raycastHit, 10f); // To Check If Player Can Jump Or Not Based On Is He/She On Ground
    }
    private void CheckForGrounded()
    {
        Collider[] groundColliders = Physics.OverlapSphere(transform.position, 1f, layerMask);
        if (groundColliders != null) IsGrounded = true;
        else IsGrounded = false;
        //foreach (Collider ground in groundColliders)
        //{
        //    if (ground != null) IsGrounded = true;
        //    else IsGrounded = false;
        //}
    }
    void Update()
    {
        //MoveCharacter(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));

        // Move Character By Animator's Root Motion
        animator.SetFloat("Forward", Input.GetAxis("Vertical"));
        animator.SetFloat("Strafe", Input.GetAxis("Horizontal"));

        // Left Or Right Punch
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                animator.SetTrigger("LeftPunch");
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                animator.SetTrigger("RightPunch");
            }
            nextAttackTime = Time.time + 1f / attackRate;
        }
        if (IsGrounded)
        {
            Debug.Log("Can Jump");
            if (Input.GetButtonDown("Jump"))
            {
                animator.SetTrigger("Jump");
            }
        }
    }
}