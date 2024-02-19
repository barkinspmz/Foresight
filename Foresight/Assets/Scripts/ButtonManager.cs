using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonManager : MonoBehaviour
{
    private GameObject _goButton;
    private PlayerMovement _playerMovement;
    private InputHolder _inputHolder;

    [SerializeField] private Animator _closeTabButton;

    private AudioManager _audioManager;
    private void Start()
    {
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        _goButton = GameObject.Find("GoButton");
        _playerMovement = GameObject.Find("PlayerObj").GetComponent<PlayerMovement>();
        _inputHolder = GameObject.Find("InputHolder").GetComponent<InputHolder>();
        if (_closeTabButton != null)
        {
            _closeTabButton.SetTrigger("Go");
        }
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

    public void ClickingCloseTab()
    {
        _closeTabButton.SetTrigger("Back");
        _audioManager.PlayAudioClip( _audioManager.movementSound);
    }

}
