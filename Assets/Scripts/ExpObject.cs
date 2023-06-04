using UnityEngine;

public class ExpObject : MonoBehaviour
{
    [Header("可以吃這個物件的名稱")]
    public string nameTarget = "Player";
    [Header("移動速度"), Range(0, 500)]
    public float moveSpeed = 3.5f;
    [Header("吃掉物件的距離"), Range(0, 5)]
    public float eatDistance = 1f;
    [Header("經驗值"), Range(0, 5000)]
    public float exp = 30;

    private bool playerInArea;
    private Transform player;
    private LevelManager levelmanager;

    private void Awake()
    {
        player = GameObject.Find(nameTarget).transform;
        levelmanager = FindObjectOfType<LevelManager>();
    }
    // 玩家是否在範圍內&#xff1a;預設為沒有
    private void Update()
    {
        // 如果 玩家進入範圍 為勾選狀態 就追蹤
        if (playerInArea)
        {
            transform.position = Vector3.MoveTowards(transform.position,player.position,moveSpeed * Time.deltaTime);
            float distance = Vector2.Distance(transform.position, player.position);//取得此經驗值物件與玩家物件的距離
            if(distance < eatDistance)//如果距離小於2就刪除
			{
                levelmanager.Getexp(exp);
                Destroy(gameObject);
			}
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print($"<color=#ff6699>{collision.name}</color>");// 輸出進入經驗值物件碰撞範圍內的物件名稱
        if (collision.name.Contains(nameTarget))// 如果 碰撞物件的名稱 包含(犀牛)
        {
            // 玩家進入範圍 = 勾選
            playerInArea = true;
        }
    }
}
