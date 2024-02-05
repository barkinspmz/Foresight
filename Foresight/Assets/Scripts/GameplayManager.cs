using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance;

    public delegate void MoveLeftSide();
    public event MoveLeftSide moveLeft;

    public delegate void MoveRightSide();
    public event MoveRightSide moveRightSide;

    public delegate void MoveJump();
    public event MoveJump moveJump;

    private InputHolder _inputHolder;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _inputHolder = GameObject.Find("InputHolder").GetComponent<InputHolder>();
    }
    
}
