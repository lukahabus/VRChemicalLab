using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassHoleLiquidCollector : MonoBehaviour
{
    GlassContainerController controller;
    Material liquidMaterial;
    public float fillIncrement = 0.33f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponentInParent<GlassContainerController>();
    }
}

