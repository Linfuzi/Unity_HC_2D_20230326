using UnityEngine;
using Unity.Mathematics;

public class Weapon : MonoBehaviour
{
	[Header("剛體")]
	public Rigidbody2D rig;
	[Header("武器發射力道")]
	public Vector2 power;

	private void Awake()
	{
		rig.AddForce(power);
	}
}
