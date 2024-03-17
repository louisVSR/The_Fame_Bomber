using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchesClavierNV1 : MonoBehaviour
{

    public int signeDeplacement = 1;
    public float speed = 5;
    public float currentPos = 0;
    public Vector3 PosDiff;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPos > 5)
        {
            signeDeplacement = -1;
            currentPos -= speed * Time.deltaTime;
        }
        else if (currentPos < - 5)
        {
            signeDeplacement = 1;
            currentPos += speed * Time.deltaTime;
        } else
        {
            transform.Translate(new Vector3(signeDeplacement*speed*Time.deltaTime,0,0));
          
           currentPos += signeDeplacement * speed * Time.deltaTime;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 tmp = other.gameObject.transform.position;
            PosDiff = new Vector3(tmp.x - transform.position.x, 0, tmp.z -transform.position.z);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 tmp = other.gameObject.transform.position;
            other.gameObject.transform.position = new Vector3(transform.position.x + PosDiff.x, tmp.y, transform.position.z + PosDiff.z);
        }
    }

}
