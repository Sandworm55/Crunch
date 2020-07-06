using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScene : MonoBehaviour
{
	public GameObject close;
	// Start is called before the first frame update
	void Start()
	{
		#if UNITY_WEBGL
			close.SetActive(false);
		#endif
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void ToGame()
	{
		SceneManager.LoadScene("Game");
	}

	public void Close()
	{
		Application.Quit();
	}
}
