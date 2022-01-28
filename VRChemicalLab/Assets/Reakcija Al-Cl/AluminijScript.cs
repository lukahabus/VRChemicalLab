using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AluminijScript : MonoBehaviour
{
    public int zari = 0;
    public float burnoutSpeed = 3f;
    public float shrinkSpeed = 9f;
    Vector3 temp;

    void Start()
    {
        
    }

    void Update()
    {
        if (zari >= 1)
        {
            if (this.gameObject.GetComponent<Renderer>().material.color.r > 0)
            {
                Color objectColor = this.gameObject.GetComponent<Renderer>().material.color;
                float burnAmount = objectColor.r - Time.deltaTime / burnoutSpeed;

                objectColor = new Color(burnAmount, objectColor.g, objectColor.b, objectColor.a);
                this.gameObject.GetComponent<Renderer>().material.color = objectColor;
            }
            if (this.gameObject.GetComponent<Renderer>().material.color.g > 0)
            {
                Color objectColor = this.gameObject.GetComponent<Renderer>().material.color;
                float burnAmount = objectColor.g - Time.deltaTime / burnoutSpeed;

                objectColor = new Color(objectColor.r, burnAmount, objectColor.b, objectColor.a);
                this.gameObject.GetComponent<Renderer>().material.color = objectColor;
            }
            if (this.gameObject.GetComponent<Renderer>().material.color.b > 0)
            {
                Color objectColor = this.gameObject.GetComponent<Renderer>().material.color;
                float burnAmount = objectColor.b - Time.deltaTime / burnoutSpeed;

                objectColor = new Color(objectColor.r, objectColor.g, burnAmount, objectColor.a);
                this.gameObject.GetComponent<Renderer>().material.color = objectColor;
            }
            if (this.gameObject.GetComponent<Renderer>().material.color.r < 0.1 &&
                this.gameObject.GetComponent<Renderer>().material.color.g < 0.1 &&
                this.gameObject.GetComponent<Renderer>().material.color.b < 0.1)
            {
                zari = 2;
            }
        }
        if (zari == 2)
        {
            temp = transform.localScale;

            if (temp.x > 0)
            {
                temp.x = temp.x - Time.deltaTime / shrinkSpeed;
            }
            if (temp.y > 0)
            {
                temp.y = temp.y - Time.deltaTime / shrinkSpeed;
            }
            if (temp.z > 0)
            {
                temp.z = temp.z - Time.deltaTime / shrinkSpeed;
            }
            transform.localScale = temp;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 18)
        {
            zari = 1;
        }
    }
}
