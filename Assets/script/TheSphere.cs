using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheSphere : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody Rigidbody;
    public float MaxSpeed = 50;
    float BrakeSpeed;
    public float Acceleration ;
    float Deceleration;
    float previousSpeed = 0;
    public float CurrentSpeed = 0;
    public float RotateSpeed = 90;
    public ParticleSystem frictionParticule;
    Camera playercam;
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Deceleration = MaxSpeed / 3;
        BrakeSpeed = MaxSpeed / 1.5f;
        Acceleration = MaxSpeed ;
        playercam = Camera.main;
    }

   
    void Update()
    {

        Move();


    }

    private void Move()
    {
        Vector3 Jump = Vector3.zero;
        if (Input.GetKey(KeyCode.S))
        {
            CurrentSpeed -= BrakeSpeed * Time.deltaTime;
            if (CurrentSpeed < 0)
            {
                CurrentSpeed = 0;
            }
        }
        else if (Input.GetKey(KeyCode.W))
        {
            CurrentSpeed += Acceleration * Time.deltaTime;

            if (CurrentSpeed > MaxSpeed)
            {
                CurrentSpeed = MaxSpeed;
            }
        }
        else
        {
            if (CurrentSpeed > 0)
            {
                CurrentSpeed -= Deceleration * Time.deltaTime;
                if (CurrentSpeed < 0)
                {
                    CurrentSpeed = 0;
                }
            }
        }

        // particule manager
        if(CurrentSpeed >= MaxSpeed / 3)
        {
            frictionParticule.Play();
            
            
            
            float pourcentLifetime = CurrentSpeed / MaxSpeed;
            frictionParticule.startLifetime = 0.25f * pourcentLifetime;
        }
        else
        {
            frictionParticule.Stop();
        }


        //Vector3 projedcam = Vector3.ProjectOnPlane(playercam.transform.forward, Vector3.up);
        Vector3 finalVelo = playercam.transform.forward;

        Rigidbody.velocity = finalVelo * CurrentSpeed;
    }
}
