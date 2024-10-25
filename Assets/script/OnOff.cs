using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OnOff : MonoBehaviour
{
    // public variable
	public GameObject staticFolder;
	public GameObject dynamicFolder;
	public GameObject snow;
	public GameObject trail;
	public GameObject frictionParticle;
	public Material roadOn;
	public Material roadOff;
	public GameObject track;
	public GameObject _camera;

	// private variable
	private bool _on = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) toggle();		
    }

	void toggle()
	{
		// toggle ON / OFF
		_on = !_on;

		// Active / Désactive
		staticFolder.SetActive(_on);
		dynamicFolder.SetActive(_on);
		snow.SetActive(_on);
		frictionParticle.SetActive(_on);
		trail.SetActive(_on);

		if (_on) 
		{
			track.GetComponent<MeshRenderer>().material = roadOn;
			_camera.transform.localPosition -= new Vector3(0, 3, 0);
		}
		else 
		{
			track.GetComponent<MeshRenderer>().material = roadOff;
			_camera.transform.localPosition += new Vector3(0, 3, 0);
		}
	}
}
