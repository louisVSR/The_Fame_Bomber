using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joueur : MonoBehaviour
{
    //script temporaire : le mouvement de la camera et les deplacements vont etre retravaillés.
    public float speed = 5;
    public float MousSpeed = 3f;
    public float rotCamX = 0f;
    public float rotY = 0f;

    public GameObject cam;
    public Animator anim;
    public bool conflitAv;
    public bool conflitAR;
    public bool conflitG;
    public bool conflitD;


    // Start is called before the first frame update
    void Start()
    {
        //Get the animator, which you attach to the GameObject you are intending to animate.
        anim = GetComponent<Animator>();
        conflitAv = false;
        conflitAR = false;
        conflitG = false;
        conflitD = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) // Avant
        {
            if (!conflitAR)
            {
                conflitAv = true;
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                anim.SetBool("avant", true);
            }
        }
        if (Input.GetKey(KeyCode.A)) // Gauche
        {
            if (!conflitD)
            {
                conflitG = true;
                transform.Translate(Vector3.left * Time.deltaTime * speed);
                anim.SetBool("gauche", true);
            }
        }
        if (Input.GetKey(KeyCode.D)) // Droite
        {
            if (!conflitG)
            {
                conflitD = true;
                transform.Translate(Vector3.right * Time.deltaTime * speed);
                anim.SetBool("droite", true);
            }
        }
        if (Input.GetKey(KeyCode.S)) // Arriere
        {
            if (!conflitAv)
            {
                conflitAR = true;
                transform.Translate(-Vector3.forward * Time.deltaTime * speed);
                anim.SetBool("arriere", true);
            }
        }
        
        else
        {
            anim.SetBool("avant", false);
            anim.SetBool("arriere", false);
            anim.SetBool("gauche", false);
            anim.SetBool("droite", false);
            conflitAv = false;
            conflitAR = false;
            conflitG = false;
            conflitD = false;

        }
        rotCamX += Input.GetAxis("Mouse Y") * -MousSpeed;
        rotY += Input.GetAxis("Mouse X") * MousSpeed;
        cam.transform.localEulerAngles = new Vector3(rotCamX, 0, 0);
        transform.localEulerAngles = new Vector3(0, rotY, 0);

    }
}
