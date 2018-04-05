using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Mono.Data.SqliteClient;
using UnityEngine.SceneManagement;

public class CheckUsername : MonoBehaviour
{
    public InputField GrStudentUserName;
    public Button AddStudent;
    //create array lists for the DB
    private static ArrayList userList = new ArrayList();

    void Start()
    {
        //direct db connection to where the db is stored in app
        //and open connection
        const string connectionString = "URI=file:Assets\\Plugins\\MumboJumbos.db";
        IDbConnection dbcon = new SqliteConnection(connectionString);
        dbcon.Open();

        //create query for user name
        IDbCommand dbcmd = dbcon.CreateCommand();
        const string sql =
            "SELECT StuUserName " +
            "FROM student";
        dbcmd.CommandText = sql;
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            string user = reader.GetString(0);

            Debug.Log(user);

            userList.Add(user);

        }
        var input = GrStudentUserName;
        var se = new InputField.SubmitEvent();
        se.AddListener(CheckName);
        input.onEndEdit = se;

        //or simply use the line below, 
        //input.onEndEdit.AddListener(CheckName);  // This also works


    }

    public static void updateUserList()
    {
        //direct db connection to where the db is stored in app
        //and open connection
        const string connectionString = "URI=file:Assets\\Plugins\\MumboJumbos.db";
        IDbConnection dbcon = new SqliteConnection(connectionString);
        dbcon.Open();

        //create query for user name
        IDbCommand dbcmd = dbcon.CreateCommand();
        const string sql =
            "SELECT StuUserName " +
            "FROM student";
        dbcmd.CommandText = sql;
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            string user = reader.GetString(0);

            Debug.Log(user);

            userList.Add(user);

        }
    }

    private void CheckName(string arg0)
    {


        if (userList.Contains(arg0))
        {
            SceneManager.LoadScene("AddUser");
            GrStudentUserName.text = "That user name is already taken.";


        }
        else
        {
            AddStudent.interactable = true;
        }

    }

    public static bool IsTaken(String checkName)
    {
        if (userList.Contains(checkName))
        {
            return true;
        }
        else
            return false;
    }
}

