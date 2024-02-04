using UnityEngine;

public class LevelRequirements : MonoBehaviour
{
    public static LevelRequirements Instance;
    public int howManyInputPlayerCanPress;

    private void Awake()
    {
        Instance = this;
    }
}
