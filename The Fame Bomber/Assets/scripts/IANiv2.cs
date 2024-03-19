using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class IANiv2 : MonoBehaviour
{
    public List<GameObject> wayPoints = new List<GameObject>();
    private int position;
    private NavMeshAgent nma;

    public int etat;
    private const int MOUVEMENT = 0;
    private const int ATTENTE = 1;
    private const int SETOURNERVERS = 2;
    private float compteur;
    private float aAttendre;
    public int nbFrames;
    private Quaternion rotDepart;


    void Start()
    {
        position = 0;
        nma = GetComponent<NavMeshAgent>();
        nma.SetDestination(wayPoints[position].transform.position);
        etat = MOUVEMENT;
        nbFrames = 0;
        compteur = 0f;
    }

    void Update()
    {
        if (etat == ATTENTE)
        {
            compteur += Time.deltaTime;
            if (compteur > aAttendre)
            {
                etat = MOUVEMENT;
                position = (position + 1) % wayPoints.Count;
                nma.SetDestination(wayPoints[position].transform.position);
                compteur = 0f;
            }

        }
        if (etat == SETOURNERVERS)
        {
            nbFrames++;
            this.transform.rotation = Quaternion.Lerp(rotDepart, wayPoints[position].transform.rotation, nbFrames / 30f);
            if (nbFrames >= 30)
            {
                etat = ATTENTE;
                nbFrames = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.layer == 7) && (nma.remainingDistance < 0.5))
        {
            etat = SETOURNERVERS;
            compteur = 0f;
            nbFrames = 0;
            aAttendre = other.gameObject.GetComponent<wpControler>().tempsAttente;
            rotDepart = transform.rotation;
        }
    }
}
