using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Image[] uiInputLockedImages;

    public Sprite LeftArrowKey;
    public Sprite RightArrowKey;
    public Sprite SpaceButtonImage;

    public Sprite emptyImage;

    public Image OutlineForInputHandleUI;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        AdjustUI();
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
}
