#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;
[CustomEditor(typeof(GeneratingMap))]
public class GeneratingMapEditor : Editor
{
    public override void OnInspectorGUI()
    {
        GeneratingMap generatingMap = (GeneratingMap)target;
        
        if (GUILayout.Button("Generate Level"))
        {
            generatingMap.GenerateMap();
        }

        if (GUILayout.Button("Clean All"))
        {
            generatingMap.CleanLevel();
        }
        DrawDefaultInspector();
    }
}