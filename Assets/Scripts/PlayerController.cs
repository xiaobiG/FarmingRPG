using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    private CharacterController _controller;
    public float MoveSpeed = 4f;
    [Header("Movement System")] public float WalkSpeed = 4f;
    [Header("Movement System")] public float RunSpeed = 8f;


    void Start()
    {
        _animator = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        Vector3 velocity = MoveSpeed * Time.deltaTime * direction;

        if (Input.GetButton("Sprint"))
        {
            MoveSpeed = RunSpeed;
            _animator.SetBool("Running", true);
        }
        else
        {
            MoveSpeed = WalkSpeed;
            _animator.SetBool("Running", false);
        }

        if (direction.magnitude >= 0.1f)
        {
            // 更改朝向
            transform.rotation = Quaternion.LookRotation(direction);

            // Move
            _controller.Move(velocity);
        }

        Debug.Log("Speed " + velocity.magnitude);
        _animator.SetFloat("Speed", velocity.magnitude);
    }
}