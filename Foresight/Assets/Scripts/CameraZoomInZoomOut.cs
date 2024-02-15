using Cinemachine;
using System.Collections;
using UnityEngine;

public class CameraZoomInZoomOut : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _cam;

    private PlayerMovement _pMovement;
    private int _currentIndex;
    void Start()
    {
        _currentIndex = 0;
        var gObj = GameObject.Find("PlayerObj");
        _pMovement = gObj.GetComponent<PlayerMovement>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _currentIndex++;
            if (_currentIndex % 2 == 1 && !_pMovement._isGameStarted)
            {
                _cam.GetComponent<Animator>().SetTrigger("ZoomOut");
            }
            else if(_currentIndex % 2 == 0 && !_pMovement._isGameStarted)
            {
                _cam.GetComponent<Animator>().SetTrigger("ZoomIn");
            }
        }
    }
}
