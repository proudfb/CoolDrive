using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverclockController : LongAbility_ab {

    [SerializeField] private float overclockFactor=10;
    private HeatGenerationController heatGen;

    void Start()
    {
        //get the reference to our heat generator controller
        heatGen = gameObject.GetComponent<HeatGenerationController>();
    }

    public override void ActivateAbility()
    {
        this.abilityIsActive = true;
    }

    protected override void Ability()
    {
        gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * overclockFactor * Time.deltaTime, ForceMode.Acceleration);
        heatGen.ChangeHeat(heatGenerated, heatScalar);
    }
}
