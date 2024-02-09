using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nv1 : MonoBehaviour
{

    public Camera cam_anim;
    public GameObject cam_animGO;
    public float size = 600f;
    public float add = 0.00001f;

    // Start is called before the first frame update
    void Start()
    {
        cam_anim.orthographicSize = size;
        cam_animGO.SetActive(true);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (size > 2)
        {
            Anim_Base();
        }
    }

    public void Anim_Base()
    {
        size = size/(1+add);
        add = add / 1.0017f;
        cam_anim.orthographicSize = size;
        if (size <2.1f)
        {
            cam_animGO.SetActive(false);
        }
    }
}
