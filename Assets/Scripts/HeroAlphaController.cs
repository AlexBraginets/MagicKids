using UnityEngine;

public class HeroAlphaController : MonoBehaviour
{
    [SerializeField] private Renderer[] renderers;

    private const int AlphaPropertyIndex = 5;

    private int _alphaPropertyID = -1;
    private int alphaPropertyID
    {
        get
        {
            if (_alphaPropertyID == -1)
            {
                _alphaPropertyID = renderers[0].material.shader.GetPropertyNameId(AlphaPropertyIndex);
            }
            return _alphaPropertyID;
        }
    }
    public void ApplyAlpha(float alpha)
    {
        foreach (var r in renderers)
        {
            r.material.SetFloat(alphaPropertyID, alpha);
        }
    }
}
