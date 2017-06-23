using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JsonFx.Json;


public class DatabaseManager : MonoBehaviour {

    // Use this for initialization
    void Start () {

       
    }

    // Update is called once per frame
    void Update () {
		
	}

    public IEnumerator LoadDB_IEnumerator(string post_url, string result, Action<string> myMethodName)
    {
     
        //get all the data of object from each 
        
        WWW hs_post = new WWW(post_url);
        yield return hs_post; // Wait until the download is done


        if (hs_post.error != null)
        {
            Debug.LogError("Cannot Connect to component....db!");
            Debug.LogError("server returned: " + hs_post.error);
            
        }
        else
        {
            result = hs_post.text;
            myMethodName(result);
        }

    }


}
