using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTriggerNv1 : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //mort : on peut egalement ajouter un element graphique.
            collision.transform.position = new Vector3(1.77f, -2.3f, -3.13f);
            collision.gameObject.transform.eulerAngles =new Vector3(0, -17.65f, 0);
            Vector3 rotation = collision.transform.eulerAngles;
        }
    }
}
