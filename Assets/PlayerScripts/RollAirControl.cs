using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollAirControl : BasicAbility_ab {

    [SerializeField] private float RollControlScalar = 30;
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
            gameObject.GetComponent<Rigidbody>().AddRelativeTorque(0, 0, -(Input.GetAxis(AxisName) * RollControlScalar * Time.deltaTime), ForceMode.Acceleration); //invert to ensure proper rolling
        }
    }
}
