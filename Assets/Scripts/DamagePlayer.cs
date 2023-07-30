using UnityEngine;
using UnityEngine.UI;

public class DamagePlayer : DamageSystem
{
	[Header("血條")]
	public Image imghp;
	[Header("控制系統")]
	public ControlSystem controlSystem;
	[Header("結束面板")]
	public GameObject goFinal;
	public override void GetDamage(float damage)
	{
		base.GetDamage(damage);
		imghp.fillAmount = hp / hpmax;
		AudioClip sound = SoundSystem.instance.PlayerHit;
		SoundSystem.instance.PlaySound(sound, 1, 2);
	}
	protected override void Dead()
	{
		base.Dead();
		//	1.關閉控制系統
		controlSystem.enabled = (false);
		//	2.彈出結束畫面
		goFinal.SetActive(true);
		AudioClip sound = SoundSystem.instance.PlayerDead;
		SoundSystem.instance.PlaySound(sound, 1, 2);
	}
	public void UpdateHealth(float updateHp)
	{
		Data.hp = updateHp;
		hp = updateHp;
		hpmax = updateHp;
		imghp.fillAmount = 1; 
	}
}
