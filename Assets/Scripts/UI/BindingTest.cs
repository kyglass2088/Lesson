using UnityEngine;

public class BindingTest : MonoBehaviour
{
     public PlayerData playerData;

    void Update()
    {
        if (Input.GetKey(KeyCode.N))
        {
            playerData.HP = 9;
        }
        if (Input.GetKey(KeyCode.O))
        {
            playerData.HP = 100;
        }
    }
}
