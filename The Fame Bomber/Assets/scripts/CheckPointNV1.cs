using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointNV1 : MonoBehaviour
{

    public GameObject manager;

    public void OnTriggerEnter(Collider other)
    {
        if (tag == "check1")
        {
            if (!manager.GetComponent<DeathTriggerNv1>().lst[0].Contains(other.gameObject))
            {
                manager.GetComponent<DeathTriggerNv1>().lst[0].Add(other.gameObject);
            }
        }
        else if (tag == "check2")
        {
            if (!manager.GetComponent<DeathTriggerNv1>().lst[1].Contains(other.gameObject))
            {
                manager.GetComponent<DeathTriggerNv1>().lst[1].Add(other.gameObject);
            }
        }
        else
        {
            if (!manager.GetComponent<DeathTriggerNv1>().lst[2].Contains(other.gameObject))
            {
                manager.GetComponent<DeathTriggerNv1>().lst[2].Add(other.gameObject);
            }
        }
    }
}