using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoboTalk : MonoBehaviour
{
    public AudioClip yestalk;
    public AudioSource auds;
    public HeadFollow hf;
    Image img;

    [SerializeField] public AudioClip[] SoundEffect;
    [SerializeField] public string[] obName;

    public bool takeTalkInput = false;
    public GameObject talkUI;
    string ii;
    public string qqq;
    bool qOpen = false;
    bool firstMeet = false;
    public int currentEnv = 0;
    GameObject qObj;

    // Start is called before the first frame update
    void Start()
    {
        auds = GetComponent<AudioSource>();
        hf = GetComponentInChildren<HeadFollow>();
        talkUI = GameObject.FindWithTag("talk");

        ii = talkUI.GetComponentInChildren<Text>().text;
        img = talkUI.GetComponent<Image>();
        talkUI.SetActive(false);
        qObj = GameObject.FindWithTag("q");
        qObj.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (takeTalkInput)
        {
            if (Input.GetKey("t"))
            {
                qOpen = true;
                hf.lookAtCameraDirection = false;
                hf.lookAtPlayer = true;
                talkUI.GetComponentInChildren<Text>().text = qqq;
                img.rectTransform.sizeDelta = new Vector2(1100, 50);
                qObj.SetActive(true);
                //StartCoroutine("startTalk");
            }
            if (qOpen)
            {
                if (Input.GetKey("1") && !auds.isPlaying)
                {
                    auds.PlayOneShot(SoundEffect[currentEnv]);
                }
                if (Input.GetKey("2") && !auds.isPlaying)
                {
                    auds.PlayOneShot(SoundEffect[9]);
                }
                if (Input.GetKey("3") && !auds.isPlaying)
                {
                    auds.PlayOneShot(SoundEffect[10]);
                }
                if (Input.GetKey("4"))
                {
                    talkUI.GetComponentInChildren<Text>().text = ii;
                    qOpen = false;
                    talkUI.SetActive(false);
                    img.rectTransform.sizeDelta = new Vector2(500, 50);
                    qObj.SetActive(false);
                }
            }
        }
        if(talkUI == null)
        {
            talkUI = GameObject.FindWithTag("talk");
            Debug.Log("talkUI null");
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
        if (co.tag == "Player" )
        {
            takeTalkInput = true;
            talkUI.SetActive(true);
            Debug.Log("Player collided");
            if( !firstMeet && !auds.isPlaying)
            {
                auds.PlayOneShot(SoundEffect[0]);
                firstMeet = true;
            }
        }
        if (co.name == obName[0] && !auds.isPlaying)
        {
            auds.PlayOneShot(SoundEffect[0]);
        }
        if (co.name == obName[1] && !auds.isPlaying)
        {
            auds.PlayOneShot(SoundEffect[1]);
        }
        if (co.name == obName[2] && !auds.isPlaying)
        {
            auds.PlayOneShot(SoundEffect[2]);
        }
        if (co.name == obName[3] && !auds.isPlaying)
        {
            auds.PlayOneShot(SoundEffect[3]);
        }
        if (co.name == obName[4] && !auds.isPlaying)
        {
            auds.PlayOneShot(SoundEffect[4]);
        }
        if (co.name == obName[5] && !auds.isPlaying)
        {
            auds.PlayOneShot(SoundEffect[5]);
        }
        if (co.name == obName[6] && !auds.isPlaying)
        {
            auds.PlayOneShot(SoundEffect[6]);
        }
        if (co.name == obName[7] && !auds.isPlaying)
        {
            auds.PlayOneShot(SoundEffect[7]);
        }
        if (co.name == obName[8] && !auds.isPlaying)
        {
            auds.PlayOneShot(SoundEffect[8]);
        }
    }
    public void OnTriggerExit(Collider co)
    {
        if (co.tag == "Player")
        {
            takeTalkInput = false;
            talkUI.GetComponentInChildren<Text>().text = ii;
            talkUI.SetActive(false);
            qOpen = false;
            img.rectTransform.sizeDelta = new Vector2(500, 50);
            qObj.SetActive(false);
        }
    }
}
