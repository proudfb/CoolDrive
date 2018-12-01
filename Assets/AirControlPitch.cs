using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirControlPitch : BasicAbility_ab {

    private float pitchControl;
    public float PitchControl { get; set; }

    protected override void Ability()
    {
        gameObject.transform.Rotate(0, Input.GetAxis(AxisName)*Time.deltaTime, 0);
    }
}
