using UnityEngine;

public class SpawnSysytem : MonoBehaviour
{
    [Header("怪物生成間隔時間"), Range(0, 10)]
    public float interval;
    [Header("生成的怪物")]
    public GameObject prefabsenemy;

    private void Monster()
	{
        Instantiate(prefabsenemy, transform.position, transform.rotation);
	}
	private void Awake()
	{
        InvokeRepeating("Monster", 0, interval);
	}
}
