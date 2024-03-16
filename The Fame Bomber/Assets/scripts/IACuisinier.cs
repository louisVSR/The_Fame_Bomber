using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    private float compteur;
    private float aAttendre;

    public TextMeshPro text;

    // Start is called before the first frame update
    void Start()
    {
        position = 0;
        nma = GetComponent<NavMeshAgent>();
        nma.SetDestination(wayPoints[position].transform.position);
        etat = MOUVEMENT;
        text = GetComponentInChildren<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if (etat==ATTENTE)
        {
            compteur += Time.deltaTime;
            //text.SetText("Cuisine");
            if (compteur > aAttendre) 
            {
                etat = MOUVEMENT;
                position = (position + 1) % wayPoints.Count;
                nma.SetDestination(wayPoints[position].transform.position);
            }
            else
            {
                //text.SetText("");
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.layer == 7) && (nma.remainingDistance<0.5))
        {
            etat = ATTENTE;
            compteur = 0;
            aAttendre = other.gameObject.GetComponent<wpControler>().tempsAttente;
        }
    }
}
