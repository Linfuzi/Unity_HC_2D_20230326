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
		if(collision.gameObject.name.Contains("屁股"))
		{
			float attack =  collision.gameObject.GetComponent<Weapon>().attack;
			GetDamage(attack);
		}
	}
	private void GetDamage(float damage)
	{
		print($"<color=#ff6699>受到的傷害{damage}</color>");
		hp -= damage;

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