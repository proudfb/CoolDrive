using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostController : Ability_ab {
    private HeatGenerationController heatGen;
    private AudioSource rocketBoost;
    [SerializeField] private float BoostForce = 100;

    void Start()
    {
        //get the reference to our heat generator controller
        heatGen = gameObject.GetComponent<HeatGenerationController>();
        rocketBoost = gameObject.GetComponent<AudioSource>();
    }

    protected override void Ability()
    {
        //ROCKETBOOST YEAH
        gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * BoostForce, ForceMode.VelocityChange);
        //AUDIO YEAH
        rocketBoost.Play();
        //OVERHEAT YEAH
        heatGen.ChangeHeat(heatGenerated, heatScalar);
    }
}
