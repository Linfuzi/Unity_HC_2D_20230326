using UnityEngine;
using TMPro;

public class DamageSystem : MonoBehaviour
{
	[Header("血量資料")]
	public DataHealth Data;
	[Header("DamageCanvas")]
	public GameObject DamageCanvas;

	protected float hp;
	protected float hpmax;

	private void Awake()
	{
		hp = Data.hp;
		hpmax = hp;
	}
	public virtual void GetDamage(float damage)
	{
		//print($"<color=#ff6699>受到的傷害{damage}</color>");
		hp -= damage;

		GameObject tempDamage = Instantiate(DamageCanvas, transform.position, transform.rotation);
		tempDamage.transform.Find("文字傷害值").GetComponent<TextMeshProUGUI>().text = damage.ToString();
		Destroy(tempDamage, 1.5f);
		if(hp <= 0)
		{
			Dead();
		}
	}
	protected virtual void Dead()
	{
		
	}
	
}