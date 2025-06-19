using UnityEngine;
using UnityEngine.UIElements;

public class HighJumpItem : MonoBehaviour
{
    [SerializeField] MeshRenderer meshRenderer;

    public PlayerData playerData;

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
        if (other.gameObject.CompareTag("User") && meshRenderer)
        {
            playerData.JumpForce *= 5.0f;
        }
    }
}
