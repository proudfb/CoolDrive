using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCameraController : MonoBehaviour {

    //from https://www.youtube.com/watch?v=VyOGduSxyqk by omni scient
    private Transform car;
    private Rigidbody carRb;
    private Quaternion look;

    private Transform cameraTf;

    [SerializeField] private float rotationThreshold = 1f;
    [SerializeField] private float cameraStickiness = 10f;
    [SerializeField] private float cameraRotationSpeed = 5f;

    // Use this for initialization
    void Awake () {
        cameraTf = Camera.main.transform;
        car = GetComponent<Transform>();
        carRb = car.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 targetCarPosition = new Vector3(car.position.x, car.position.y + 3, car.position.z - 8);

        // Moves the camera to match the car's position.
        cameraTf.position = Vector3.Lerp(cameraTf.position, targetCarPosition, cameraStickiness * Time.fixedDeltaTime);

        // If the car isn't moving, default to looking forwards. Prevents camera from freaking out with a zero velocity getting put into a Quaternion.LookRotation
        if (carRb.velocity.magnitude < rotationThreshold)
            look = Quaternion.LookRotation(car.forward);
        else
            look = Quaternion.LookRotation(car.forward); //Quaternion.LookRotation(carPhysics.velocity.normalized);

        // Rotate the camera towards the velocity vector.
        look = Quaternion.Slerp(cameraTf.rotation, look, cameraRotationSpeed * Time.fixedDeltaTime);
        cameraTf.rotation = look;

    }
}
