using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class joueur : NetworkBehaviour
{
    //script temporaire : le mouvement de la camera et les deplacements vont etre retravaillés.
    public float speed = 5;
    public float MousSpeed = 3f;
    public float rotCamX = 0f;
    public float rotY = 0f;
    public bool grounded = true;

    public GameObject cam;
    public Rigidbody rb;
    public Animator anim;
    public CapsuleCollider col;

    private Vector3 posDepart;
    private Vector3 rotDepart;


    // Start is called before the first frame update
    void Start()
    {
        //Get the animator, which you attach to the GameObject you are intending to animate.
        Cursor.visible = false;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();

        posDepart = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isLocalPlayer)
        {
            bool isMoving = Anim();
            grounded = IsGrounded();
            if (!isMoving)
            {
                anim.SetBool("avant", false);
                anim.SetBool("arriere", false);
                anim.SetBool("gauche", false);
                anim.SetBool("droite", false);
            }
            rotCamX += Input.GetAxis("Mouse Y") * -MousSpeed;
            rotY += Input.GetAxis("Mouse X") * MousSpeed;
            cam.transform.localEulerAngles = new Vector3(rotCamX, 0, 0);
            transform.localEulerAngles = new Vector3(0, rotY, 0);
        }

    }

    public bool IsGrounded()
    {
        return Physics.Raycast(col.bounds.center, -Vector3.up, col.bounds.extents.y + 0.01f); ;
    }

    public bool Anim()
    {
        bool res = false;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Debug.Log("moooonstre");
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            anim.SetTrigger("saut");
        }

        if (Input.GetKey(KeyCode.W)) // Avant
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            anim.SetBool("avant", true);
            res = true;
        }
        else if (Input.GetKey(KeyCode.S)) // Arriere
        {
            transform.Translate(-Vector3.forward * Time.deltaTime * speed);
            anim.SetBool("arriere", true);
            res = true;
        }
        if (Input.GetKey(KeyCode.A)) // Gauche
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            anim.SetBool("gauche", true);
            res = true;

        } else if (Input.GetKey(KeyCode.D)) // Droite
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            anim.SetBool("droite", true);
            res = true;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("avant", false);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("arriere", false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetBool("droite", false);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetBool("gauche", false);
        }

        return res;
       
    }


    //Pour le Niveau 2
    public void Repere()
    {
        //Si repéré, le joueur revient au départ
        transform.position = posDepart;

        //rajouter la direction du personnage
    }
}
