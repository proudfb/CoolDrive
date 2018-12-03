using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class TempGaugeController : MonoBehaviour {
    public Slider TempGauge;
    public CarController car;

    public void UpdateGauge(float f)
    {
        TempGauge.value = f;
    }



}
