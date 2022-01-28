using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class TPScript : MonoBehaviour
{
    public Button gumb;
    public Transform Teleport1;

    private void Start()
    {
        //botun = GetComponent<Button>();
        gumb.onClick.AddListener(TaskOnClick);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void TaskOnClick()
    {
        if (gumb.IsActive())
        {
            transform.position = Teleport1.position;
        }
    }

    

}