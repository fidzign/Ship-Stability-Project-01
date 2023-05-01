using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class readData : MonoBehaviour
{

    private string txt;

    void Start()
    {
        FileInfo theSourceFile = null;
        StreamReader reader = null;
         
        theSourceFile = new FileInfo (Application.dataPath + "/data_hidrostatic.txt");
        if ( theSourceFile != null && theSourceFile.Exists )
           reader = theSourceFile.OpenText();
         
        if ( reader == null )
        {
           Debug.Log("data not found or not readable");
        }

        reader.ReadLine();

      //  print("data ;" + theSourceFile);
    }
}