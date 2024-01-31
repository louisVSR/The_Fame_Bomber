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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * Time.deltaTime * speed);
        }

        rotCamX += Input.GetAxis("Mouse Y") * -MousSpeed;
        rotY += Input.GetAxis("Mouse X") * MousSpeed;
        cam.transform.localEulerAngles = new Vector3(rotCamX, 0, 0);
        transform.localEulerAngles = new Vector3(0, rotY, 0);

    }
}
