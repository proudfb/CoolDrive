using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines an ability that lasts for more than one frame. Inherits from AbilityAbstract
/// </summary>
public abstract class LongAbility_ab : Ability_ab {

    /// <summary>
    /// How long does this ability last, in seconds?
    /// </summary>
    [SerializeField] private readonly float abilityDuration;

    protected float abilityTimeLeft = 0f;

    //force an override for activate ability, since long abilities have more general requirements than one frame abilities.
    /// <summary>
    /// Activate the ability. Don't forget to set the "AbilityIsActive" value to true!
    /// </summary>
    public abstract override void ActivateAbility();

    public void ToggleAbility()
    {
        if (this.abilityIsActive)
        {
            abilityIsActive = false;
            ActivateCooldown();
        }
        else //abilityIsActive is false
        {
            if(abilityIsReady){
                ActivateAbility();
            }
        }
    }

    private void FixedUpdate()
    {
        timerText.text = String.Format("{0:S} ready in: {0:F3} seconds", abilityName, Cooldown());
        if (abilityIsActive)
        {
            Ability();
        }
    }
}
