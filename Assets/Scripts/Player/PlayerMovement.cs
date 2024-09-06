using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    private Rigidbody2D _rigidBody2D;
    private Animator _animator;
    private BoxCollider2D _boxCollider2D;
    private float _horizontalInput;
    private int _countSpaceKeys = 0;
    void Awake()
    {   
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        if (Grounded() || OnWall()) 
        {
            _countSpaceKeys = 0;
        }
        if (Grounded() && _horizontalInput == 0) 
        {
            Idle();
        }
        if (OnWall() && !Grounded())
        {
            WallJump();
        }
        if (_horizontalInput != 0 && Grounded()) 
        {
            Run();
        }
        if (_rigidBody2D.velocity.y < 0 && !OnWall())
        {
            Fall();
        }
        if (_rigidBody2D.velocity.y > 0)
        {
            Jump();             // Keep the jump effect without lifting a player
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _countSpaceKeys++;
            if (_countSpaceKeys == 1 && _rigidBody2D.velocity.y >= 0)
            {
                Jump();
            }
            if (_countSpaceKeys > 1 && _rigidBody2D.velocity.y > 0) 
            {
                DoubleJump();
            }
        }
    }

    private void Idle()
    {
        _animator.SetTrigger("idle");
    }
    private void Run() 
    {
        _rigidBody2D.velocity = new Vector2(_horizontalInput * speed, _rigidBody2D.velocity.y);
        if (_horizontalInput > 0.01f) 
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (_horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        _animator.SetTrigger("run");
    }
    private void Jump()
    {   
        if (Grounded()) 
        {
            _rigidBody2D.velocity = new Vector2(_rigidBody2D.velocity.x, jumpSpeed);
        }
        else if (OnWall())
        {
            _rigidBody2D.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 0);
            Fall();
        }
        _animator.SetTrigger("jump");
    }

    private void DoubleJump() 
    {
        _rigidBody2D.velocity = new Vector2(_rigidBody2D.velocity.x, jumpSpeed);
        _animator.SetTrigger("double_jump");
        _countSpaceKeys = 0;
    }
    
    private void WallJump()
    {
        if (Mathf.Sign(transform.localScale.x) > 0)
        {
            _animator.SetTrigger("wall_jump_right");
        }
        else
        {
            _animator.SetTrigger("wall_jump_left");
            transform.localScale = new Vector3(_animator.transform.localScale.x, _animator.transform.localScale.y, _animator.transform.localScale.z);
        }
        _rigidBody2D.gravityScale = 0;
        _rigidBody2D.velocity = Vector2.zero;
    }

    private void Fall()
    {
        _rigidBody2D.gravityScale = 1;
        _animator.SetTrigger("fall");
    }
    private bool Grounded()
    {
        RaycastHit2D _raycastHit2D = Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size, 0, Vector2.down, 0.1f, LayerMask.GetMask("Ground"));
        return _raycastHit2D.collider != null;
    }

    private bool OnWall() 
    {
        RaycastHit2D _raycastHit2D = Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size, 0, new Vector2(Mathf.Sign(transform.localScale.x), 0), 0.1f, LayerMask.GetMask("Wall"));
        return _raycastHit2D.collider != null;
    }
}

