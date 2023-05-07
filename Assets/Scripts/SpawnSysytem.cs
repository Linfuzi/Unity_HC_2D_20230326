using UnityEngine;

public class SpawnSysytem : MonoBehaviour
{
    [Header("怪物生成間隔時間"), Range(0, 10)]
    public float interval = 3.5f;
    [Header("生成的怪物")]
    public GameObject prefabsEnemy;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
