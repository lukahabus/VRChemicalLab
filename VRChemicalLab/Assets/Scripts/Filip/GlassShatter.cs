using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassShatter : MonoBehaviour
{
    public Transform shatteredObject;
    public float magnitudeCol, power;

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

        if(collision.relativeVelocity.magnitude > magnitudeCol)
        {
            Destroy(this.gameObject);
            Transform shards = Instantiate(shatteredObject, this.transform.position, this.transform.rotation);
            shards.localScale = this.transform.localScale;

            Vector3 explosionPosition = this.transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPosition, 1);

            foreach(Collider hit in colliders)
            {
                if(hit.attachedRigidbody)
                {
                    hit.attachedRigidbody.AddExplosionForce(power * collision.relativeVelocity.magnitude, explosionPosition, 1, 1);
                } 
            }

            Destroy(shards.gameObject, 5);

        }
        
    }
}
