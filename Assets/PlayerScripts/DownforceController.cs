using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownforceController : LongAbility_ab {

    [SerializeField] private float downforceFactor = 10;
    private HeatGenerationController heatGen;

    void Start()
    {
        //get the reference to our heat generator controller
        heatGen = gameObject.GetComponent<HeatGenerationController>();
    }

    public override void ActivateAbility()
    {
        this.abilityIsActive = true;//set the ability to "active"
        this.abilityTimeLeft = abilityDuration;//set the duration
    }

    protected override void Ability()
    {
        gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.down*downforceFactor, ForceMode.Impulse);
        heatGen.ChangeHeat(heatGenerated, heatScalar);
    }
}
