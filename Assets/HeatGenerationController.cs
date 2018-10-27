using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatGenerationController : MonoBehaviour {
    public float CurrHeat { get; private set; }
    /// <summary>
    /// What is the base cooling factor for airtime and other small tricks?
    /// </summary>
    public float BaseCoolingFactor = 4;
    /// <summary>
    /// How fast does the temperature rise?
    /// </summary>
    public float HeatFactor = 2.5f;
    public Slider TempGauge;


	// Use this for initialization
	void Start () {
        CurrHeat = 195;
        TempGauge.gameObject.GetComponent<TempGaugeController>().UpdateGauge(CurrHeat);
    }
	
	// Update is called once per frame
	void Update () {
        CurrHeat += (Time.deltaTime * HeatFactor);
        TempGauge.gameObject.GetComponent<TempGaugeController>().UpdateGauge(CurrHeat);
	}

    public void ChangeHeat(float f, float factor)
    {
        CurrHeat += (f * factor);
    }
}
