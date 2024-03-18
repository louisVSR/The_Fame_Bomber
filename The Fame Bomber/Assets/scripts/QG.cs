using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QG : MonoBehaviour
{
    public GameObject refUIHistoire;

    // Start is called before the first frame update
    void Start()
    {
        refUIHistoire.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void commencerHistoire()
    {
        refUIHistoire.SetActive(false);
    }
}
