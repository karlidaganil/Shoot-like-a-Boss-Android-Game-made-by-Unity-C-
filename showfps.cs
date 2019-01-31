using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showfps : MonoBehaviour {

   float deltaTime;
   public  Text taşçıkmasüresitext;

	void Start () {
		
	}
	
	
	void Update () {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        taşçıkmasüresitext.text = Mathf.Ceil(fps).ToString();
    }
}
