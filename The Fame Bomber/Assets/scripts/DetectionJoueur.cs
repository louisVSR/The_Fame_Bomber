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
        //Si ce n'est pas le joueur, alors il n'est pas repéré

        RaycastHit hit;
        bool detected = false;
        // On lance un rayon depuis la position de spotLight dans sa direction "avant"
        if (Physics.Linecast(transform.position, refJoueur.transform.position, out hit))
        {
            // Si l'objet touché est le joueur alors il est détecté
            if (hit.transform.gameObject.tag == "Player")
                detected = true;
        }
        // Code permettant de détecter le Joueur (vu dans l’étape 4 exercice 2 …)
        /*if (detected)
            ControleNiveau.getInstance().perdre();*/

        if (detected)
        {
            //Debug.Log("Joueur repéré !");
            //refJoueur.GetComponent<ControleJoueur>().Repere();
        }


    }
    
}
