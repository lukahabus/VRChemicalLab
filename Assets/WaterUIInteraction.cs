using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class WaterUIInteraction : MonoBehaviour
{
    public Button gumb;
    public Canvas platnoZaIskljuciti;
    public List<Canvas> listaPlatna;
    public GameObject lonac;
    private float fillAmount;
    private GlassContainerController glassContainerController;

    private void Start()
    {
        platnoZaIskljuciti = GetComponent<Canvas>();
        lonac = GetComponent<GameObject>();
        gumb.onClick.AddListener(PerformOnClick);
    }

    void PerformOnClick()
    {
        glassContainerController = (GlassContainerController) lonac.GetComponent("GlassContainerController");
        if (glassContainerController)
        {
            fillAmount = glassContainerController.GetLiquidShaderFillAmount();
            if (gumb.IsActive() && fillAmount > 0.240)
            {
                platnoZaIskljuciti.enabled = false;
                foreach (Canvas c in listaPlatna)
                {
                    c.enabled = true;
                }
            }
        }
        
    }
}
