using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboFollow : MonoBehaviour
{

    public GameObject target;
    public GameObject body;
    private Vector3 targetPos;
    public float speed = .6f;
    public float bodyRotSpeed = 60f;
    private float initialSpeed;
    private bool isFollowing = false;

    // Start is called before the first frame update
    void Start()
    {
        initialSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

        if (Vector3.Distance(transform.position, targetPos) > 1)
        {
            StartCoroutine("startMov");
        }
        else isFollowing = false;



        if (isFollowing)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            body.transform.Rotate(bodyRotSpeed * Time.deltaTime, 0, 0);
        }
        // else speed = initialSpeed;

    }

    IEnumerator startMov()
    {
       //Debug.Log("incSpeed called " );
        yield return new WaitForSeconds(1.2f);
        isFollowing = true;
    }

}
