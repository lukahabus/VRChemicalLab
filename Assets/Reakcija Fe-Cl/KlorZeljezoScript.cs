using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KlorZeljezoScript : MonoBehaviour
{
    public float fadeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroyObject());
        Destroy(this.gameObject, 11.0f);
    }

    

    IEnumerator destroyObject()
    {
        yield return new WaitForSeconds(2f);

        while (this.gameObject.GetComponent<Renderer>().material.color.a > 0)
        {

            Color objectColor = this.gameObject.GetComponent<Renderer>().material.color;
            float fadeAmount = objectColor.a - Time.deltaTime / fadeSpeed;

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            this.gameObject.GetComponent<Renderer>().material.color = objectColor;

            yield return null;

        }
    }
}
