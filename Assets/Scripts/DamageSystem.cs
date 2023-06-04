using UnityEngine;

public class DamageSystem : MonoBehaviour
{
	[Header("血量資料")]
	public DataHealth Data;

	private float hp;

	private DataHealthEnemy dataEnemy;

	private void Awake()
	{
		hp = Data.hp;
		dataEnemy = (DataHealthEnemy)Data;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		//print(collision.gameObject);
		if(collision.gameObject.name.Contains("屁股"))
		{
			//print("被屁股撞到");
			GetDamage();
		}
	}
	private void GetDamage()
	{
		hp -= 500;
		//print("血量剩下" + hp);

		if(hp <= 0)
		{
			Dead();
		}
	}
	private void Dead()
	{
		Destroy(gameObject);
		DropExp();
	}
	private void DropExp()
	{
		//print("這隻怪物的掉落經驗值機率" + dataEnemy.dropProbability);
		if(Random.value <= dataEnemy.dropProbability)
		{
			Instantiate(dataEnemy.prefabExp, transform.position, transform.rotation);
		}
	}
}