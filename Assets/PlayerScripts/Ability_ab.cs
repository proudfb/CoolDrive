﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Defines an ability that lasts for one frame. Requires Ability() to be implemented by descendent classes.
/// </summary>
public abstract class Ability_ab : BasicAbility_ab
{

    protected bool abilityIsActive = false;
    protected bool abilityIsReady = true;
    ///// <summary>
    ///// The name of the axis to use for this input (key, button, etc)
    ///// </summary>
    //[SerializeField] protected string axisName;
    ///// <summary>
    ///// The name of this ability to show in the UI
    ///// </summary>
    //[SerializeField] protected string abilityName;


    /// <summary>
    /// The base cooldown of this ability
    /// </summary>
    [SerializeField] protected float cooldownTimeBase;
    /// <summary>
    /// How much base heat is generated by the ability
    /// </summary>
    [SerializeField] protected float heatGenerated;
    /// <summary>
    /// The scalar to multiply the amount of heat generated by.
    /// </summary>
    protected float heatScalar;
    /// <summary>
    /// The textfield used to show the user the remaining cooldown time
    /// </summary>
    [SerializeField] protected Text timerText;

    protected float cooldownTimeLeft;

    public float CooldownTimeLeft { get { return cooldownTimeLeft; } }
    public bool AbilityIsReady { get { return abilityIsReady; } }
    public bool AbilityIsActive { get { return abilityIsActive; } }

    void Awake()
    {
        //grab our HeatScalar value for this specific car.
        heatScalar = gameObject.GetComponent<CarStats>().HeatScalar;
    }

    public override void ActivateAbility()
    {
        if (abilityIsReady)
        {
            abilityIsActive = true;
            Ability();
            abilityIsActive = false;
            //timeSinceLastActive = Time.time;
            ActivateCooldown();
        }
    }

    /// <summary>
    /// Activate the cooldown of an ability, making it no longer ready for use.
    /// </summary>
    protected virtual void ActivateCooldown()
    {
        abilityIsReady = false;
        cooldownTimeLeft = cooldownTimeBase;
    }

    /// <summary>
    /// Check if an ability is ready (and if it is, set abilityIsReady to true). Returns 0 if ready, the time until it is (as a float) if not
    /// Called each FixedUpdate.
    /// </summary>
    /// <returns>float</returns>
    public virtual float Cooldown()
    {
        if (!abilityIsReady)
        {
            if (CooldownTimeLeft <= 0f)
            {
                cooldownTimeLeft = 0f;
                abilityIsReady = true;
            }
            else
            {
                //if our ability isn't ready, get a value that we can use to determine how long we have left
                cooldownTimeLeft -= Time.deltaTime;
            }
            return cooldownTimeLeft;
        }
        else return 0f;
    }

    private void FixedUpdate()
    {
        timerText.text = String.Format("{0:S} ready in: {1:F3} seconds", abilityName, Cooldown());
    }

}
