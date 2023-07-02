using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    private Transform player;

	private void Awake()
	{
		player = GameObject.Find("Player").transform;
	}
	private void Update()
	{
		transform.position = player.position;
	}
}
