using UnityEngine;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour
{
    private GameObject _goButton;
    private PlayerMovement _playerMovement;
    private InputHolder _inputHolder;
    private void Start()
    {
        _goButton = GameObject.Find("GoButton");
        _playerMovement = GameObject.Find("PlayerObj").GetComponent<PlayerMovement>();
        _inputHolder = GameObject.Find("InputHolder").GetComponent<InputHolder>();
    }
    public void ClickingResetButton()
    {
        if (!_playerMovement._isGameStarted && _inputHolder.isInputsFilled)
        {
            _goButton.GetComponent<Button>().interactable = false;
            _goButton.GetComponent<Animator>().SetTrigger("Out");
        }
        UIManager.Instance.Clear(); 
    }
}
