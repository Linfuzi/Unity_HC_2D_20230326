using UnityEngine;

public class DamageSystem : MonoBehaviour
{
	[Header("血量資料")]
	public DataHealth Data;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		//print(collision.gameObject);
		if(collision.gameObject.name.Contains("屁股"))
		{
			print("被屁股撞到");
		}
	}
}