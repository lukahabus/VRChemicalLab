using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KlorScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 17)
        {
            Destroy(this.gameObject, 9.0f);
        }
    }
}
