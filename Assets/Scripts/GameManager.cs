using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public GameObject MoveTrapPrefab;
    public GameObject HiddenInstanceKillTrapPrefab;
    public GameObject HiddenTrapPrefab;

    [SerializeField] Transform _parent;

    int TrapNumbers = 5;
    public Transform[] position = new Transform[15];
    int MaxTrapNumbers = 15;

    void Start()
    {
        CreateTraps();
    }

    void CreateTraps()
    {
        for (int i = 0; i < MaxTrapNumbers; i += Random.Range(1, 3))
        {
            GameObject clone = Instantiate(MoveTrapPrefab, position[i].position, Quaternion.identity);
            clone.transform.parent = _parent;

        }
    }

}
