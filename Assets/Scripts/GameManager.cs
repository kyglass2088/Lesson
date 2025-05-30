using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public GameObject[] Traps = new GameObject[3];

    [SerializeField] Transform _parent;

    const int EasyLevelTrapInt = 5;
    const int NormalLevelTrapInt = 6;
    const int HardLevelTrapInt = 8;

    public Transform[] easyPosition = new Transform[EasyLevelTrapInt];
    public Transform[] normalPosition = new Transform[NormalLevelTrapInt];
    public Transform[] hardPosition = new Transform[HardLevelTrapInt];
    int MaxTrapNumbers = 15;

    void Start()
    {
        CreateTrapsTutorial();
    }

    void CreateTrapsTutorial()
    {
        for (int i = 0; i < EasyLevelTrapInt; i++)
        {
            GameObject clone = Instantiate(Traps[Random.Range(0, 3)], easyPosition[i].position, Quaternion.identity);
            clone.transform.parent = _parent;

        }
    }

    void CreateTrapsStageOne()
    {
        for (int i = 0; i < NormalLevelTrapInt; i++)
        {
            GameObject clone = Instantiate(Traps[Random.Range(0, 3)], normalPosition[i].position, Quaternion.identity);
            clone.transform.parent = _parent;
            // CommonTrap.TrapDamage = 15

        }
    }

    void CreateTrapsStageTwo()
    {
        for (int i = 0; i < HardLevelTrapInt; i++)
        {
            GameObject clone = Instantiate(Traps[Random.Range(0, 3)], hardPosition[i].position, Quaternion.identity);
            clone.transform.parent = _parent;
            // CommonTrap.TrapDamage = 25

        }
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.E))
        {
            CreateTrapsStageOne();
        }

        if (Input.GetKeyUp(KeyCode.H))
        {
            CreateTrapsStageTwo();
        }
    }


}
