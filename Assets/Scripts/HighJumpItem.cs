using UnityEngine;
using UnityEngine.UIElements;

public class HighJumpItem : MonoBehaviour
{
    [SerializeField] MeshRenderer meshRenderer;

    public Player player;

    void Start()
    {
        meshRenderer.enabled = false;
        Lever.OnLeverEvent += ShowItem;
    }

    void ShowItem()
    {
        meshRenderer.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("User") && meshRenderer.enabled)
        {
            Debug.Log("HighJumpItem");
            player.playerData.JumpForce += 10.0f;
        }
    }
}
