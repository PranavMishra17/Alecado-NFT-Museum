using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboTalk : MonoBehaviour
{
    public AudioClip yestalk;
    public AudioSource auds;
    public HeadFollow hf;

    [SerializeField] public AudioClip[] SoundEffect;
    [SerializeField] public string[] tags;

    public bool takeTalkInput = false;
    public GameObject talkUI;
    // Start is called before the first frame update
    void Start()
    {
        auds = GetComponent<AudioSource>();
        hf = GetComponentInChildren<HeadFollow>();
        talkUI = GameObject.FindGameObjectWithTag("talk");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("t") && takeTalkInput)
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

    public void OnTriggerEnter(Collider co)
    {
        if (co.tag == "Player")
        {
            takeTalkInput = true;
        }
        if (co.tag == tags[0])
        {
            auds.PlayOneShot(SoundEffect[0]);
        }
        if (co.tag == tags[1])
        {
            auds.PlayOneShot(SoundEffect[1]);
        }
        if (co.tag == tags[2])
        {
            auds.PlayOneShot(SoundEffect[2]);
        }
        if (co.tag == tags[3])
        {
            auds.PlayOneShot(SoundEffect[3]);
        }
        if (co.tag == tags[4])
        {
            auds.PlayOneShot(SoundEffect[4]);
        }
        if (co.tag == tags[5])
        {
            auds.PlayOneShot(SoundEffect[5]);
        }
        if (co.tag == tags[6])
        {
            auds.PlayOneShot(SoundEffect[6]);
        }
        if (co.tag == tags[7])
        {
            auds.PlayOneShot(SoundEffect[7]);
        }
        if (co.tag == tags[8])
        {
            auds.PlayOneShot(SoundEffect[8]);
        }
    }
    public void OnTriggerExit(Collider co)
    {
        if (co.tag == "Player")
        {
            takeTalkInput = false;
        }
    }
}
