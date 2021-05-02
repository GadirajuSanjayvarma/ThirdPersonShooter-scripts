using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update
         public Animator anim;
          public float smoothBlend;
        public playerMotor motor;
        [SerializeField]

    private float speed = 5f;
    public float lookSensitivity;
    void Start()
    {
           motor = gameObject.GetComponent<playerMotor>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (Application.isMobilePlatform)
        {
            mobileInput();
        }
        else
        {
            pcInput();
        }

       
    }

    void mobileInput()
    {
    }

    
    void pcInput()
    {
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");
    

         
        anim.SetFloat("forward", _zMov,smoothBlend,Time.deltaTime);
        anim.SetFloat("sideways", _xMov,smoothBlend,Time.deltaTime);
    
        Vector3 _movHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.forward * _zMov;

        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        //apply movement
        motor.Move(_velocity);

        float _yRot = Input.GetAxisRaw("Mouse X");
      

      
        Vector3 _rotation = new Vector3(0f,  _yRot, 0f) * lookSensitivity;

        motor.Rotate(_rotation);
        float _xRot = Input.GetAxisRaw("Mouse Y");
       
        float _Camerarotation = _xRot *lookSensitivity;

        motor.RotateCamera(_Camerarotation);

       
    
    }





}
