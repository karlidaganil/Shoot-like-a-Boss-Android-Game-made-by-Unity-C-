using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class düsmanMermiKodu : MonoBehaviour {

    Rigidbody fizik;
    
    void Start () {
        fizik = GetComponent<Rigidbody>();
        fizik.velocity = new Vector3(-20f, 0f, 0f);
    }

}
