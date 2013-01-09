using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	public Vector3 velocity;
	public float speed;
	
	// Use this for initialization
	void Start ()
	{
		velocity = new Vector3();
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.transform.Translate(velocity.x * Time.deltaTime, 0, velocity.y * Time.deltaTime);
	}
}
