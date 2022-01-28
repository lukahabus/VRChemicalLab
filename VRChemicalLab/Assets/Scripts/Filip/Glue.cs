using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glue : MonoBehaviour
{
    private int numOfBalls;
    public Transform pozicijaGume;
    public GameObject gumaObjekt;
    public float fadeSpeed;

    //01 - veliki / 02- srednji / 03 - mali
    public ParticleSystem[] smoke;

    HashSet<string> allowed;
    private bool natrij;

    // Start is called before the first frame update
    void Start()
    {
        natrij = false;
        numOfBalls = 0;
        allowed = new HashSet<string>();

        for (int i = 0; i < 3; i++)
        {
            smoke[i].Pause();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (numOfBalls >= 7 && natrij)
        {
            smoke[1].Stop();
            smoke[0].Play();

            StartCoroutine(createShape());
            numOfBalls = 0;
        }

        if (numOfBalls >= 1 && numOfBalls < 4)
        {
            smoke[2].Play();
        }

        if (numOfBalls >= 4)
        {
            smoke[2].Stop();
            smoke[1].Play();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11)
        {

            if (!allowed.Contains(other.name))
            {
                allowed.Add(other.name);
                StartCoroutine(destroyObject(other.gameObject));
            }

        }

        if (other.gameObject.layer == 12)
        {
            StartCoroutine(destroyObject(other.gameObject));
        }

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

        if (ob.name.StartsWith("F"))
        {
            numOfBalls++;
        }
        else if (ob.name.StartsWith("K"))
        {
            natrij = true;
        }

        //Destroy(ob);
    }

    IEnumerator createShape()
    {
        GameObject guma = Instantiate(gumaObjekt, pozicijaGume.position, pozicijaGume.rotation);

        while (guma.GetComponent<Renderer>().material.color.a < 1)
        {
            Color objectColor = guma.GetComponent<Renderer>().material.color;
            float fadeAmount = objectColor.a + Time.deltaTime / fadeSpeed;

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            guma.GetComponent<Renderer>().material.color = objectColor;

            yield return null;
        }

        smoke[0].Stop();
    }
}
