using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] GameObject[] _mines;
    [SerializeField] GameObject[] _collectable;

    [SerializeField] Transform[] _positions;
    [SerializeField] Transform[] _3DTiles;
    [SerializeField] Transform[] _parent;
    [SerializeField] Transform[] startPoint;
    [SerializeField] Transform[] endPoint;

    void Start()
    {
        _3DTiles.trasform.Clear(); // Extention...
        _parent.transform.Clear();
        SetupTile();
    }

    void Update()
    {
        
    }
}
