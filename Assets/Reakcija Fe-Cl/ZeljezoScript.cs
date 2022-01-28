using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeljezoScript : MonoBehaviour
{
    public GameObject ZeljezoKlor = null;
    public Transform spawnPos = null;
    public int zazari = 0;

    public float fadeSpeed = 9f;
    public float burnSpeed = 7f;
    public float burnoutSpeed = 4f;
    public float shrinkSpeed = 5f;

    Vector3 temp;

    void Start()
    {
    }
    void Update()
    {
        
        if (zazari == 1)
        {
            
            if (this.gameObject.GetComponent<Renderer>().material.color.r < 1)
            {
                Color objectColor = this.gameObject.GetComponent<Renderer>().material.color;
                float burnAmount = objectColor.r + Time.deltaTime / burnSpeed;

                objectColor = new Color(burnAmount, objectColor.g, objectColor.b, objectColor.a);
                this.gameObject.GetComponent<Renderer>().material.color = objectColor;
            }
            if (this.gameObject.GetComponent<Renderer>().material.color.g < 0.2961104)
            {
                Color objectColor = this.gameObject.GetComponent<Renderer>().material.color;
                float burnAmount = objectColor.g + Time.deltaTime / burnSpeed;

                objectColor = new Color(objectColor.r, burnAmount, objectColor.b, objectColor.a);
                this.gameObject.GetComponent<Renderer>().material.color = objectColor;
            }
            if (this.gameObject.GetComponent<Renderer>().material.color.b > 0.135849)
            {
                Color objectColor = this.gameObject.GetComponent<Renderer>().material.color;
                float burnAmount = objectColor.b - Time.deltaTime / burnSpeed;

                objectColor = new Color(objectColor.r, objectColor.g, burnAmount, objectColor.a);
                this.gameObject.GetComponent<Renderer>().material.color = objectColor;
            }

            if (this.gameObject.GetComponent<Renderer>().material.color.r >= 1 &&
                this.gameObject.GetComponent<Renderer>().material.color.g >= 0.2961104 &&
                this.gameObject.GetComponent<Renderer>().material.color.b <= 0.135849)
            {
                zazari = 2;
                
            }
        }
        if (zazari == 2)
        {
            temp = transform.localScale;
            if (temp.x < 0.11)
            {
                temp.x = temp.x + Time.deltaTime / (shrinkSpeed / 3);
            }
            if (temp.y > 0.0195)
            {
                temp.y = temp.y - Time.deltaTime / shrinkSpeed;
            }
            if (temp.z < 0.0975)
            {
                temp.z = temp.z + Time.deltaTime / shrinkSpeed;
            }
            transform.localScale = temp;

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
        }
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 18)
        {
            zazari = 1;
            StartCoroutine(destroyObject(collision.gameObject));

            Reakcija();
        }
    }


    public void Reakcija()
    {
        GameObject clone = (GameObject)Instantiate(ZeljezoKlor, spawnPos.position, spawnPos.rotation);
    }

    IEnumerator destroyObject(GameObject ob)
    {

        while (ob.GetComponent<Renderer>().material.color.a > 0)
        {

            Color objectColor = ob.GetComponent<Renderer>().material.color;
            float fadeAmount = objectColor.a - Time.deltaTime / fadeSpeed;

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            ob.GetComponent<Renderer>().material.color = objectColor;

            yield return null;

        }
    }
}

