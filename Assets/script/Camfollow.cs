using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Camfollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 Offset = Vector3.zero;
    public Transform Target;
    Vector3 Velocity =  Vector3.zero;
    private float TimeSmooth = 0.0f;
    float RotateSpeed = 90;
    public Vector3 VisualRotation = new Vector3(0,0,0);
    float PrevMp = 0;
    void Start()
    {
        PrevMp = Input.mousePosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(Target != null)
        {
           

            Vector3 TargetPosition = Target.position+Offset;
            

            if (Input.GetKey(KeyCode.D))
            {
                this.transform.RotateAround(Target.position, Target.transform.up, RotateSpeed * Time.deltaTime);
                this.transform.parent.GetChild(0).RotateAround(Target.position, Target.transform.up, RotateSpeed * Time.deltaTime);
                Vector3 targetVisuelRot = new Vector3(0, this.transform.eulerAngles.y + VisualRotation.y, 0);
                this.transform.parent.GetChild(0).eulerAngles = targetVisuelRot;

            }
            else if (Input.GetKey(KeyCode.A))
            {
                this.transform.RotateAround(Target.position, Target.transform.up, -RotateSpeed * Time.deltaTime);
                this.transform.parent.GetChild(0).RotateAround(Target.position, Target.transform.up, -RotateSpeed * Time.deltaTime );
                Vector3 targetVisuelRot = new Vector3(0, this.transform.eulerAngles.y - VisualRotation.y, 0);
                this.transform.parent.GetChild(0).eulerAngles = targetVisuelRot;

            }else
            {
                //this.transform.parent.GetChild(0).eulerAngles = this.transform.eulerAngles;
                Vector3 temporaryEuler = this.transform.eulerAngles;
                temporaryEuler.x = 0;
                this.transform.parent.GetChild(0).eulerAngles = temporaryEuler;
            }

            /*if(Input.GetMouseButton(1))
            {
                float Mp = Input.mousePosition.y;
                if(Mp>PrevMp)
                {
                    this.transform.RotateAround(Target.position, Target.transform.right, -RotateSpeed * Time.deltaTime);
                }else if(Mp<PrevMp)
                {
                    this.transform.RotateAround(Target.position, Target.transform.right, RotateSpeed * Time.deltaTime);
                }
                PrevMp = Mp;
            }*/


            this.transform.LookAt(Target.position);
        }
       
    }
}
