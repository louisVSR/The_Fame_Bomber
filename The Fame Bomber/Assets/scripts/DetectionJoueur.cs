using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionJoueur : MonoBehaviour
{
    [Tooltip("ref du joueur")]
    public GameObject refJoueur;

    private void OnTriggerEnter(Collider other)
    {
        RaycastHit hit;
        bool detected = false;
        if (Physics.Linecast(transform.position, refJoueur.transform.position, out hit))
        {
            if (hit.transform.gameObject.tag == "Player")
                detected = true;
        }

        if (detected)
        {
            refJoueur.GetComponent<joueur>().Repere();
        }


    }
    
}
