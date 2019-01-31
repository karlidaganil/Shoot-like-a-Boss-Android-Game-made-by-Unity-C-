using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mermiKodu : MonoBehaviour {

    // public GameObject patlatmaEfekti;
    public ParticleSystem patlamaEfekti;


    AudioSource[] sesler;
  //  public GameObject müzikobjesi;
    //float score = 0f;
    GameObject gemiplayer;
    GemiPlayerKodu gemiplayerKodu;
    
    void Start () {
        sesler = GetComponents<AudioSource>();
        gemiplayer = GameObject.FindGameObjectWithTag("gemi1Sprite");
        gemiplayerKodu = gemiplayer.GetComponent<GemiPlayerKodu>();
        
    }


    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag=="kayatagi")
        {
            sesler[0].Play();
            Destroy(coll.gameObject);
            transform.position = new Vector3(500f, 500f, 500f);
            Destroy(gameObject,1f);
            //Instantiate(müzikobjesi, new Vector3(500f, 500f, 500f), Quaternion.identity);
            //GameObject efktobje = Instantiate(patlatmaEfekti, coll.transform.position, Quaternion.identity);
            //Destroy(efktobje, 2f);
            patlamaEfekti.Play();

            patlamaEfekti.transform.position = new Vector3(coll.transform.position.x, coll.transform.position.y, coll.transform.position.z);






            //gemiplayer.GetComponent<GemiPlayerKodu>().score += 100;    //ASLINDA BU VE ALTTAKİ SATIR ÇALIŞIOR AMA AŞADAKİNİ DENEDK HEM GET YAPMAMAK İÇİN
            //gemiplayer.GetComponent<GemiPlayerKodu>().scoreumText.text = "Score" + gemiplayer.GetComponent<GemiPlayerKodu>().score;


            gemiplayerKodu.score += 100;
            gemiplayerKodu.scoreumText.text = "Score" +gemiplayerKodu.score;



            //  GameObject.FindGameObjectWithTag("gemiplayer").GetComponent<GemiPlayerKodu>().scoreText.text= "Scoreeee " + GameObject.FindGameObjectWithTag("gemiplayer").GetComponent<GemiPlayerKodu>().score;



        }

    }

   
}
