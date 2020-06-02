using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float multiplier = 0.7f;
    public float duration = 2f;

    public GameObject pickupEffect;
    public GameObject smokeEffect;
    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
           StartCoroutine( Pickup(other) );

        }
    }

    IEnumerator Pickup(Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        Instantiate(smokeEffect, transform.position, transform.rotation);


        player.transform.localScale *= multiplier;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        Component halo = GetComponent("Halo"); 
        halo.GetType().GetProperty("enabled").SetValue(halo, false, null);


        yield return new WaitForSeconds(duration);

        player.transform.localScale /= multiplier;

        Destroy(gameObject);
    }
}
