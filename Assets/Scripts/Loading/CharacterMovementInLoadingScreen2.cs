using UnityEngine;

public class CharacterMovementInLoadingScreen2 : MonoBehaviour
{
    public float jumpPower = 2f;
    public Animator animator;
    public BoxCollider2D characterBoxCollider2D;
    public Rigidbody2D characterRigidbody2D;
    private bool _isGrounded = true;
    private bool _canDoubleJump = true;
    void Update()
    {
        _isGrounded = IsGrounded();
        Jump();
    }
    void Jump()
    {
        if (characterRigidbody2D.velocity.y > 0 && characterRigidbody2D.velocity.y < 12.2f && _canDoubleJump)
        {
            DoubleJump();
            return;
        }
        if (_isGrounded)
        {
            animator.SetTrigger("idle");
            _canDoubleJump = true;
            characterRigidbody2D.velocity = new Vector2(0, jumpPower);
            return;
        }
        if (characterRigidbody2D.velocity.y < 0)
        {
            animator.SetTrigger("fall");
            return;
        }
        animator.SetTrigger("jump");
    }
    void DoubleJump()
    {
        _canDoubleJump = false;
        characterRigidbody2D.velocity = new Vector2(jumpPower, 0);
        animator.SetTrigger("double_jump");
    }
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.
            BoxCast(characterBoxCollider2D.bounds.center, characterBoxCollider2D.bounds.size, 0, Vector2.down, 0.1f, LayerMask.GetMask("Ground"));
            return raycastHit2D.collider != null;
    }

}