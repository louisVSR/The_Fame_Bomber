using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class IACuisinier : MonoBehaviour
{
    public List<GameObject> wayPoints = new List<GameObject>();
    private int position;
    private NavMeshAgent nma;

    private int etat;
    private const int MOUVEMENT = 0;
    private const int ATTENTE = 1;
    private const int SETOURNERVERS = 2;
    private float compteur;
    private float aAttendre;
    private Quaternion pos;

    public TextMeshPro text;

    void Start()
    {
        position = 0;
        nma = GetComponent<NavMeshAgent>();
        nma.SetDestination(wayPoints[position].transform.position);
        etat = MOUVEMENT;
        text = GetComponentInChildren<TextMeshPro>();
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
            }

        }
        if (etat == SETOURNERVERS)
        {
            compteur++;
            this.transform.rotation = Quaternion.Lerp(pos, wayPoints[position].transform.rotation, compteur / 30);
            if (this.transform.rotation == wayPoints[position].transform.rotation)
            {
                etat = ATTENTE;
                compteur = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.layer == 7) && (nma.remainingDistance < 0.5))
        {
            etat = SETOURNERVERS;
            compteur = 0;
            aAttendre = other.gameObject.GetComponent<wpControler>().tempsAttente;
            pos = transform.rotation;
        }
    }
}
