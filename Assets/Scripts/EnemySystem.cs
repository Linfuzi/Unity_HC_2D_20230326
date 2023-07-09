using UnityEngine;
using UnityEngine.UIElements;
/// <summary>
/// 敵人系統
/// 1.追蹤玩家
/// 2.面向玩家
/// </summary>
public class EnemySystem : MonoBehaviour
{
	[Header("追蹤速度"), Range(0, 100)]
	public float movespeed;
	[Header("敵人資料")]
	public DataHealthEnemy data;
	private Transform player;
	private DamagePlayer damageplayer;
	public Animator ani;
	private float timer;

	private void Awake()
	{
		player = GameObject.Find("Player").transform;
		damageplayer = player.GetComponent<DamagePlayer>();
	}
	private void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, player.position, movespeed*Time.deltaTime);
		ani.SetBool("run", true);
		Attack();
		// 距離 = 三維向量 的 距離(此物件的座標,玩家的座標)
		float distance = Vector3.Distance(transform.position, player.position);
		// 如果 距離 小於 敵人資料裡面的攻擊範圍 才會 攻擊
		if (distance < data.attackRange) Attack();
		// 如果此物件的X 大於 玩家的X 角度設定為 0,0,0
		if (transform.position.x > player.position.x) transform.eulerAngles = new Vector3(0, 0, 0);
		// 如果此物件的X 小於 玩家的X 角度設定為 0,180,0
		if (transform.position.x < player.position.x) transform.eulerAngles = new Vector3(0, 180, 0);
		print($"<color=#ff6699>距離:{distance}</color>");
	}
	private void Attack()
	{
		timer += Time.deltaTime;
		print($"<color=#ff6699>計時器:{timer}</color>");
		if (timer > data.attackInterval)
		{
			print("<color=#ff6699>攻擊玩家!</color>");
			damageplayer.GetDamage(data.attack);
			timer = 0;
		}
	}
	private void OnDrawGizmos()
	{
		Gizmos.color = new Color(1, 0, 0, 0.5f);
		Gizmos.DrawSphere(transform.position, data.attackRange);
	}
}
