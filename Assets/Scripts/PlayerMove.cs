using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;

    public float mouseSenseX = 1f;
    public float mouseSenseY = 1f;

    // limit view angle, no 360 noscope
    float verticalLookRotation;

    Transform mainCam;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        // prevents mouse pointing from moving out of game window
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        mainCam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSenseX);
        verticalLookRotation += Input.GetAxis("Mouse Y") * mouseSenseY;

        // limit view 80 degrees up or down
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -80, 80);

        // make camera look up or down
        mainCam.localEulerAngles = Vector3.left * verticalLookRotation;

        if (Input.GetKey("w"))
        {
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey("s"))
        {
            transform.position -= transform.forward * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey("d"))
        {
            transform.position += transform.right * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey("a"))
        {
            transform.position -= transform.right * Time.deltaTime * moveSpeed;
        }
    }
}
