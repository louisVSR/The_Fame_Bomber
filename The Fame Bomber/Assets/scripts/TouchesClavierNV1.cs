using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchesClavierNV1 : MonoBehaviour
{

    public int signeDeplacement = 1;
    public float speed = 5;
    public float currentPos = 0;
    private Vector3 PosDiff;


    // Start is called before the first frame update
    void Start()
    {
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

    public void OnCollisionEnter(Collision collision)
    {
        PosDiff = new Vector3(transform.position.x - collision.transform.position.x,0, transform.position.z - collision.transform.position.z);

    }

    public void OnCollisionStay(Collision collision)
    {
        Debug.Log("Marche");
        //collision.transform.Translate(new Vector3(signeDeplacement * speed * Time.deltaTime, 0, 0));
        collision.transform.position = new Vector3(transform.position.x - PosDiff.x, collision.transform.position.y, transform.position.z - PosDiff.z);
    }

}
