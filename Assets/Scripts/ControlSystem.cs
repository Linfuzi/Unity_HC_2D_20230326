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
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");
		rb.velocity = new Vector3(x, y, 0) * movespeed;
	}
	private void Awake()
	{
       
	}
}
