using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboFollow : MonoBehaviour
{
    public GameObject target1;
    public GameObject target;
    public GameObject target2;
    public GameObject body;
    private Vector3 targetPos;
    public float speed = .6f;
    public float maxSpeed = 10f;
    public float bodyRotSpeed = 60f;
    //public float maxSpeedRot = 10f;
    
    private float initialSpeed;
    private bool isFollowing = false;
    public float minDisttoTarget = 1f;
    public float incDist = 20f;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        initialSpeed = speed;
        player = GameObject.FindGameObjectWithTag("Player");
        target = player;

    }

    // Update is called once per frame
    void Update()
    {
        //target.transform.position = player.transform.position;
       // target.transform.position.z = player.transform.position.z -2;
        targetPos = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);


    }

    private void LateUpdate()
    {

        if (Vector3.Distance(transform.position, targetPos) > minDisttoTarget)
        {
            StartCoroutine("startMov");
        }
        else
        {
            isFollowing = false;
        }
        if (isFollowing)
        {
            //minDisttoTarget = incDist;
            speed = Mathf.Lerp(speed, maxSpeed, Time.deltaTime * 1);
            //bodyRotSpeed = Mathf.Lerp(minSpeedRot, maxSpeedRot, Time.deltaTime * 1);

            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            body.transform.Rotate(bodyRotSpeed * Time.deltaTime, 0, 0);
        }
    }
    IEnumerator startMov()
    {
       //Debug.Log("incSpeed called " );
        yield return new WaitForSeconds(1f);
        isFollowing = true;
    }
    IEnumerator stopMov()
    {
        //Debug.Log("incSpeed called " );
        yield return new WaitForSeconds(1f);
        isFollowing = false;
    }

    public void switchtarget()
    {
        if(target == target1)
        {
            target = target2;
        }
        else 
        {
            target = target1;
        }
    }

}
