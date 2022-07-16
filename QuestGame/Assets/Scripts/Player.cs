using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Player : MonoBehaviour
{
    PhotonView view;

    [SerializeField]
    private float _speed = 2f;
    [SerializeField]
    private int _jumpForce = 10;
    [SerializeField]
    private float checkRadius;
    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private Text nickText;
    
    private Rigidbody2D playerRigidBody2D;
    private Animator animator;
    private Transform playerTransform;
     

    private bool _isFacingRight = true;
    private bool _isGrounded;

    private void Start()
    {
        view = GetComponent<PhotonView>();
        playerRigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerTransform = GetComponent<Transform>();

        nickText.text = view.Owner.NickName;
    }

    private void Update()
    {
        if (view.IsMine)
        {
            if (Input.GetButton("Horizontal"))
            {
                Run();
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }

            if (Input.GetButtonDown("Vertical"))
            {
                Jump();
            }
        }
        
    }

    private void FixedUpdate()
    {
        if (view.IsMine)
        {
            _isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        
            if ((Input.GetKey((KeyCode.LeftArrow)) || Input.GetKey((KeyCode.A))) && _isFacingRight)
            {
                Flip();
            }

            else if (((Input.GetKey(KeyCode.RightArrow)) || Input.GetKey((KeyCode.D))) && !_isFacingRight)
            {
                Flip();
            }
        }
    }

    private void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, _speed * Time.deltaTime);

        animator.SetBool("isRunning", true);
    }

    private void Jump()
    {
        animator.SetTrigger("Jump");

        if (_isGrounded)
        {
            playerRigidBody2D.AddForce(transform.up * _jumpForce);
        }
    }

    void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

        view.RPC("FlipNick", RpcTarget.AllBuffered);
    }

    [PunRPC]
    private void FlipNick()
    {
        nickText.transform.Rotate(0f, 180f, 0f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
}
