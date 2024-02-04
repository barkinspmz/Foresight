using UnityEngine;

public class InputHolder : MonoBehaviour
{
    private int _maxInputIndex;
    [SerializeField] private int _currentIndex;

    private enum InputTypes { Left, Right, Jump}
    private InputTypes[] _inputs;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (_currentIndex < LevelRequirements.Instance.howManyInputPlayerCanPress)
            {
                _inputs[_currentIndex] = InputTypes.Left;
                _currentIndex++;
                UIManager.Instance.uiInputLockedImages[_currentIndex] = UIManager.Instance.LeftArrowKey;
            }
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (_currentIndex < LevelRequirements.Instance.howManyInputPlayerCanPress)
            {
                _inputs[_currentIndex] = InputTypes.Right;
                _currentIndex++;
                UIManager.Instance.uiInputLockedImages[_currentIndex] = UIManager.Instance.LeftArrowKey;
            }
        }

        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_currentIndex < LevelRequirements.Instance.howManyInputPlayerCanPress)
            {
                _inputs[_currentIndex] = InputTypes.Jump;
                _currentIndex++;
            }
        }
    }
}
