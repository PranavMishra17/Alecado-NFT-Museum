using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallColTrigger : MonoBehaviour
{
    public RoboFollow rf;
    public RoboTalk rt;
    // Start is called before the first frame update
    void Start()
    {
        rf = GetComponent<RoboFollow>();
        rt = GetComponent<RoboTalk>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider co)
    {
        if (co.tag == "Wall")
        {
            rf.switchtarget();
        }
    }
    public void OnTriggerExit(Collider co)
    {
        if (co.tag == "Wall")
        {
            rf.switchtarget();
        }
    }
}
