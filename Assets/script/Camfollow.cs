using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
    private TheSphere TheSphere;

    [Header("Paramètres de FOV")]
    [SerializeField] private int FovMin = 85;
    [SerializeField] private int FovMax = 105;

    // positions camera
    private Vector3 farCam;
    private Vector3 nearCam;
    [SerializeField] private float camSpeed = 300;
    private float _velocity = 0;


    void Start()
    {
        PrevMp = Input.mousePosition.y;
        TheSphere = this.transform.parent.parent.GetComponent<TheSphere>();

        // setup farcam et nearcam
        farCam = this.transform.localPosition + new Vector3(0f, 0f, -5f);
        nearCam = this.transform.localPosition - new Vector3(0f, 0f, 5f);

    }

    // Update is called once per frame
    void Update()
    {
        Fov();
        CamPos();



        if(Target != null)
        {

           

            Vector3 TargetPosition = Target.position+Offset;
            

            if (Input.GetKey(KeyCode.D))
            {
                this.transform.parent.RotateAround(Target.position, Target.transform.up, RotateSpeed * Time.deltaTime);
                this.transform.parent.parent.GetChild(0).RotateAround(Target.position, Target.transform.up, RotateSpeed * Time.deltaTime);
                Vector3 targetVisuelRot = new Vector3(0, this.transform.parent.eulerAngles.y + VisualRotation.y, 0);
                this.transform.parent.parent.GetChild(0).eulerAngles = targetVisuelRot;

            }
            else if (Input.GetKey(KeyCode.A))
            {
                this.transform.parent.RotateAround(Target.position, Target.transform.up, -RotateSpeed * Time.deltaTime);
                this.transform.parent.parent.GetChild(0).RotateAround(Target.position, Target.transform.up, -RotateSpeed * Time.deltaTime );
                Vector3 targetVisuelRot = new Vector3(0, this.transform.parent.eulerAngles.y - VisualRotation.y, 0);
                this.transform.parent.parent.GetChild(0).eulerAngles = targetVisuelRot;

            }else
            {
                //this.transform.parent.GetChild(0).eulerAngles = this.transform.eulerAngles;
                /*Vector3 temporaryEuler = this.transform.parent.eulerAngles;
                temporaryEuler.x = 0;
                this.transform.parent.parent.GetChild(0).eulerAngles = temporaryEuler;*/
                transform.parent.parent.GetChild(0).eulerAngles = new Vector3(0f, transform.parent.eulerAngles.y, transform.parent.eulerAngles.z);
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


    void Fov()
    {
        // changement de FOV suivant la vitesse
        float i = TheSphere.CurrentSpeed / TheSphere.MaxSpeed;
        this.GetComponent<Camera>().fieldOfView = Mathf.Lerp(FovMin, FovMax, i);
    }

    void CamPos()
    {
        this.transform.localPosition = new Vector3(0f, 0f, Mathf.SmoothDamp(this.transform.localPosition.z, -TheSphere._acceleration / 10, ref _velocity, camSpeed * Time.deltaTime) );
    }

}
