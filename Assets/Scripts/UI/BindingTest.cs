using UnityEngine;

public class BindingTest : MonoBehaviour
{
     public PlayerData playerData;

    void Update()
    {
        if (Input.GetKey(KeyCode.N))
        {
            playerData.Life = 5;
        }
        if (Input.GetKey(KeyCode.O))
        {
            int a = playerData.Life;
        }
    }
}
