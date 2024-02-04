using UnityEngine;

public class GeneratingMap : MonoBehaviour
{
    [SerializeField] private GameObject _prefabBlock;
    [SerializeField] private Vector2 _currentPos;
    [SerializeField] private Vector2 _distanceBetweenBlocks;
    [SerializeField] private int howManyBlockWillCreate;
    
    void GenerateMap()
    {
        Instantiate( _prefabBlock, _currentPos, Quaternion.identity);
        _currentPos += _distanceBetweenBlocks;

        for (int i = 0; i < howManyBlockWillCreate; i++)
        {
            Instantiate(_prefabBlock, _currentPos, Quaternion.identity);
            _currentPos += _distanceBetweenBlocks;
        }
    }
}
