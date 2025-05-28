using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public GameObject[] Traps = new GameObject[3];
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
        for (int i = 0; i < MaxTrapNumbers; i++)
        {
            GameObject clone = Instantiate(Traps[Random.Range(0, 3)], position[i].position, Quaternion.identity);
            clone.transform.parent = _parent;

        }
    }

}
