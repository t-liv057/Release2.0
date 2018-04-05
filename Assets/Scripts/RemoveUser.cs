using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Mono.Data.SqliteClient;
using UnityEngine.SceneManagement;

public class RemoveUser : MonoBehaviour
{
    //input/button game objects
    public InputField StudentUserName;
    public Button removeButton;
    public Text removedText;

    //default values
    private string username = null;

    //check for important variables being entered
    private Boolean user = false;



    //when each input field has a change call the respective method to set it's variable to the input
    void Start()
    {
        StudentUserName.onEndEdit.AddListener(SubmitUserName);

    }




    //add user name to local variable for later use
    private void SubmitUserName(string input)
    {
        username = input;
        user = true;
    }


    //format add user query and select using teacherID stored on login and auto increment of stuID
    public void ActivateRemove()
    {
        //check to see if neccesary variables were received
        if (user)
        {
            Debug.Log(username);
            //check if username is already taken again
                

                //direct db connection to where the db is stored in app
                //and open connection
                const string connectionString = "URI=file:Assets\\Plugins\\MumboJumbos.db";
                IDbConnection dbcon = new SqliteConnection(connectionString);
                dbcon.Open();

                //create query for adding user
                IDbCommand dbcmd = dbcon.CreateCommand();
                String command =
                "DELETE FROM student " +
                "WHERE StuUserName = " +
                "@username";

                //dbcmd.Parameters.Add(new SqliteParameter("@one", one));    
            dbcmd.Parameters.Add(new SqliteParameter("@username", username));

                string sql = command;
                dbcmd.CommandText = sql;
                IDataReader reader = dbcmd.ExecuteReader();
                removedText.text = "User Removed!";
                removedText.enabled = true;

        }
        else
        {
            SceneManager.LoadScene("RemoveUser");
            Reset();
        }
    }

    private void Reset()
    {
        removeButton.interactable = false;
        removedText.text = null;

        //check for important variables being entered
        user = false;
    }
}


