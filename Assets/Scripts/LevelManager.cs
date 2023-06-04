using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
	[Header("等級與經驗值介面")]
	public TextMeshProUGUI textlv;
	public TextMeshProUGUI textexp;
	public Image imgexp;
	[Header("等級上限"), Range(0, 100)]
	public int lvMax;
	private int lv = 1;
	private float exp;
	public float[] expneeds = { 100, 200, 300 };

	[ContextMenu("更新經驗值需求表")]
	private void Updateexpneeds()
	{
		expneeds = new float[lvMax];
		for(int i = 0; i < lvMax; i++)
		{
			expneeds[i] = (i + 1) * 100;
		}
	}
	/// <summary>
	/// 獲得經驗值
	/// </summary>
	/// <param name="getExp">取得的經驗值浮點數</param>
	public void Getexp(float getexp)
	{
		exp += getexp;
		print($"<color=yellow>當前經驗值&#xff1a;{ exp }</color>");
		if(exp >= expneeds[lv - 1] && lv < lvMax)//如果 經驗值 >= 當前等級需求 並且 < 等級上限  就升級
		{
			exp -= expneeds[lv - 1];//計算多出來的經驗
			lv++;					//等級提升(+1)
			textlv.text = $"lv{lv}";//更新等級介面
		}
		textexp.text = $"{exp}/{expneeds[lv - 1]}";
		imgexp.fillAmount = exp / expneeds[lv - 1];
	}
}
