using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadFollow : MonoBehaviour
{
    public float headRotSpeed = 1f;
    public bool lookAtCameraDirection = true;
    public bool lookAtPlayer = false;
    public GameObject player;
    private Vector3 _dir;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (lookAtCameraDirection)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Camera.main.transform.rotation, headRotSpeed * Time.deltaTime);
        }
        else if (lookAtPlayer)
        {
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, player.transform.position, headRotSpeed * Time.deltaTime);
            _dir = player.transform.position - gameObject.transform.position;
            _dir.Normalize();
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_dir), headRotSpeed* 0.2f * Time.deltaTime);
            //transform.RotateAround(player.transform);
        }

    }
}
