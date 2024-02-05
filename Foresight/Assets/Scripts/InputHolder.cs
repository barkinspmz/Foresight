using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
public class InputHolder : MonoBehaviour
{
    private int _maxInputIndex;
    [SerializeField] private int _currentIndex;

    public enum InputTypes { Left, Right, Jump}
    public InputTypes[] inputs;

    private GameObject _goButton;

    public bool isInputsFilled;
    private void Start()
    {
        inputs = new InputTypes[LevelRequirements.Instance.howManyInputPlayerCanPress];
        UIManager.Instance.resetAll += ClearAllInputs;
        _goButton = GameObject.Find("GoButton");
        isInputsFilled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (_currentIndex < LevelRequirements.Instance.howManyInputPlayerCanPress)
            {
                inputs[_currentIndex] = InputTypes.Left;
                UIManager.Instance.uiInputLockedImages[_currentIndex].sprite = UIManager.Instance.LeftArrowKey;
                _currentIndex++;
                UIManager.Instance.ChangeOutlinePosition();
            }

            if (_currentIndex >= LevelRequirements.Instance.howManyInputPlayerCanPress)
            {
                UIManager.Instance.OutlineForInputHandleUI.enabled = false;
                _goButton.GetComponent<Animator>().SetTrigger("Go");
                _goButton.GetComponent<UnityEngine.UI.Button>().interactable = true;
                isInputsFilled = true;
            }
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (_currentIndex < LevelRequirements.Instance.howManyInputPlayerCanPress )
            {
                inputs[_currentIndex] = InputTypes.Right;
                UIManager.Instance.uiInputLockedImages[_currentIndex].sprite = UIManager.Instance.RightArrowKey;
                _currentIndex++;
                UIManager.Instance.ChangeOutlinePosition();
            }

            if (_currentIndex >= LevelRequirements.Instance.howManyInputPlayerCanPress)
            {
                UIManager.Instance.OutlineForInputHandleUI.enabled = false;
                _goButton.GetComponent<Animator>().SetTrigger("Go");
                _goButton.GetComponent<UnityEngine.UI.Button>().interactable = true;
                isInputsFilled = true;
            }
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (_currentIndex < LevelRequirements.Instance.howManyInputPlayerCanPress)
            {
                inputs[_currentIndex] = InputTypes.Jump;
                UIManager.Instance.uiInputLockedImages[_currentIndex].sprite = UIManager.Instance.SpaceButtonImage;
                _currentIndex++;
                UIManager.Instance.ChangeOutlinePosition();
            }

            if (_currentIndex >= LevelRequirements.Instance.howManyInputPlayerCanPress)
            {
                UIManager.Instance.OutlineForInputHandleUI.enabled = false;
                _goButton.GetComponent<Animator>().SetTrigger("Go");
                _goButton.GetComponent<UnityEngine.UI.Button>().interactable = true;
                isInputsFilled = true;
            }
        }
    }

    private void ClearAllInputs()
    {
        _currentIndex = 0;
        isInputsFilled = false;
    }
}
