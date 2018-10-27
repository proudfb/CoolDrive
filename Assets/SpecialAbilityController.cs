using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAbilityController : MonoBehaviour {

    private HeatGenerationController heatGen;
    private AudioSource rocketBoost;
    public float BoostForce = 10;
	// Use this for initialization
	void Start () {
        //get the reference to our heat generator controller
        heatGen = gameObject.GetComponent<HeatGenerationController>();
        rocketBoost = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //ROCKET BOOST YEAH
            gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward*BoostForce, ForceMode.VelocityChange);
            //AUDIO YEAH
            rocketBoost.Play();
            //OVERHEAT YEAH
            heatGen.ChangeHeat(40, 1);
        }
	}
}
