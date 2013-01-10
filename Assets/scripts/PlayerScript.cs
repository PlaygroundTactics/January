using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
	public GameObject bulletObj;
	
    public float linearAccel;
    public float angularAccel;

	// Use this for initialization
	void Start ()
    {
		;
	}
	
	// Update is called once per frame
	void Update ()
    {
        updateMovement();
        
        updateShooting();
	}
	
    void updateMovement()
    {
        // angular
        if (Input.GetKey(KeyCode.A))
        {
            this.rigidbody.AddTorque(0, -angularAccel, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
           this.rigidbody.AddTorque(0, angularAccel, 0);
        }
        
        // linear
		float angle = transform.rotation.eulerAngles.y * (Mathf.PI/180);
		
        if (Input.GetKey(KeyCode.W))
        {
            this.rigidbody.AddForce(Mathf.Sin(angle) * linearAccel, 0, Mathf.Cos(angle) * linearAccel);
        }
        if (Input.GetKey(KeyCode.S))
        {
          	this.rigidbody.AddForce(Mathf.Sin(angle) * -linearAccel, 0, Mathf.Cos(angle) * -linearAccel);
        }
    }
    
    void updateShooting()
    {
        if (Input.GetMouseButtonDown(0))
		{
			GameObject obj = Instantiate(bulletObj, this.transform.position, this.transform.rotation) as GameObject;
			BulletScript b = obj.GetComponent("BulletScript") as BulletScript;
			
			float a = transform.rotation.eulerAngles.y * (Mathf.PI/180);
			b.rigidbody.AddForce(b.speed * Mathf.Sin(a), 0, b.speed * Mathf.Cos(a));
		}
    }
    
	// returns value clamped between the specified max and min
	float Clamp(float value, float min, float max)
	{
		return (value > max) ? max : (value < min) ? min : value;
	}
}


