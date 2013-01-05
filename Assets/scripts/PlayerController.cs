using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float linearAccel;
    public float maxLinearSpeed;
    public float angularAccel;
    public float maxAngularSpeed;

    private Vector3 linearVelocity;
    private float angularVelocity;

	// Use this for initialization
	void Start ()
    {
		linearVelocity = new Vector3(0,0,0);
		angularVelocity = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // angular
        if (Input.GetKey(KeyCode.A))
        {
            angularVelocity -= angularAccel;
        }
        if (Input.GetKey(KeyCode.D))
        {
            angularVelocity += angularAccel;
        }
        
        // linear
		float angle = Mathf.Atan2(transform.rotation.eulerAngles.z, transform.rotation.eulerAngles.x);
		
        if (Input.GetKey(KeyCode.W))
        {
            linearVelocity.x += Mathf.Sin(angle) * linearAccel;
			linearVelocity.z += Mathf.Cos(angle) * linearAccel;
        }
        if (Input.GetKey(KeyCode.S))
        {
          	linearVelocity.x -= Mathf.Sin(angle) * linearAccel;
			linearVelocity.z -= Mathf.Cos(angle) * linearAccel;
        }
        
		// clamp linear velocity
		if (linearVelocity.magnitude > maxLinearSpeed)
		{
			linearVelocity.Normalize();
			linearVelocity *= maxLinearSpeed;
		}
		
		// clamp angular velocity
		angularVelocity = Clamp(angularVelocity, -maxAngularSpeed, maxAngularSpeed);
		
        // apply velocities
        this.transform.Rotate(0, angularVelocity * Time.deltaTime, 0);
        this.transform.Translate(linearVelocity * Time.deltaTime, Space.World);
	}
	
	// returns value clamped between the specified max and min
	float Clamp(float value, float min, float max)
	{
		return (value > max) ? max : (value < min) ? min : value;
	}
}


