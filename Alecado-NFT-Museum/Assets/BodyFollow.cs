using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyFollow : MonoBehaviour
{
    public float bodyRotSpeed = 10f;
    public GameObject target;
    public RoboFollow rf;
    private void Start()
    {
        rf = GetComponentInParent<RoboFollow>();
        target = rf.target;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 relativePos = target.transform.position - transform.position;
        //Debug.Log("relative Pos: " + relativePos);
        //relativePos.x = 0;
        //relativePos.z = 0;

        if ( Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("w") || Input.GetKey("d"))
        {
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, Camera.main.transform.rotation, bodyRotSpeed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(relativePos, Vector3.up);


        }

    }
}
