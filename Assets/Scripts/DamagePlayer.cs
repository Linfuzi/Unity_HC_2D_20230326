using UnityEngine;
using UnityEngine.UI;

public class DamagePlayer : DamageSystem
{
	[Header("血條")]
	public Image imghp;

	public override void GetDamage(float damage)
	{
		base.GetDamage(damage);
		imghp.fillAmount = hp / hpmax;
	}
}
