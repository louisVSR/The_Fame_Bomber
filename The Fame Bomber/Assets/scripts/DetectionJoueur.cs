using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionJoueur : MonoBehaviour
{
    [Tooltip("ref du joueur")]
    public GameObject refJoueur;

    private void OnTriggerEnter(Collider other)
    {
        //Lancer un linecast depuis drone jusque milieu joueur
        //Si ce n'est pas le joueur, alors il n'est pas rep�r�

        RaycastHit hit;
        bool detected = false;
        // On lance un rayon depuis la position de spotLight dans sa direction "avant"
        if (Physics.Linecast(transform.position, refJoueur.transform.position, out hit))
        {
            // Si l'objet touch� est le joueur alors il est d�tect�
            if (hit.transform.gameObject.tag == "Player")
                detected = true;
        }
        // Code permettant de d�tecter le Joueur (vu dans l��tape 4 exercice 2 �)
        /*if (detected)
            ControleNiveau.getInstance().perdre();*/

        if (detected)
        {
            //Debug.Log("Joueur rep�r� !");
            //refJoueur.GetComponent<ControleJoueur>().Repere();
        }


    }
    
}
