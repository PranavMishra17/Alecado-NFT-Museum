using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyFollow : MonoBehaviour
{
    public float bodyRotSpeed = 10f;
    public GameObject target;
    public RoboFollow rf;
    Quaternion yourRotationQuaternion;
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

            //transform.rotation = Quaternion.LookRotation(relativePos, Vector3.up);
           // relativePos.x = 0;
           // relativePos.z = 0;
            relativePos.Normalize();
            
            //Debug.Log(relativePos);
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(relativePos), bodyRotSpeed * 0.2f * Time.deltaTime);

            yourRotationQuaternion = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(relativePos), bodyRotSpeed * 0.2f * Time.deltaTime);

            yourRotationQuaternion = Quaternion.Euler(new Vector3(0f, yourRotationQuaternion.eulerAngles.y, 0f));

            transform.rotation = yourRotationQuaternion;

        }

    }
}
