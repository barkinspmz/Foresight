using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void ClickingResetButton()
    {
        UIManager.Instance.Clear();
    }
}
