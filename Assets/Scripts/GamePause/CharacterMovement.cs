using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float initialSpeedX;
    public float initialSpeedY;
    public Rigidbody2D characterRigidbody2D;
    public BoxCollider2D characterBoxCollider2D;
    private RectTransform _characterRectTransform;
    void Awake()
    {
        _characterRectTransform = GetComponent<RectTransform>();
        characterRigidbody2D.velocity = new Vector2(initialSpeedX, initialSpeedY);
    }
    void Update()
    {
        if (IsCeillingCollision())
        {
            print("ceilling");
            characterRigidbody2D.velocity = new Vector2(characterRigidbody2D.velocity.x, -initialSpeedY);
        }
        if (IsGroundCollision())
        {
            print("ground");
            characterRigidbody2D.velocity = new Vector2(characterRigidbody2D.velocity.x, initialSpeedY);
        }
        if (IsWallLeftCollision())
        {
            print("left wall");
            characterRigidbody2D.velocity = new Vector2(initialSpeedX, characterRigidbody2D.velocity.y);
        }
        if (IsWallRightCollision())
        {
            print("right wall");
            characterRigidbody2D.velocity = new Vector2(-initialSpeedX, characterRigidbody2D.velocity.y);
        }
    }
    private bool IsCeillingCollision()
    {
        RaycastHit2D _raycastHit2DUp = Physics2D.
            BoxCast(characterBoxCollider2D.bounds.center, characterBoxCollider2D.bounds.size, 0, Vector2.up, 0.1f, LayerMask.GetMask("Ceilling"));
        
        return _raycastHit2DUp.collider != null;  
    }
    private bool IsGroundCollision()
    {
        RaycastHit2D _raycastHit2DDown = Physics2D.
            BoxCast(characterBoxCollider2D.bounds.center, characterBoxCollider2D.bounds.size, 0, Vector2.down, 0.1f, LayerMask.GetMask("Ground"));
        return _raycastHit2DDown.collider != null;
    }
    private bool IsWallLeftCollision()
    {
        RaycastHit2D _raycastHit2DLeft = Physics2D.
            BoxCast(characterBoxCollider2D.bounds.center, characterBoxCollider2D.bounds.size, 0, Vector2.left, 0.1f, LayerMask.GetMask("LeftWall"));
        return _raycastHit2DLeft.collider != null;  
    }
    private bool IsWallRightCollision()
    {
        RaycastHit2D _raycastHit2DRight = Physics2D.
            BoxCast(characterBoxCollider2D.bounds.center, characterBoxCollider2D.bounds.size, 0, Vector2.right, 0.1f, LayerMask.GetMask("RightWall"));
        return _raycastHit2DRight.collider != null;
    }
}