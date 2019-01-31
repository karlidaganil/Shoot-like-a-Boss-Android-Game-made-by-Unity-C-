using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroy : MonoBehaviour {

     void Awake()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("music");
        if(obj.Length>1) // || Application.loadedLevel>2
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }

    }
    void Start () {
       
	}
	
	
}
