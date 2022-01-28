using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class CanvasRemoveScript : MonoBehaviour
{
    public Button disableButton;
    public Canvas canvas;
    public List<Canvas> canvasList;

    private void Start()
    {
        canvas = GetComponent<Canvas>();
        disableButton.onClick.AddListener(TaskOnClick);
    }
    // Update is called once per frame
    void Update()
    {

    }
    void TaskOnClick()
    {
        if (disableButton.IsActive())
        {
            canvas.enabled = false;
            foreach (Canvas c in canvasList)
            {
                c.enabled = true;
            }
        }
    }
}
