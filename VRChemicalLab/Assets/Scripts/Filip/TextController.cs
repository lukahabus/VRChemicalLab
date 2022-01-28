using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    public GameObject floatingTextPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        string elementName = this.gameObject.name;
        Debug.Log(elementName);

        switch(elementName)
        {
            case "Kocka natrija":
                displayText("Natrij");
                break;

            case "Fluorescent dye":
                displayText("Flourokrom");
                break;
        }

    }

    private void displayText(string text)
    {
        if(floatingTextPrefab)
        {
            GameObject prefab = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);

            prefab.GetComponentInChildren<TextMesh>().text = text;

            Destroy(prefab, 3.1f);
        }
    }
}
