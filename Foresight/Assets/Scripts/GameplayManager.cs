using Cinemachine;
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

    public delegate void MoveUp();
    public event MoveUp moveUp;

    public delegate void MoveDown();
    public event MoveDown moveDown;

    public delegate void DeadCondition();
    public event DeadCondition deadCondition;

    public delegate void UnlockThePortal();
    public event UnlockThePortal UnlockPortal;

    private InputHolder _inputHolder;
    private PlayerMovement _playerMovement;
    private GameObject _goButton;

    [SerializeField] private float _timeBetweenMovements;

    private int _currentIndex;

    public bool isLockUnlocked;

    private Animator cinemachineCamAnim;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _inputHolder = GameObject.Find("InputHolder").GetComponent<InputHolder>();
        _playerMovement = GameObject.Find("PlayerObj").GetComponent<PlayerMovement>();
        _goButton = GameObject.Find("GoButton");
        isLockUnlocked = false;

        var cineCam = GameObject.Find("VirtualCamera");
        cinemachineCamAnim = cineCam.GetComponent<Animator>();
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
                    _currentIndex++;
                    cinemachineCamAnim.SetTrigger("Shake");
                    if (_currentIndex == LevelRequirements.Instance.howManyInputPlayerCanPress)
                    {
                        UnlockPortal();
                    }
                    break;
                case InputHolder.InputTypes.Right:
                    moveRight();
                    _currentIndex++;
                    cinemachineCamAnim.SetTrigger("Shake");
                    if (_currentIndex == LevelRequirements.Instance.howManyInputPlayerCanPress)
                    {
                        UnlockPortal();
                    }
                    break;
                case InputHolder.InputTypes.Up:
                    moveUp();
                    _currentIndex++;
                    cinemachineCamAnim.SetTrigger("Shake");
                    if (_currentIndex == LevelRequirements.Instance.howManyInputPlayerCanPress)
                    {
                        UnlockPortal();
                    }
                    break;
                case InputHolder.InputTypes.Down:
                    moveDown();
                    _currentIndex++;
                    cinemachineCamAnim.SetTrigger("Shake");
                    if (_currentIndex == LevelRequirements.Instance.howManyInputPlayerCanPress)
                    {
                        UnlockPortal();
                    }
                    break;
            }
            yield return new WaitForSeconds(_timeBetweenMovements);
        }
    }
    
}
