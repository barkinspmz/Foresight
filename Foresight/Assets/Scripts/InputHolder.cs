using UnityEngine;

public class InputHolder : MonoBehaviour
{
    private int _maxInputIndex;
    [SerializeField] private int _currentIndex;

    private enum InputTypes { Left, Right, Jump}
    private InputTypes[] _inputs;

    private void Start()
    {
        _inputs = new InputTypes[LevelRequirements.Instance.howManyInputPlayerCanPress];
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (_currentIndex < LevelRequirements.Instance.howManyInputPlayerCanPress)
            {
                _inputs[_currentIndex] = InputTypes.Left;
                UIManager.Instance.uiInputLockedImages[_currentIndex].sprite = UIManager.Instance.LeftArrowKey;
                _currentIndex++;
                UIManager.Instance.ChangeOutlinePosition();
            }

            if (_currentIndex >= LevelRequirements.Instance.howManyInputPlayerCanPress)
            {
                Destroy(UIManager.Instance.OutlineForInputHandleUI);
            }
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (_currentIndex < LevelRequirements.Instance.howManyInputPlayerCanPress )
            {
                _inputs[_currentIndex] = InputTypes.Right;
                UIManager.Instance.uiInputLockedImages[_currentIndex].sprite = UIManager.Instance.RightArrowKey;
                _currentIndex++;
                UIManager.Instance.ChangeOutlinePosition();
            }

            if (_currentIndex >= LevelRequirements.Instance.howManyInputPlayerCanPress)
            {
                Destroy(UIManager.Instance.OutlineForInputHandleUI);
            }
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (_currentIndex < LevelRequirements.Instance.howManyInputPlayerCanPress)
            {
                _inputs[_currentIndex] = InputTypes.Jump;
                UIManager.Instance.uiInputLockedImages[_currentIndex].sprite = UIManager.Instance.SpaceButtonImage;
                _currentIndex++;
                UIManager.Instance.ChangeOutlinePosition();
            }

            if (_currentIndex >= LevelRequirements.Instance.howManyInputPlayerCanPress)
            {
                Destroy(UIManager.Instance.OutlineForInputHandleUI);
            }
        }
    }
}
