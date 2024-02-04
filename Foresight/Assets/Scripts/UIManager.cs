using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Image[] uiInputLockedImages;

    public Image LeftArrowKey;
    public Image RightArrowKey;
    public Image SpaceButtonImage;

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
            uiInputLockedImages[0] = null;
        }
    }
}
