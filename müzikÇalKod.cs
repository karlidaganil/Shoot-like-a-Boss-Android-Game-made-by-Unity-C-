using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class müzikÇalKod : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("kendiniYokET", 2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void kendiniYokET()
    {
        Destroy(gameObject);
    }
}
