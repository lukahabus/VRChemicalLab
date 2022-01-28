using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumporScript : MonoBehaviour
{

    public int reakcija = 0;
    public float shrinkSpeed = 7f;
    public float burnSpeed = 6f;
    public float burnSpeed2 = 9f;
    Vector3 temp;

    void Start()
    {
        
    }

    void Update()
    {
        if (reakcija == 1)
        {
            temp = transform.localScale;

            if (temp.x > 0)
            {
                temp.x = temp.x - Time.deltaTime / (shrinkSpeed/3);
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
            StartCoroutine(yellowLiquid(collision.gameObject));
            StartCoroutine(redLiquid(collision.gameObject));
            reakcija = 1;
        }
    }

    IEnumerator yellowLiquid(GameObject ob)
    {

        yield return new WaitForSeconds(4f);

        while (ob.GetComponent<Renderer>().material.color.a < 0.9 ||
                ob.GetComponent<Renderer>().material.color.r > 0.7924528 ||
                ob.GetComponent<Renderer>().material.color.g > 0.5493066 ||
                ob.GetComponent<Renderer>().material.color.b > 0.07775006)
        {

            Color objectColor = ob.GetComponent<Renderer>().material.color;
            if (ob.GetComponent<Renderer>().material.color.r > 0.7924528)
            {
                float burnAmount = objectColor.r - Time.deltaTime / burnSpeed;
                objectColor = new Color(burnAmount, objectColor.g, objectColor.b, objectColor.a);
            }
            if (ob.GetComponent<Renderer>().material.color.g > 0.5493066)
            {
                float burnAmount = objectColor.g - Time.deltaTime / burnSpeed;
                objectColor = new Color(objectColor.r, burnAmount, objectColor.b, objectColor.a);
            }
            if (ob.GetComponent<Renderer>().material.color.b > 0.07775006)
            {
                float burnAmount = objectColor.b - Time.deltaTime / burnSpeed;
                objectColor = new Color(objectColor.r, objectColor.g, burnAmount, objectColor.a);
            }
            if (ob.GetComponent<Renderer>().material.color.a < 0.9)
            {
                float fadeAmount = objectColor.a + Time.deltaTime / burnSpeed;
                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            }

            ob.GetComponent<Renderer>().material.color = objectColor;

            yield return null;

        }
    }
    IEnumerator redLiquid(GameObject ob)
    {
        yield return new WaitForSeconds(7f);

        while (ob.GetComponent<Renderer>().material.color.r > 0.5377358 ||
                ob.GetComponent<Renderer>().material.color.g > 0.1268829 ||
                ob.GetComponent<Renderer>().material.color.b > 0.05783193)
        {

            Color objectColor = ob.GetComponent<Renderer>().material.color;
            if (ob.GetComponent<Renderer>().material.color.r > 0.5377358)
            {
                float burnAmount = objectColor.r - Time.deltaTime / burnSpeed2;
                objectColor = new Color(burnAmount, objectColor.g, objectColor.b, objectColor.a);
            }
            if (ob.GetComponent<Renderer>().material.color.g > 0.1268829)
            {
                float burnAmount = objectColor.g - Time.deltaTime / burnSpeed2;
                objectColor = new Color(objectColor.r, burnAmount, objectColor.b, objectColor.a);
            }
            if (ob.GetComponent<Renderer>().material.color.b > 0.05783193)
            {
                float burnAmount = objectColor.b - Time.deltaTime / burnSpeed2;
                objectColor = new Color(objectColor.r, objectColor.g, burnAmount, objectColor.a);
            }

            ob.GetComponent<Renderer>().material.color = objectColor;

            yield return null;

        }
    }
}
