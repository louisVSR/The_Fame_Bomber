using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class joueur : MonoBehaviour
{
    //script temporaire : le mouvement de la camera et les deplacements vont etre retravaillés.
    public float speed = 5;
    public float MousSpeed = 50f;
    public float rotCamX = 0f;
    public float rotY = 0f;
    public bool grounded = true;
    public bool isLinked = false;
    public bool debug = false;

    public GameObject cam;
    public Rigidbody rb;
    public Animator anim;
    public CapsuleCollider col;

    private Vector3 posDepart;
    private Quaternion rotDepart;


    // Start is called before the first frame update
    void Start()
    {
        //Get the animator, which you attach to the GameObject you are intending to animate.
        Cursor.visible = true;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();

        posDepart = transform.position;
        rotDepart = transform.rotation;
    }

    void Update()
    {
        grounded = IsGrounded();
        if (isLinked || grounded)
        {
            jump();
        }
        rotCamX = Input.GetAxisRaw("Mouse Y");
        rotY = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3(0, rotY, 0) * MousSpeed;
        Vector3 Camrotation = new Vector3(rotCamX, 0, 0) * MousSpeed;
        Rotation(rotation);
        RotCamera(Camrotation);
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
    }

    public void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            anim.SetTrigger("saut");
        }
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool isMoving = Anim();

        if (!isMoving)
        {
            anim.SetBool("avant", false);
            anim.SetBool("arriere", false);
            anim.SetBool("gauche", false);
            anim.SetBool("droite", false);
        }
    }

    public void Rotation(Vector3 rot)
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rot));
    }

    public void RotCamera(Vector3 rot)
    {
        cam.transform.Rotate(-rot);
    }

    public bool IsGrounded()
    {
        return Physics.Raycast(col.bounds.center, -Vector3.up, col.bounds.extents.y + 0.01f); ;
    }

    public bool Anim()
    {
        bool res = false;

        if (Input.GetKey(KeyCode.O))
        {
            transform.position = new Vector3(0, 3, 0);
            Debug.Log("coucouccccccc");
            
        }
       

        if (Input.GetKey(KeyCode.W)) // Avant
        {
            rb.MovePosition(rb.position + (transform.forward * speed) * Time.fixedDeltaTime);
            //transform.Translate(Vector3.forward * Time.deltaTime * speed);
            anim.SetBool("avant", true);
            res = true;
        }
        else if (Input.GetKey(KeyCode.S)) // Arriere
        {
            rb.MovePosition(rb.position + (-transform.forward.normalized * speed) * Time.fixedDeltaTime);
            // transform.Translate(-Vector3.forward * Time.deltaTime * speed);
            anim.SetBool("arriere", true);
            res = true;
        }
        if (Input.GetKey(KeyCode.A)) // Gauche
        {
            rb.MovePosition(rb.position + (-transform.right * speed) * Time.fixedDeltaTime);
            //transform.Translate(Vector3.left * Time.deltaTime * speed);
            anim.SetBool("gauche", true);
            res = true;

        } else if (Input.GetKey(KeyCode.D)) // Droite
        {
            rb.MovePosition(rb.position + (transform.right * speed) * Time.fixedDeltaTime);
            //transform.Translate(Vector3.right * Time.deltaTime * speed);
            anim.SetBool("droite", true);
            res = true;
        }

        return res;
       
    }


    //Pour le Niveau 2
    public void Repere()
    {
        transform.position = posDepart;
        transform.rotation = rotDepart;
    }
}
