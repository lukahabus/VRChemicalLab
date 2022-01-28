using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayForKemEl : MonoBehaviour
{
    public KemijskiElement kemEl;

    // Start is called before the first frame update
    void Start()
    {
        setColor();
    }

    private void Update()
    {

    }
    public void setColor()
    {
        gameObject.GetComponent<Renderer>().material.color = kemEl.boja;
    }

}
