using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAbilityController : MonoBehaviour {

    //The lists of abilities that we need to watch for. initialized at runtime.
    private List<Ability_ab> abilities = new List<Ability_ab>();
    private List<LongAbility_ab> longAbilities = new List<LongAbility_ab>();

    public float OverclockAccel = 100;
    public float heatScalar = 1;


	// Called after all the Start() functions are called.
	void Awake () {
        foreach (Ability_ab ability in gameObject.GetComponents<Ability_ab>()){
            if (ability is LongAbility_ab)//if the ability is a long ability
            {
                longAbilities.Add(ability as LongAbility_ab);//add it to our list of long abilities
            }
            else //our ability is a short ability, so add it to the respective list
            {
                abilities.Add(ability);
            }
        }

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        foreach (Ability_ab ability in abilities)
        {
            if (Input.GetAxis(ability.AxisName)>0)
            {
                ability.ActivateAbility();
            }
        }

        //Overclock
        //Debug.Log("Overclock key is signalling:"+Input.GetAxis("Fire1").ToString());
        if (Input.GetKey(KeyCode.V))
        {
            //gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * OverclockAccel * Time.deltaTime, ForceMode.Acceleration);
            //heatGen.ChangeHeat(.125f, heatScalar);
        }
	}
}
