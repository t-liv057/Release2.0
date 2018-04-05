using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Data;
using Mono.Data.SqliteClient;
using System;

public class DeathMenu : MonoBehaviour {

    public Text scoreText;
    public Image backgroundImage;
    private bool isShowed = false;
    private float transition = 0.0f;

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(!isShowed)  {
            return;
        }
        transition += Time.deltaTime;
        backgroundImage.color = Color.Lerp(new Color(0,0,0,0),Color.black,transition);
	}

    public void ToggleEndMenu(float score) {
        gameObject.SetActive(true);
        scoreText.text = ((int)score).ToString();
        isShowed = true;

    }

    public void Restart() {
        //direct db connection to where the db is stored in app
        //and open connection
        //const string connectionString = "URI=file:Assets\\Plugins\\MumboJumbos.db";
        //IDbConnection dbcon = new SqliteConnection(connectionString);
        //dbcon.Open();
        //IDbCommand dbcmd = dbcon.CreateCommand();

        ////create query for adding score
        //dbcmd = null;
        //dbcon.CreateCommand();
        //String command =
        //"INSERT INTO score " +
        //"(userID, totalScore, grade) " +
        //"VALUES (@two, @three, @four)";

        ////dbcmd.Parameters.Add(new SqliteParameter("@one", one)); 
        //dbcmd.Parameters.Add(new SqliteParameter("@two", SubmitName.getStuID()));
        //dbcmd.Parameters.Add(new SqliteParameter("@three", Int32.Parse(scoreText.text)));
        //dbcmd.Parameters.Add(new SqliteParameter("@four", SubmitName.getStuGrade()));

        //string sql = command;
        //Debug.Log(sql);
        //dbcmd.CommandText = sql;
        //IDataReader reader = dbcmd.ExecuteReader();
        SceneManager.LoadScene("Menu");

    }

    public void ToMenu() {
        //direct db connection to where the db is stored in app
        //and open connection
        //const string connectionString = "URI=file:Assets\\Plugins\\MumboJumbos.db";
        //IDbConnection dbcon = new SqliteConnection(connectionString);
        //dbcon.Open();
        //IDbCommand dbcmd = dbcon.CreateCommand();

        ////create query for adding score
        //dbcmd = null;
        //dbcon.CreateCommand();
        //String command =
        //"INSERT INTO score " +
        //"(userID, totalScore, grade) " +
        //"VALUES  @two, @three, @four)";

        ////dbcmd.Parameters.Add(new SqliteParameter("@one", one)); 
        //dbcmd.Parameters.Add(new SqliteParameter("@two", SubmitName.getStuID()));
        //dbcmd.Parameters.Add(new SqliteParameter("@three", Int32.Parse(scoreText.text)));
        //dbcmd.Parameters.Add(new SqliteParameter("@four", SubmitName.getStuGrade()));

        //string sql = command;
        //Debug.Log(sql);
        //dbcmd.CommandText = sql;
        //IDataReader reader = dbcmd.ExecuteReader();
        SceneManager.LoadScene("Menu");
    }
}
