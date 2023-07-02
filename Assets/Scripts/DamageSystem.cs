using UnityEngine;
using TMPro;

public class DamageSystem : MonoBehaviour
{
	[Header("血量資料")]
	public DataHealth Data;
	[Header("DamageCanvas")]
	public GameObject DamageCanvas;

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

		GameObject tempDamage = Instantiate(DamageCanvas, transform.position, transform.rotation);
		tempDamage.transform.Find("文字傷害值").GetComponent<TextMeshProUGUI>().text = damage.ToString();
		Destroy(tempDamage, 1.5f);
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