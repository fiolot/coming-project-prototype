using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour {

    public ParticleSystem laserEmitter;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            laserEmitter.Play();
        }
        else if (Input.GetMouseButtonUp(0)) {
            laserEmitter.Stop();
            //laserEmitter.Clear(); // Uncomment the code to the right to switch firing mode!
        }
	}
}
