using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public delegate void ClickResetAll();
    public event ClickResetAll resetAll;

    public Image[] uiInputLockedImages;

    public Sprite LeftArrowKey;
    public Sprite RightArrowKey;
    public Sprite UpArrowKey;
    public Sprite DownArrowKey;

    public Sprite emptyImage;
    public Sprite isNotEmptyImage;

    public Image infoIcon;
    public TextMeshProUGUI infoText; 

    public Image OutlineForInputHandleUI;
    private Vector3 outlineStartPos;

    private InputHolder _inputHolder;

    public Animator infoInputAnim;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        AdjustUI();

        resetAll += ClearAllImages;
        resetAll += ResetOutlinePosition;

        outlineStartPos = OutlineForInputHandleUI.rectTransform.anchoredPosition;

        _inputHolder = GameObject.Find("InputHolder").GetComponent<InputHolder>();
    }

    private void AdjustUI()
    {
        for (int i = 0; i < LevelRequirements.Instance.howManyInputPlayerCanPress; i++)
        {
            uiInputLockedImages[i].sprite = emptyImage;
        }
    }

    public void ChangeOutlinePosition()
    {
        OutlineForInputHandleUI.rectTransform.anchoredPosition = new Vector3(OutlineForInputHandleUI.rectTransform.anchoredPosition.x + 110, OutlineForInputHandleUI.rectTransform.anchoredPosition.y, OutlineForInputHandleUI.rectTransform.position.z);
    }

    public void ChangeOutLinePositionOneBlockBack()
    {
        OutlineForInputHandleUI.rectTransform.anchoredPosition = new Vector3(OutlineForInputHandleUI.rectTransform.anchoredPosition.x - 110, OutlineForInputHandleUI.rectTransform.anchoredPosition.y, OutlineForInputHandleUI.rectTransform.position.z);

    }

    private void ClearAllImages()
    {
        for (int i = 0; i < uiInputLockedImages.Length; i++)
        {
            uiInputLockedImages[i].sprite = isNotEmptyImage;
        }

        for (int i = 0; i < LevelRequirements.Instance.howManyInputPlayerCanPress; i++)
        {
            uiInputLockedImages[i].sprite = emptyImage;
        }
    }

    private void ResetOutlinePosition()
    {
        OutlineForInputHandleUI.rectTransform.anchoredPosition = outlineStartPos;
        OutlineForInputHandleUI.enabled = true;
    }

    public void Clear()
    {
        resetAll();
    }
}
