using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GumaScript : MonoBehaviour
{
    public float glowingSpeed;

    //must be > 1f
    public float maxGlow;

    private float factor;
    private bool colliding;

    // Start is called before the first frame update
    void Start()
    {
        factor = 1f;
        colliding = false;
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10 && factor < maxGlow)
        {
            colliding = true;
            StartCoroutine(glowUp());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == 10)
        {
            colliding = false;
        }
    }

    IEnumerator glowUp()
    {
        while(factor <= maxGlow && colliding)
        {
            factor += 0.015f;

            Color color = this.GetComponent<Renderer>().material.color;
            color = new Color(color.r * factor, color.g * factor, color.b * factor, color.a);
            GetComponent<Renderer>().material.color = color;

            yield return new WaitForSeconds(glowingSpeed);
        }

    }

}
