using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float linearAccel;
    public float maxLinearSpeed;
    public float angularAccel;
    public float maxAngularSpeed;

    private float linearVelocity;
    private float angularVelocity;

	// Use this for initialization
	void Start ()
    {
	
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
        if (Input.GetKey(KeyCode.W))
        {
            linearVelocity += linearAccel;
        }
        if (Input.GetKey(KeyCode.S))
        {
            linearVelocity -= linearAccel;
        }
        
		// clamp speeds
		linearVelocity = clamp(linearVelocity, -maxLinearSpeed, maxLinearSpeed);
		angularVelocity = clamp(angularVelocity, -maxAngularSpeed, maxAngularSpeed);
		
        // apply velocities
        this.transform.Rotate(0, angularVelocity * Time.deltaTime, 0);
        this.transform.Translate(linearVelocity * Time.deltaTime, 0, 0);
	}
	
	float clamp(float value, float min, float max)
	{
		return (value > max) ? max : (value < min) ? min : value;
	}
}


