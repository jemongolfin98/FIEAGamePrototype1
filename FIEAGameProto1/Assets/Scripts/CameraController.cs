using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Transform bg1a;
    public Transform bg2a;
    public Transform bg3a;
    public Transform bg4a;
    public Transform bg1b;
    public Transform bg2b;
    public Transform bg3b;
    public Transform bg4b;
    public Transform p1a;
    public Transform p1b;
    public Transform p2a;
    public Transform p2b;

    private float sizeB1;
    private float sizeB2;
    private float sizeB3;
    private float sizeB4;
    private float sizeP1;
    private float sizeP2;

    //Initializing the location of the pieces of the environemnt (background, camera, parameters)
    private Vector3 cameraTargetPos = new Vector3();
    private Vector3 bg1aTargetPos = new Vector3();
    private Vector3 bg2aTargetPos = new Vector3();
    private Vector3 bg3aTargetPos = new Vector3();
    private Vector3 bg4aTargetPos = new Vector3();
    private Vector3 bg1bTargetPos = new Vector3();
    private Vector3 bg2bTargetPos = new Vector3();
    private Vector3 bg3bTargetPos = new Vector3();
    private Vector3 bg4bTargetPos = new Vector3();
    private Vector3 p1aTargetPos = new Vector3();
    private Vector3 p1bTargetPos = new Vector3();
    private Vector3 p2aTargetPos = new Vector3();
    private Vector3 p2bTargetPos = new Vector3();


    void Start()
    {
        sizeB1 = bg1a.GetComponent<BoxCollider2D>().size.x;
        sizeB2 = bg2a.GetComponent<BoxCollider2D>().size.x;
        sizeB3 = bg3a.GetComponent<BoxCollider2D>().size.x;
        sizeB4 = bg4a.GetComponent<BoxCollider2D>().size.x;
        sizeP1 = p1a.GetComponent<BoxCollider2D>().size.x;
        sizeP2 = p2a.GetComponent<BoxCollider2D>().size.x;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

        //Allows the horizontally locked continuous movement of the camera
        Vector3 targetPos = SetPos(cameraTargetPos, target.position.x, 0, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPos, 0.2f);

        //Allows the continuous movement of the background imaages
        if (transform.position.x >= bg1b.position.x)
        {
            bg1a.position = SetPos(bg1aTargetPos, bg1b.position.x + sizeB1, bg1a.position.y, bg1a.position.z);
            SwitchBg1();
        }

        if (transform.position.x < bg1a.position.x)
        {
            bg1b.position = SetPos(bg1bTargetPos, bg1a.position.x - sizeB1, bg1a.position.y, bg1a.position.z);
        }

        if (transform.position.x >= bg2b.position.x)
        {
            bg2a.position = SetPos(bg2aTargetPos, bg2b.position.x + sizeB2, bg2a.position.y, bg2a.position.z);
            SwitchBg2();
        }

        if (transform.position.x < bg2a.position.x)
        {
            bg2b.position = SetPos(bg2bTargetPos, bg2a.position.x - sizeB2, bg2a.position.y, bg2a.position.z);
        }

        if (transform.position.x >= bg3b.position.x)
        {
            bg3a.position = SetPos(bg3aTargetPos, bg3b.position.x + sizeB3, bg3a.position.y, bg3a.position.z);
            SwitchBg3();
        }

        if (transform.position.x < bg3a.position.x)
        {
            bg3b.position = SetPos(bg3bTargetPos, bg3a.position.x - sizeB3, bg3a.position.y, bg3a.position.z);
        }

        if (transform.position.x >= bg4b.position.x)
        {
            bg4a.position = SetPos(bg4aTargetPos, bg4b.position.x + sizeB4, bg4a.position.y, bg4a.position.z);
            SwitchBg4();
        }

        if (transform.position.x < bg4a.position.x)
        {
            bg4b.position = SetPos(bg4bTargetPos, bg4a.position.x - sizeB4, bg4a.position.y, bg4a.position.z);
        }


        //Parameters
        if (transform.position.x >= p1b.position.x)
        {
            p1a.position = SetPos(p1aTargetPos, p1b.position.x + sizeP1, p1a.position.y, p1a.position.z);
            SwitchParameter1();
        }

        if (transform.position.x < p1a.position.x)
        {
            p1b.position = SetPos(p1bTargetPos, p1a.position.x - sizeP1, p1b.position.y, p1b.position.z);
        }

        if (transform.position.x >= p2b.position.x)
        {
            p2a.position = SetPos(p2aTargetPos, p2b.position.x + sizeP2, p2a.position.y, p2a.position.z);
            SwitchParameter2();
        }

        if (transform.position.x < p2a.position.x)
        {
            p2b.position = SetPos(p2bTargetPos, p2a.position.x - sizeP2, p2b.position.y, p2b.position.z);
        }

    }

    public void SwitchBg1()
    {
        Transform temp = bg1a;
        bg1a = bg1b;
        bg1b = temp;
    }

    public void SwitchBg2()
    {
        Transform temp = bg2a;
        bg2a = bg2b;
        bg2b = temp;
    }

    public void SwitchBg3()
    {
        Transform temp = bg3a;
        bg3a = bg3b;
        bg3b = temp;
    }

    public void SwitchBg4()
    {
        Transform temp = bg4a;
        bg4a = bg4b;
        bg4b = temp;
    }


    public void SwitchParameter1()
    {
        Transform temp3 = p1a;
        p1a = p1b;
        p1b = temp3;
    }

    public void SwitchParameter2()
    {
        Transform temp3 = p2a;
        p2a = p2b;
        p2b = temp3;
    }

    private Vector3 SetPos(Vector3 pos, float x, float y, float z)
    {
        pos.x = x;
        pos.y = y;
        pos.z = z;
        return pos;
    }
}