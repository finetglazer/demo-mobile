using UnityEngine;

public class CharacterMovementInLoadingScreen1 : MonoBehaviour
{
    public float jumpPower = 2f;
    public Animator animator;
    public BoxCollider2D characterBoxCollider2D;
    public Rigidbody2D characterRigidbody2D;
    private bool _isGrounded = true;
    void Update()
    {
        _isGrounded = IsGrounded();
        Jump();
    }
    void Jump()
    {
        if (_isGrounded)
        {
            animator.SetTrigger("idle");
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
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.
            BoxCast(characterBoxCollider2D.bounds.center, characterBoxCollider2D.bounds.size, 0, Vector2.down, 0.1f, LayerMask.GetMask("Ground"));
            return raycastHit2D.collider != null;
    }

}