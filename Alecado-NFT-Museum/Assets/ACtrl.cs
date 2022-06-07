using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACtrl : MonoBehaviour
{
    Animator chAnim;

    CharacterController characterController;

    public float speed = 6.0f;

    private Vector3 moveDirection = Vector3.zero;

    [SerializeField] private float _mouseSensitivity = 50f;
    [SerializeField] private float _minCameraview = -70f, _maxCameraview = 80f;
    private Camera _camera;
    private float xRotation = 0f;


    // Start is called before the first frame update
    void Start()
    {
        chAnim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();

        _camera = Camera.main;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("w") || Input.GetKey("d"))
        {
            chAnim.SetBool("isWalking", true);

            if (Input.GetKey("left shift"))
            {
                chAnim.SetBool("isRunning", true);
            }
            else chAnim.SetBool("isRunning", false);
        }
        else chAnim.SetBool("isWalking", false);

        if (Input.GetKey("e"))
        {
            chAnim.SetBool("isLooking", true);
        }
        else chAnim.SetBool("isLooking", false);


    }
}
