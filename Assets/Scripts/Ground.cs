using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer meshRenderer;

    private void Update()
    {
        float speed = GameManager.Instance.GameSpeed / transform.localScale.x;
        meshRenderer.material.mainTextureOffset += speed * Time.deltaTime * Vector2.right;
    }
}
