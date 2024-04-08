using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        //MoveCharacter(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        animator.SetFloat("Forward", v);
        animator.SetFloat("Strafe", h);
    }
}