﻿using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Mono.Data.SqliteClient;
using UnityEngine.SceneManagement;

public class AddWord : MonoBehaviour
{
    //input/button game objects
    public InputField SetID;
    public InputField Word;
    public InputField Difficulty;
    public InputField Grade;
    public Button addButton;
    public Text addedText;

    //default values
    private string three = null;
    private string four = null;
    private string five = null;
    private char six;

    //check for important variables being entered
    private Boolean user = false;
    private Boolean first = false;
    private Boolean last = false;
    private Boolean grad = false;


    //when each input field has a change call the respective method to set it's variable to the input
    void Start()
    {
        SetID.onEndEdit.AddListener(SubmitSetID);
        Word.onEndEdit.AddListener(SubmitWord);
        Difficulty.onEndEdit.AddListener(SubmitDifficulty);
        Grade.onEndEdit.AddListener(SubmitGrade);
    }




    //add user name to local variable for later use
    private void SubmitSetID(string input)
    {
        three = input;
        user = true;
    }
    //add user name to local variable for later use
    private void SubmitWord(string input)
    {
        four = input;
        first = true;
    }
    //add user name to local variable for later use
    private void SubmitDifficulty(string input)
    {
        five = input;
        last = true;
    }
    //add user name to local variable for later use
    private void SubmitGrade(string input)
    {
        if (input.Length < 2)
        {
            six = input.ToCharArray()[0];
            grad = true;
        }

    }


    //format add user query and select using teacherID stored on login and auto increment of stuID
    public void ActivateAdd()
    {
        //check to see if neccesary variables were received
        if (first)
        {
            //check if username is already taken again
            if (!(CheckUsername.IsTaken(four)))
            {

                //direct db connection to where the db is stored in app
                //and open connection
                const string connectionString = "URI=file:Assets\\Plugins\\MumboJumbos.db";
                IDbConnection dbcon = new SqliteConnection(connectionString);
                dbcon.Open();

                //create query for adding user
                IDbCommand dbcmd = dbcon.CreateCommand();
                String command =
                "INSERT INTO wordlist " +
                "(SetID, Word, Difficulty, TeacherID, Grade) " +
                "VALUES (@two, @three, @four, @five, @six)";

                //dbcmd.Parameters.Add(new SqliteParameter("@one", one));    
                dbcmd.Parameters.Add(new SqliteParameter("@two", three));
                dbcmd.Parameters.Add(new SqliteParameter("@three", four));
                dbcmd.Parameters.Add(new SqliteParameter("@four", five));
                dbcmd.Parameters.Add(new SqliteParameter("@five", SubmitName.getTeachID()));
                dbcmd.Parameters.Add(new SqliteParameter("@six", six));
                string sql = command;
                dbcmd.CommandText = sql;
                IDataReader reader = dbcmd.ExecuteReader();
                addedText.text = "Word Added!";
                addedText.enabled = true;
                SetID.text = null;
                Word.text = null;
                Difficulty.text = null;
                Grade.text = null;

}
            else
            {
                SceneManager.LoadScene("AddWord");
                Reset();
            }

        }
        else
        {
            SceneManager.LoadScene("AddWord");
            Reset();
        }
    }

    private void Reset()
    {

        Grade.text = null;
        addButton.interactable = false;
        addedText.text = null;
        three = null;
        four = null;
        five = null;
        six = Convert.ToChar(0);

        //check for important variables being entered
        user = false;
        first = false;
        last = false;
        grad = false;

    }
}


