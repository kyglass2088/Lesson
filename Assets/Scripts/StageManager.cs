using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StageManager : MonoBehaviour
{
    [SerializeField] GameObject[] _mines;
    [SerializeField] GameObject[] _collectable;

    [SerializeField] Transform[] _positions;
    [SerializeField] Transform _3DTiles;
    [SerializeField] Transform _parent;
    [SerializeField] Transform startPoint;
    [SerializeField] Transform endPoint;

    void Start()
    {
        _3DTiles.Clear(); // Extention...
        _parent.Clear();
        CreateTrap();
    }

    void CreateTrap()
    {
        int max = _positions.Length;
        for (int i = 0; i < max; i++)
        {
            GameObject clone = Instantiate(_mines[Random.Range(0, _mines.Length)], startPoint.position, Quaternion.identity);

            clone.transform.parent = _parent;
        }
    }

}
