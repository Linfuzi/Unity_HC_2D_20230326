using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundSystem : MonoBehaviour
{
	[Header("音效清單")]
	public AudioClip PlayerHit;
	public AudioClip PlayerDead;
	public AudioClip PlayerShoot;
	public AudioClip EnemyHit;
	public AudioClip EnemyDead;
	public AudioClip BtnNormal;
	public AudioClip BtnUpdateSkill;
	public AudioClip BtnLevelUp;
	public AudioClip GetExp;
	public AudioSource aud;
	public static SoundSystem instance;

	public void Awake()
	{
		instance = this;
		aud = GetComponent<AudioSource>();
	}
	//參數 sound 代表要播放的音效
	//參數 min 代表音量最小值
	//參數 max 代表音量最大值
	public void PlaySound(AudioClip sound,float min,float max)
	{
		float volume = Random.Range(min, max);
		aud.PlayOneShot(sound, volume);
	}
}
