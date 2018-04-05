using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToUser : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void ToUserEdit()
	{
		SceneManager.LoadScene("AddUser");
	}
    public void ToUserRemove()
    {
        SceneManager.LoadScene("RemoveUser");
    }
    public void ToWordAdd()
    {
        SceneManager.LoadScene("AddWord");
    }


}
