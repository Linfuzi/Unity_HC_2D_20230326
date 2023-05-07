using UnityEngine;
/// <summary>
/// 敵人系統
/// 1.追蹤玩家
/// 2.面向玩家
/// </summary>
public class EnemySystem : MonoBehaviour
{
	[Header("追蹤速度"), Range(0, 100)]
	public float movespeed;
	public Transform player;
	public Animator ani;
	private void Awake()
	{
		player = GameObject.Find("Player").transform;
	}
	private void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, player.position, movespeed);
		ani.SetBool("run", true);
	}
}
