using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassContainerController : MonoBehaviour
{
    public GameObject GlassLiquid;
    public GameObject HolePoint;
    public float fillIncrement = 0.33f;
    private float fillAmount;
    public float startingFillAmount = 0.284f;
    public GameObject waterDropletPrefab;
    public bool isInfiniteSource = false;
    public bool Visible = true;
    public Color StartingSideColor;
    public Color StartingTopColor;
    Material liquidMaterial;
    MeshRenderer liquidMeshRenderer;
    MeshRenderer meshRenderer;

    // Start is called before the first frame update
    IEnumerator SpawnLiquidParticle()
    {
        while (true)
        {
            float absRotX = Mathf.Abs(transform.rotation.eulerAngles.x);
            float absRotZ = Mathf.Abs(transform.rotation.eulerAngles.z);
            if (fillAmount > .192)
            {
                if ((absRotX > 90 && absRotX < 270) || (absRotZ > 90 && absRotZ < 270))
                {
                    if (!isInfiniteSource)
                    {
                        IncrementFillAmount(-fillIncrement);
                    }
                    GameObject droplet = Instantiate(waterDropletPrefab, HolePoint.transform.position, Quaternion.identity);
                    WaterDropletBillboard dropletController = droplet.GetComponent<WaterDropletBillboard>();
                    //Debug.Log(dropletController);
                    dropletController.SetColor(GetSideColor());
                    dropletController.SideColor = GetSideColor();
                    dropletController.TopColor = GetTopColor();
                    //Debug.Log(dropletController.SideColor);
                }
            } else
            {

            }
            yield return new WaitForSeconds(.33f);
        }
    }
    void Start()
    {
        fillAmount = startingFillAmount;
        liquidMaterial = GlassLiquid.GetComponent<Renderer>().material;
        meshRenderer = GetComponent<MeshRenderer>();
        liquidMeshRenderer = GlassLiquid.GetComponent<MeshRenderer>();
        SetSideColor(StartingSideColor);
        SetTopColor(StartingTopColor);
        StartCoroutine(SpawnLiquidParticle());
        HandleVisibility();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLiquidShader();
        HandleVisibility();
    }
    public Material GetLiquidMaterial()
    {
        return liquidMaterial;
    }
    public float GetLiquidShaderFillAmount()
    {
        return liquidMaterial.GetFloat("Vector1_a30bf3cdb53a4a6b871f0e97d2f6073f");
    }
    private void UpdateLiquidShader()
    {
        liquidMaterial.SetFloat("Vector1_a30bf3cdb53a4a6b871f0e97d2f6073f", fillAmount);
    }
    public void IncrementFillAmount(float fillIncrement)
    {
        fillAmount += fillIncrement;
    }
    public void UpdateColor(float fillIncrement, Color TopColor, Color SideColor)
    {
        Color tc = GetTopColor(), sc = GetSideColor();
        if (Mathf.Abs(fillIncrement) < 0.001) return;
        SetTopColor(Color.Lerp(tc, TopColor, fillIncrement / fillAmount));
        SetSideColor(Color.Lerp(sc, SideColor, fillIncrement / fillAmount));
    }
    public Color GetTopColor()
    {
        return liquidMaterial.GetColor("_TopColor");
    }
    public void SetTopColor(Color color)
    {
        liquidMaterial.SetColor("_TopColor", color);
    }
    public Color GetSideColor()
    {
        return liquidMaterial.GetColor("_SideColor");
    }
    public void SetSideColor(Color color)
    {
        liquidMaterial.SetColor("_SideColor", color);
    }
    private void HandleVisibility()
    {
        meshRenderer.enabled = Visible;
        liquidMeshRenderer.enabled = Visible;
    }
}
