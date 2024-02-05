using System.Collections;
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
    private bool _isGravityOpen;
    public bool _isGameStarted;
    [SerializeField] private int _deadZonePlatformerIndex;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _goLeft = new Vector2(-moveDistance, 0);
        _goRight = new Vector2(moveDistance, 0);
        _currentTargetPos = transform.position;
        _isGravityOpen = false;
        _isGameStarted = false;

        GameplayManager.Instance.moveLeft += MoveLeft;
        GameplayManager.Instance.moveRight += MoveRight;
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position,_currentTargetPos)>0.001f && !_isGravityOpen && _isGameStarted)
        transform.position = Vector2.MoveTowards(transform.position, _currentTargetPos, Time.deltaTime * movementSpeed);
    }

    void MoveLeft()
    {
        _currentTargetPos += _goLeft;
        currentPlatformerIndex--;
        if (currentPlatformerIndex<=0)
        {
            StartCoroutine(DeadCondition());
            GameplayManager.Instance.DiedCondition();
        }
    }

    void MoveRight()
    {
        _currentTargetPos += _goRight;
        currentPlatformerIndex++;
        if (currentPlatformerIndex == _deadZonePlatformerIndex)
        {
            StartCoroutine(DeadCondition());
            GameplayManager.Instance.DiedCondition();
        }
    }

    void Jump()
    {

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
