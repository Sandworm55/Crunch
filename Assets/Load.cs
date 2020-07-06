using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    public float Loadtime = 1f, cur;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if ((cur+= Time.deltaTime) >= Loadtime)
		{
            SceneManager.LoadScene("Game");
		}
    }
}
