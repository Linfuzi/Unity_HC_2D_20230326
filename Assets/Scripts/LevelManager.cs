using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class LevelManager : MonoBehaviour
{
	#region 資料
	[Header("等級與經驗值介面")]
	public TextMeshProUGUI textlv;
	public TextMeshProUGUI textexp;
	public Image imgexp;
	[Header("等級上限"), Range(0, 100)]
	public int lvMax;
	private int lv = 1;
	private float exp;
	public float[] expneeds;

	[Header("升級面板")]
	public GameObject goLevelUp;
	[Header("技能選取區塊 1 ~ 3")]
	public GameObject[] goChooseSkills;
	[Header("全部技能")]
	public DataSkill[] dataSkills;

	public List<DataSkill> randomSkill = new List<DataSkill>();
	#endregion

	#region 經驗值系統
	[ContextMenu("更新經驗值需求表")]
	private void Updateexpneeds()
	{
		expneeds = new float[lvMax];
		//float totalExp = 0;
		for (int i = 0; i < lvMax; i++)
		{
			/*totalExp += (i + 1) * 100;//totalexp = totalexp + (i + 1) * 100
			expneeds[i] = totalExp;*/
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
		//print($"<color=yellow>當前經驗值&#xff1a;{ exp }</color>");
		if (exp >= expneeds[lv - 1] && lv < lvMax)//如果 經驗值 >= 當前等級需求 並且 < 等級上限  就升級
		{
			exp -= expneeds[lv - 1];//計算多出來的經驗
			lv++;                   //等級提升(+1)
			textlv.text = $"lv{lv}";//更新等級介面
			LevelUp();
		}
		textexp.text = $"{exp}/{expneeds[lv - 1]}";
		imgexp.fillAmount = exp / expneeds[lv - 1];
	}
	private void LevelUp()
	{
		//時間暫停
		Time.timeScale = 0;
		//升級面板顯現
		goLevelUp.SetActive(true);
		//技能小於5拿出來
		randomSkill = dataSkills.Where(x => x.lv < 5).ToList();
		//技能隨機排序
		randomSkill = randomSkill.OrderBy(x => Random.Range(0, 999)).ToList();

		for (int i = 0; i < 3; i++)
		{
			goChooseSkills[i].transform.Find("技能名稱").GetComponent<TextMeshProUGUI>().text = randomSkill[i].nameSkill;
			goChooseSkills[i].transform.Find("技能描述").GetComponent<TextMeshProUGUI>().text = randomSkill[i].description;
			goChooseSkills[i].transform.Find("技能等級").GetComponent<TextMeshProUGUI>().text = "等級  Lv  " + randomSkill[i].lv;

			goChooseSkills[i].transform.Find("圖片").GetComponent<Image>().sprite = randomSkill[i].iconSkill;
		}
		AudioClip sound = SoundSystem.instance.BtnLevelUp;
		SoundSystem.instance.PlaySound(sound, 1, 2);
	}
	public void ClickSkillButton(int number)
	{
		//該技能等級+1
		randomSkill[number].lv++;
		//按下的技能升級
		if (randomSkill[number].nameSkill == "急速領域") UpdateMoveSpeed(number);
		if (randomSkill[number].nameSkill == "鑲嵌") UpdateweaponAttack(number);
		if (randomSkill[number].nameSkill == "鍛鍊") UpdateWeaponInterval(number);
		if (randomSkill[number].nameSkill == "血牛") UpdatePlayerHealth(number);
		if (randomSkill[number].nameSkill == "經多多") UpdateExpRange(number);
		Time.timeScale = 1;
		goLevelUp.SetActive(false);
		AudioClip sound = SoundSystem.instance.BtnUpdateSkill;
		SoundSystem.instance.PlaySound(sound, 1, 2);
	}
	#endregion

	#region 升級系統
	[Header("控制系統:玩家")]
	public ControlSystem controlSystem;
	[Header("武器系統:玩家")]
	public WeaponSystem weaponSystem;
	[Header("血量系統:玩家血量")]
	public DataHealth dataHealth;
	[Header("經驗物件:奇異果經驗值")]
	public ExpObject expkiwi;
	[Header("武器:蜜蜂")]
	public Weapon weaponbee;
	[Header("玩家血量系統:player")]
	public DamagePlayer damagePlayer;

	private void Awake()
	{
		weaponbee.attack = dataSkills[0].skillValues[0];//對應技能在 data skill 內的順序
		weaponSystem.interval = dataSkills[1].skillValues[0];
		dataHealth.hp = dataSkills[2].skillValues[0];
		controlSystem.movespeed = (int)dataSkills[3].skillValues[0];
		expkiwi.exp = dataSkills[4].skillValues[0];
	}

	private void UpdateMoveSpeed(int number)
	{
		int lv = randomSkill[number].lv;
		controlSystem.movespeed = (int)randomSkill[number].skillValues[lv - 1];
	}
	private void UpdateweaponAttack(int number)
	{
		int lv = randomSkill[number].lv;
		weaponbee.attack = randomSkill[number].skillValues[lv - 1];
	}
	private void UpdateWeaponInterval(int number)
	{
		int lv = randomSkill[number].lv;
		weaponSystem.interval = randomSkill[number].skillValues[lv - 1];
		weaponSystem.ReSpawWeapon();
	}
	private void UpdatePlayerHealth(int number)
	{
		int lv = randomSkill[number].lv;
		dataHealth.hp = randomSkill[number].skillValues[lv - 1];
		damagePlayer.UpdateHealth(dataHealth.hp);
	}
	private void UpdateExpRange(int number)
	{
		int lv = randomSkill[number].lv;
		expkiwi.exp = randomSkill[number].skillValues[lv - 1];
	} 
	#endregion
}
