using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QGVersNiv1 : MonoBehaviour
{
    public GameObject refUI;
    public GameObject refJoueur;

    // Start is called before the first frame update
    void Start()
    {
        refUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            refUI.SetActive(true);
        }
    }
    public void revenir()
    {
        refUI.SetActive(false);
    }
    public void changerScene()
    {
        SceneManager.LoadScene("DEATHRUN");
    }
}
