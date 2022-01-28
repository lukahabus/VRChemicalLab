using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KockaNatrija : MonoBehaviour
{
    public ParticleSystem vatra;
    private bool burnedOut = false;

    // Start is called before the first frame update
    void Start()
    {
        vatra.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if (burnedOut)
        {
            StartCoroutine(destroySodium());
        }
    }

    //u reakciji s vodom
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 4)
        {
            vatra.Play();

            StartCoroutine(stopFire());
        }
    }

    IEnumerator stopFire()
    {
        yield return new WaitForSeconds(12f);

        vatra.Stop();
        burnedOut = true;

    }

    IEnumerator destroySodium()
    {
        yield return new WaitForSeconds(1.2f);
        Destroy(this.gameObject);
    }
}
