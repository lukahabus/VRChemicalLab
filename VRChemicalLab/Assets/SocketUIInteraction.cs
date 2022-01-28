using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class SocketUIInteraction : MonoBehaviour
{
    public Button dugme;
    public Canvas platno;
    public List<Canvas> platna;
    public List<MeshRenderer> prikazivaci;

    private void Start()
    {
        platno = GetComponent<Canvas>();
        dugme.onClick.AddListener(DoOnClick);
    }
    // Update is called once per frame
    void Update()
    {

    }
    void DoOnClick()
    {
        int brojRenderanih = 0;
        if (dugme.IsActive())
        {
            foreach (MeshRenderer r in prikazivaci)
            {
                if (r.enabled == false)
                {
                    brojRenderanih++;
                }
            }
            if (brojRenderanih == prikazivaci.Count)
            {
                platno.enabled = false;
                foreach (Canvas c in platna)
                {
                    c.enabled = true;
                }
            }
        }
    }
}
