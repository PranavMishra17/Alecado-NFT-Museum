using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboTalk : MonoBehaviour
{
    public AudioClip yestalk;
    public AudioSource auds;
    public HeadFollow hf;
    // Start is called before the first frame update
    void Start()
    {
        auds = GetComponent<AudioSource>();
        hf = GetComponentInChildren<HeadFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("t"))
        {
            hf.lookAtCameraDirection = false;
            hf.lookAtPlayer = true;
            StartCoroutine("startTalk");
        }
    }
    IEnumerator startTalk()
    {
        yield return new WaitForSeconds(0.6f);
        auds.PlayOneShot(yestalk);
        
        StartCoroutine("stopTalk");
    }
    IEnumerator stopTalk()
    {
        yield return new WaitForSeconds(0.6f);
        hf.lookAtCameraDirection = true;
        hf.lookAtPlayer = false;
    }
}
