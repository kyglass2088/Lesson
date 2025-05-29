using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public GameObject[] Traps = new GameObject[3];

    [SerializeField] Transform _parent;

    public Transform[] position = new Transform[7];
    // public Transform[] easyPosition = new Transform[9];
    // public Transform[] hardPosition = new Transform[12];
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

    void CreateTrapsStageOne()
    {
        for (int i = 0; i < MaxTrapNumbers; i++)
        {
            GameObject clone = Instantiate(Traps[Random.Range(0, 3)], position[i].position, Quaternion.identity);
            clone.transform.parent = _parent;
            // CommonTrap.TrapDamage = 15

        }
    }

    void CreateTrapsStageTwo()
    {
        for (int i = 0; i < MaxTrapNumbers; i++)
        {
            GameObject clone = Instantiate(Traps[Random.Range(0, 3)], position[i].position, Quaternion.identity);
            clone.transform.parent = _parent;
            // CommonTrap.TrapDamage = 25

        }
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.A))
        {
            CreateTrapsStageOne();
        }

        if (Input.GetKeyUp(KeyCode.B))
        {
            CreateTrapsStageTwo();
        }
    }


}
