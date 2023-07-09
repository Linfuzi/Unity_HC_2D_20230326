using UnityEngine;

public class DamageEnemy : DamageSystem
{
	private DataHealthEnemy dataEnemy;

	private void Start()
	{
		dataEnemy = (DataHealthEnemy)Data;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name.Contains("屁股"))
		{
			float attack = collision.gameObject.GetComponent<Weapon>().attack;
			GetDamage(attack);
		}
	}
	public override void GetDamage(float damage)
	{
		base.GetDamage(damage);
		AudioClip sound = SoundSystem.instance.EnemyHit;
		SoundSystem.instance.PlaySound(sound, 1, 2);
	}
	protected override void Dead()
	{
		Destroy(gameObject);
		DropExp();
		AudioClip sound = SoundSystem.instance.EnemyDead;
		SoundSystem.instance.PlaySound(sound, 1, 2);
	}
	private void DropExp()
	{
		//print("這隻怪物的掉落經驗值機率" + dataEnemy.dropProbability);
		if (Random.value <= dataEnemy.dropProbability)
		{
			Instantiate(dataEnemy.prefabExp, transform.position, transform.rotation);
		}
	}
}
