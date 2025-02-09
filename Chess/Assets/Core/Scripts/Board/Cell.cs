using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;

    private MaterialPropertyBlock materialPropertyBlock;

    public void Initialize(bool isBlack)
    {
        materialPropertyBlock = new();
        SetColor(isBlack);
    }

    private void SetColor(bool isBlack)
    {
        meshRenderer.GetPropertyBlock(materialPropertyBlock);
        materialPropertyBlock.SetColor("_BaseColor", isBlack ? Color.black : Color.white);
        meshRenderer.SetPropertyBlock(materialPropertyBlock);
    }
}