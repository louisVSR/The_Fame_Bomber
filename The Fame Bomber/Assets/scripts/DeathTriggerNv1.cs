using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTriggerNv1 : MonoBehaviour
{

    private Vector3 RespawnPosition0 = new Vector3(1.77f, -2.3f, -3.13f);
    private Vector3 RespawnPosition1 = new Vector3(9,10,13.6f);
    private Vector3 RespawnPosition2 = new Vector3(14.6f, 24.5f, 63.2f);
    private Vector3 RespawnPosition3;
    private List<List<GameObject>> lst;
    private List<int> lst2 = new List<int>(3);
    //lst list contenant a l'indice 0 la liste des joueurs ayant atteint le checkpoint 1, etc.

    public void Start()
    {
        Debug.Log(lst2.Count);
        lst = new List<List<GameObject>>(3);
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("deja ca c bon.");
        
        if (tag == "check1")
        {
            if (!lst[0].Contains(other.gameObject))
            {
                lst[0].Add(other.gameObject);
            }
        }
        else if (tag == "check2")
        {
            if (!lst[1].Contains(other.gameObject))
            {
                lst[1].Add(other.gameObject);
            }
        }
        else if (tag == "check3")
        {
            if (!lst[2].Contains(other.gameObject))
            {
                lst[2].Add(other.gameObject);
            }
        }
        else
        {
            if (other.gameObject.tag == "Player")
            {
                Debug.Log(lst.Count);
                //mort : on peut egalement ajouter un element graphique.
                if (lst[2].Count > 0 && lst[2].Contains(other.gameObject))
                {
                    other.transform.position = RespawnPosition3;
                }
                else if (lst[1].Count > 0 && lst[1].Contains(other.gameObject))
                {
                    other.transform.position = RespawnPosition2;
                }else if (lst[0].Count > 0 && lst[0].Contains(other.gameObject))
                {
                    other.transform.position = RespawnPosition1;
                }
                else
                {
                    other.transform.position = RespawnPosition0;
                }

                //rotation marche pas.
                other.transform.eulerAngles = new Vector3(0, -17.65f, 0);
                other.transform.rotation = new Quaternion(0, -17.65f, 0, 0);
            }
        }
    }
}
