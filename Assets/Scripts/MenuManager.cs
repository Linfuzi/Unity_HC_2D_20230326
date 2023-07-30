using UnityEngine;//引用名為UnityEngine的函式庫
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public void StartGame()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("Game_ground");
	}
	public void OverGame()
	{
		Application.Quit();
	}
}
