using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSystem : MonoBehaviour
{
    [Header("移動速動")]
    [Range(1f,100f)]
    public int movespeed = 10;
    public Rigidbody2D rb;
	public Animator ani;
	public string State = "state";
	private void Start()
	{
		//print("<color=black>WoW</color>");
	}
	private void Update()
	{
		//print("<color=red>LOL</color>");
		Movemant();
	}
	private void Awake()
	{

	}
	private void Movemant()
	{
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");
		rb.velocity = new Vector3(x, y, 0) * movespeed;
		if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
		{
			transform.eulerAngles = new Vector3(0, -180, 0);
		}
		else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
		{
			transform.eulerAngles = new Vector3(0, 0, 0);
		}
		/*else if(Input.GetKeyDown(KeyCode.Space))
		{
			transform.position = new Vector3()
		}*/
		ani.SetBool("run", true);
	}
}