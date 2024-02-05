using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _currentTargetPos;
    private Vector2 _goRight;
    private Vector2 _goLeft;
    private Rigidbody2D _rb;

    [SerializeField] private float movementSpeed;
    [SerializeField] private int moveDistance;

    public int currentPlatformerIndex;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _goLeft = new Vector2(-moveDistance, 0);
        _goRight = new Vector2(moveDistance, 0);
    }

    void MoveLeft()
    {
        _currentTargetPos += _goLeft;
        transform.position = Vector2.MoveTowards(transform.position, _currentTargetPos, Time.deltaTime * movementSpeed);
        currentPlatformerIndex--;
    }

    void MoveRight()
    {
        _currentTargetPos += _goRight;
        transform.position = Vector2.MoveTowards(transform.position, _currentTargetPos, Time.deltaTime * movementSpeed);
        currentPlatformerIndex++;
    }

    void Jump()
    {

    }

}
