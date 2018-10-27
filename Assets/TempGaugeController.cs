using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class TempGaugeController : MonoBehaviour {
    public Slider TempGauge;
    public CarController car;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateGauge(float f)
    {
        TempGauge.value = f;
    }



}
