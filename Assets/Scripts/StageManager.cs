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

    public StageLevelSO[] stageLevels;
    public StageLevelSO CurrentStageLevel;

    public int StageLevelInt;

    void Start()
    {
        CurrentStageLevel = stageLevels[StageLevelInt];
        _3DTiles.Clear(); // Extention...
        _parent.Clear();
        CreateTrap();
    }

    void CreateTrap()
    {
        int max = _positions.Length;
        for (int i = 0; i < max; i++)
        {
            GameObject clone = Instantiate(_mines[Random.Range(0, _mines.Length)], _positions[i].position, Quaternion.identity);

            clone.transform.parent = _parent;
        }
    }

    public void CreateCurrentState(StageLevelSO currentState)
    {
        List<GameObject> gameObjectTraps = new List<GameObject>();
        for (int i = 0; i < currentState.TrapAmount; i++)
        {
            GameObject clone = Instantiate(_mines[Random.Range(0, _mines.Length)], _positions[i].position, Quaternion.identity);

            gameObjectTraps.Add(clone);
        }

        List<GameObject> gameObjectCollectibles = new List<GameObject>();
        for (int i = 0; i < currentState.CollectibleNumber; i++)
        {
            GameObject clone = Instantiate(_mines[Random.Range(0, _mines.Length)], _positions[i].position, Quaternion.identity);

            gameObjectCollectibles.Add(clone);
        }

        for (int i = currentState.TrapAmount; i < _positions.Length; i++)
        {
            gameObjectCollectibles[i].transform.position = _positions[i].position;
        }
        UTILS.Shuffle(gameObjectCollectibles);

        for (int i = 0; i < currentState.TrapAmount; i++)
        {
            gameObjectTraps[i].transform.position = _positions[i].position;
            gameObjectTraps[i].transform.parent = _parent;
        }

    }

}

/*
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
*/