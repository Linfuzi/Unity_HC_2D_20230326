using UnityEngine;//引用名為UnityEngine的函式庫
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{

	}
	// Update is called once per frame
	void Update()
	{

	}
    public void StartGame()
	{
		SceneManager.LoadScene("Game_ground");
	}
	public void OverGame()
	{
		Application.Quit();
	}
}
