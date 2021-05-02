using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMotor : MonoBehaviour
{
    public Rigidbody rb;

     [SerializeField]
    private GameObject cam;

    private Vector3 velocity = Vector3.zero;

    private float cameraRotataionLimit = 85;
    private Vector3 rotation = Vector3.zero;

    private float CamerarotationX = 0f;

    private float currentCamerarotationX = 0f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;



    }

    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;




    }

    public void RotateCamera(float _rotation)
    {
        CamerarotationX = _rotation;



    }



    void FixedUpdate()
    {
        //Debug.Log(velocity);
        // cam.transform.position=new Vector3(bodyPosition.transform.position.x,cam.transform.position.y,bodyPosition.transform.position.z);
        PerformMovement();
        PerformRotation();
        PerformCameraRotation();


    }

    void PerformMovement()
    {

        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }


    void PerformRotation()
    {

        if (rotation != Vector3.zero)
        {

            transform.rotation = rb.rotation * Quaternion.Euler(rotation);




        }


    }
    void PerformCameraRotation()
    {
       

            currentCamerarotationX -= CamerarotationX;
            currentCamerarotationX = Mathf.Clamp(currentCamerarotationX, -cameraRotataionLimit, cameraRotataionLimit);
          //  Debug.Log(currentCamerarotationX);
            cam.transform.localEulerAngles = new Vector3(currentCamerarotationX, 0f, 0f);

    }




}
