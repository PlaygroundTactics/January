using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour
{
	public float speed;
	public float duration;
	
	private float timer;
	
	// Use this for initialization
	void Start ()
	{
		timer = duration;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (timer > 0)
		{
			timer -= Time.deltaTime;	
		}
		else
		{
			print ("destroyed!");
			Destroy(this.gameObject);
		}
	}
	
	
}
