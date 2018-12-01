using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchAirControl : BasicAbility_ab {

    [SerializeField] private float pitchControlScalar=30;
    private TerrainCheck tcheck;

    void Start()
    {
        tcheck = gameObject.GetComponent<TerrainCheck>();
    }

    protected override void Ability()
    {
        //Debug.Log("AM I FLYING?");
        if (tcheck.IsFlying)
        {
            //Debug.Log("ROTATE!");
            gameObject.GetComponent<Rigidbody>().AddRelativeTorque(Input.GetAxis(AxisName) * pitchControlScalar * Time.deltaTime, 0, 0, ForceMode.Acceleration); 
        }
    }
}
