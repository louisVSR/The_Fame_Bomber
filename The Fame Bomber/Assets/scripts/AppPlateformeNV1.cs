using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppPlateformeNV1 : MonoBehaviour
{

    public Rigidbody rb;
    public float posyBase;
    public float posy;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        posyBase = transform.position.y;
        rb.useGravity = false;
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        posy = transform.position.y;
        if (posy < -150)
        {
            ResetPos();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //animation shaking
            Invoke("Falling", 0.5f);
        }
    }

    public void Falling()
    {
        //anim false
        Debug.Log("coucou");
        rb.useGravity = true;
        rb.isKinematic = false;
    }

    public void ResetPos()
    {
        rb.useGravity = false;
        rb.isKinematic = true;
        transform.position = new Vector3(transform.position.x, posyBase, transform.position.z);
    }
}
