using UnityEngine;

public class CharacterMovementInLoadingScreen3 : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D characterRigidbody2D;
    void Update()
    {
        WallJumpRight();
    }
    void WallJumpRight()
    {
        characterRigidbody2D.gravityScale = 0;
        characterRigidbody2D.velocity = Vector2.zero;
        animator.SetTrigger("wall_jump_right");
    }
}