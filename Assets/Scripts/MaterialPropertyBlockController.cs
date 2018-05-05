using UnityEngine;

public class MaterialPropertyBlockController : MonoBehaviour
{
    private Renderer _renderer;
    private Renderer Renderer
    {
        get { return _renderer ?? (_renderer = GetComponent<Renderer>()); }
    }

    private MaterialPropertyBlock _materialPropertyBlock;
    private MaterialPropertyBlock MaterialPropertyBlock
    {
        get { return _materialPropertyBlock ?? (_materialPropertyBlock = new MaterialPropertyBlock()); }
    }

    public void SetColor(string propertyName, Color color)
    {
        MaterialPropertyBlock.SetColor(propertyName, color);
    }

    public void SetFloat(string propertyName, float value)
    {
        MaterialPropertyBlock.SetFloat(propertyName, value);
    }

    public void Apply()
    {
        Renderer.SetPropertyBlock(MaterialPropertyBlock);
    }
}
