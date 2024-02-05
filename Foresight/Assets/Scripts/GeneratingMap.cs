using UnityEngine;

[System.Serializable]
public class GeneratingMap : MonoBehaviour
{
    [SerializeField] private GameObject _prefabBlock;
    [SerializeField] private Vector2 _currentPos;
    [SerializeField] private Vector2 _distanceBetweenBlocks;
    [SerializeField] private int _howManyBlockWillCreate;
    
    public void GenerateMap()
    {
        var parentObj = GameObject.Find("GeneratedBlocks");
        Instantiate( _prefabBlock, _currentPos, Quaternion.identity,parentObj.transform);
        _currentPos += _distanceBetweenBlocks;
        for (int i = 0; i < _howManyBlockWillCreate; i++)
        {
            Instantiate(_prefabBlock, _currentPos, Quaternion.identity,parentObj.transform);
            _currentPos += _distanceBetweenBlocks;
        }
    }
    public void CleanLevel()
    {
        var blockPrefabs = GameObject.FindGameObjectsWithTag("Block");

        foreach (var prefab in blockPrefabs)  { DestroyImmediate(prefab); }
    }
}
