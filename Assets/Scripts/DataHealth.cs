using UnityEngine;

[CreateAssetMenu(menuName = "Leo/Data Health")]
public class DataHealth : ScriptableObject
{
	[Header("血量"), Range(1, 5000)]
	public float hp = 1000;
}
