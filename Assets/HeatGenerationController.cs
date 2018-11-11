using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatGenerationController : MonoBehaviour {

    [SerializeField] private readonly float baseHeat = 195;
    [SerializeField] private readonly float minHeat = -40;
    [SerializeField] private readonly float maxHeat = 400;

    public float CurrHeat { get; private set; }
    /// <summary>
    /// What is the base cooling factor for airtime and other small tricks?
    /// </summary>
    public float BaseCoolingFactor = 4;
    /// <summary>
    /// How fast does the temperature rise for the vehicle? (scalar)
    /// </summary>
    public float HeatFactor = 2.5f;
    public Slider TempGauge;


	// Use this for initialization
	void Start () {
        CurrHeat = baseHeat;
        TempGauge.gameObject.GetComponent<TempGaugeController>().UpdateGauge(CurrHeat);
    }

    // Update is called once per frame
    void Update () {
        CurrHeat += (Time.deltaTime * (HeatFactor + EnvironmentController.heatScalar));
        TempGauge.gameObject.GetComponent<TempGaugeController>().UpdateGauge(CurrHeat);
        if (CurrHeat < minHeat)
        {
            gameObject.GetComponent<RespawnPlayerController>().RespawnPlayer(0);
        }

        if (CurrHeat > maxHeat)
        {
            gameObject.GetComponent<RespawnPlayerController>().RespawnPlayer(1);
        }
    }

    public void ResetHeat()
    {
        CurrHeat = baseHeat;
    }

    /// <summary>
    /// Change the heat level by the specified amount. Additive, with optional scalar independent of other heat factors.
    /// </summary>
    /// <param name="f">The base amount of heat an ability costs</param>
    /// <param name="factor">The scalar to multiply the heat by, used for cars that generate more or less heat by using specials.</param>
    public void ChangeHeat(float f, float factor)
    {
        Debug.Log("Heat changed by :" + (f*factor).ToString());
        CurrHeat += (f * factor);
    }
}
