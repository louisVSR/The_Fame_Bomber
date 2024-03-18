using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarteElecNV1 : MonoBehaviour
{
    public Rigidbody rb;

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        rb = collision.gameObject.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0, 13, 0),ForceMode.Impulse);
    }
}
