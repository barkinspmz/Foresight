using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 currentTargetPos;
    private Vector2 _goRight;
    private Vector2 _goLeft;
    private Vector2 _goUp;
    private Vector2 _goDown;
    private Rigidbody2D _rb;

    [SerializeField] private float movementSpeed;
    [SerializeField] private int moveDistance;

    public int currentPlatformerIndex;
    private bool _isGravityOpen;
    public bool _isGameStarted;

    //If the currentIndex equals those values, the player's death condition.
    [SerializeField] private int[] _deadZonePlatformerIndexSide;
    [SerializeField] private int[] _deadZonePlatformerIndexTop;
    [SerializeField] private int[] _deadZonePlatformerIndexDown;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _goLeft = new Vector2(-moveDistance, 0);
        _goRight = new Vector2(moveDistance, 0);
        _goUp = new Vector2(0, moveDistance);
        _goDown = new Vector2(0, -moveDistance);
        currentTargetPos = transform.position;
        _isGravityOpen = false;
        _isGameStarted = false;

        GameplayManager.Instance.moveLeft += MoveLeft;
        GameplayManager.Instance.moveRight += MoveRight;
        GameplayManager.Instance.moveUp += MoveUp;
        GameplayManager.Instance.moveDown += MoveDown;
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position,currentTargetPos)>0.001f && !_isGravityOpen && _isGameStarted)
        transform.position = Vector2.MoveTowards(transform.position, currentTargetPos, Time.deltaTime * movementSpeed);
    }

    void MoveLeft()
    {
        currentTargetPos += _goLeft;
        currentPlatformerIndex--;
        foreach (var index in _deadZonePlatformerIndexSide)
        {
            if (currentPlatformerIndex == index)
            {
                StartCoroutine(DeadCondition());
                GameplayManager.Instance.DiedCondition();
            }
        }
    }

    void MoveRight()
    {
        currentTargetPos += _goRight;
        currentPlatformerIndex++;
        foreach (var index in _deadZonePlatformerIndexSide)
        {
            if (currentPlatformerIndex == index)
            {
                StartCoroutine(DeadCondition());
                GameplayManager.Instance.DiedCondition();
            }
        }
    }

    void MoveUp()
    {
        currentTargetPos += _goUp;
        currentPlatformerIndex+=10;
        foreach (var index in _deadZonePlatformerIndexTop)
        {
            if (currentPlatformerIndex == index)
            {
                StartCoroutine(DeadCondition());
                GameplayManager.Instance.DiedCondition();
            }
        }
    }

    void MoveDown()
    {
        currentTargetPos += _goDown;
        currentPlatformerIndex -= 10;
        foreach (var index in _deadZonePlatformerIndexDown)
        {
            if (currentPlatformerIndex == index)
            {
                StartCoroutine(DeadCondition());
                GameplayManager.Instance.DiedCondition();
            }
        }
    }

    IEnumerator DeadCondition()
    {
        yield return new WaitForSeconds(0.4f);
        _rb.gravityScale = 1;
        _isGravityOpen = true;
        yield return new WaitForSeconds(0.6f);
        _rb.gravityScale = 0;
    }

}
