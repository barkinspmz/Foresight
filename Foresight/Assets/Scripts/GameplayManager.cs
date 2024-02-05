using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance;

    public delegate void MoveLeftSide();
    public event MoveLeftSide moveLeft;

    public delegate void MoveRightSide();
    public event MoveRightSide moveRight;

    public delegate void MoveJump();
    public event MoveJump moveJump;

    public delegate void DeadCondition();
    public event DeadCondition deadCondition;

    private InputHolder _inputHolder;
    private PlayerMovement _playerMovement;
    private GameObject _goButton;

    [SerializeField] private float _timeBetweenMovements;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _inputHolder = GameObject.Find("InputHolder").GetComponent<InputHolder>();
        _playerMovement = GameObject.Find("PlayerObj").GetComponent<PlayerMovement>();
        _goButton = GameObject.Find("GoButton");
    }

    public void MovementBasedOnInput()
    {
        if (_inputHolder != null)
        {
            _goButton.GetComponent<Button>().interactable = false;
            _goButton.GetComponent<Animator>().SetTrigger("Out");
            StartCoroutine(MovementFromTakenInput());
            _playerMovement._isGameStarted = true;
        }
    }

    public void DiedCondition()
    {
        deadCondition();
    }

    private IEnumerator MovementFromTakenInput()
    {
        yield return new WaitForSeconds(_timeBetweenMovements);
        for (int i = 0; i < LevelRequirements.Instance.howManyInputPlayerCanPress; i++)
        {
            switch (_inputHolder.inputs[i])
            {
                case InputHolder.InputTypes.Left:
                    moveLeft();
                    break;
                case InputHolder.InputTypes.Right:
                    moveRight();
                    break;
                case InputHolder.InputTypes.Jump:
                    moveJump();
                    break;
            }
            yield return new WaitForSeconds(_timeBetweenMovements);
        }
    }
    
}
