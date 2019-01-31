using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class düşmanGemiKodu : MonoBehaviour {

    Rigidbody fizik;
    public GameObject mermi;
    public Transform mermiPos;
    float zaman = 0f;
    GameObject gemiPlayer1;
    int darbeSayısı = 0;
    //public GameObject patlamaEfekti;
    GameObject oyunKontroller;
    public ParticleSystem patlama;
   // public ParticleSystem sonPatlama;
    AudioSource[] sesler;

    public Image canBarı;
    float oyunbas = 0f;

    //public GameObject bigEXP;
    public GameObject mysprite;
    Collider mycoll;
    
    bool ptlamaEfktAçık = false;
    //public GameObject didIt;
    bool mermiAtsın = true;

    float yediğimHasar;
    float canım;

    float mermiİçinZaman=0f;
    float mermiAtmaAralığı;
    float takipHızı;
    bool gemiyiTakipEt = true;
    
     void Awake()
    {
        oyunKontroller = GameObject.FindGameObjectWithTag("GameController");

        canım = 100f + 200f * (Application.loadedLevel - 3);
        mermiAtmaAralığı = 1.5f - 0.01f * (Application.loadedLevel - 3);
        takipHızı = 1.5f + 0.05f * (Application.loadedLevel - 3);
        



      
    }
    void Start () {
        fizik = GetComponent<Rigidbody>();
        InvokeRepeating("mermiAt", 1f, mermiAtmaAralığı);
      //  canBarı.fillAmount = 1f;
       // gemiPlayer1 = GameObject.FindGameObjectWithTag("gemi1Sprite");

        Invoke("gemiPlayerBulucu", 0.1f);
        sesler = GetComponents<AudioSource>();
        mycoll = GetComponent<Collider>();
        switch (PlayerPrefs.GetInt("gemiplayerİndex"))
        {
            case 0:
                yediğimHasar = 5f;
                break;
            case 1:
                yediğimHasar = 10f;
                break;
            case 2:
                yediğimHasar = 20f;
                break;
            case 3:
                yediğimHasar = 40f;
                break;
            case 4:
                yediğimHasar = 80f;
                break;
            case 5:
                yediğimHasar = 160f;
                break;
        }
      
    }


    void Update()
    {
        zaman = zaman + Time.deltaTime;
        if (zaman > 0.5f && gemiyiTakipEt==true)
        {
            enemiyoluyap();

        }

        //mermiİçinZaman = mermiİçinZaman + Time.deltaTime;
        //if (mermiİçinZaman > mermiAtmaAralığı)
        //{
        //    mermiAt();
        //    mermiİçinZaman = 0f;
        //}




    }

    void enemiyoluyap()
    {
        
        if (transform.position.y < gemiPlayer1.transform.position.y)
        {
            fizik.velocity = new Vector3(0f, takipHızı, 0f);
            
            if (gemiPlayer1.transform.position.y - transform.position.y < 0.1f)
            {
                fizik.velocity = new Vector3(0f, 0f, 0f);

            }
        }
        if (transform.position.y > gemiPlayer1.transform.position.y)
        {
            fizik.velocity = new Vector3(0f, -takipHızı, 0f);
           // Debug.Log("inior tamer");
            if (transform.position.y - gemiPlayer1.transform.position.y < 0.1f)
            {
                fizik.velocity = new Vector3(0f, 0f, 0f);

            }
        }
    }




    void mermiAt()
    {
        if(mermiAtsın==true)
        {
            //Instantiate(mermi, mermiPos.position, Quaternion.Euler(0f,-90f,0f));
            Instantiate(mermi, mermiPos.position, Quaternion.identity);
            
        }
       
    }
    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag=="mermitagi")
        {
            darbeSayısı++;
            canBarı.fillAmount = canBarı.fillAmount - yediğimHasar / canım ;
            //Debug.Log(canBarı.fillAmount);
            //if(ptlamaEfktAçık==false)
            //  {
            //      
            //      ptlamaEfktAçık = true;
            //  }
            //GameObject efekt = Instantiate(patlamaEfekti, transform.position, Quaternion.identity);
            //Destroy(efekt, 2f);
            patlama.Play();
            Destroy(coll.gameObject);
            if (canBarı.fillAmount<=0f)
            {
                //Destroy(gameObject);
                // Instantiate(bigEXP, coll.transform.position, Quaternion.identity);
                //  sonPatlama.Play();
                patlama.transform.localScale = new Vector3(5f, 5f, 5f);
                patlama.Play();
            
                sesler[0].Play();
                //gameObject.SetActive(false);
                mysprite.SetActive(false);
                mycoll.enabled = false;
                //transform.position = new Vector3(500, 500, 500);
                // SceneManager.LoadScene(0);
                //didIt.SetActive(true);
                //sesler[1].Play();
                mermiAtsın = false;
                oyunKontroller.GetComponent<oyunahakimimkodu>().didİtÇal();
                GameObject.FindGameObjectWithTag("gemi1Sprite").GetComponent<GemiPlayerKodu>().yıldızlarıEkle(); //bura ii durmadı burayı düzelt
                                                                                                                 // Invoke("AnaMenüReturn", 2.5f);                                                                     //çünkü sadece tek bir gemi tagi için yapabilir   
                Debug.Log("applwl==" + Application.loadedLevel + "    " + "player prefs===" + PlayerPrefs.GetInt("yendiğimlwl"));
                  if(Application.loadedLevel - 2>PlayerPrefs.GetInt("yendiğimlwl"))
                {
                    PlayerPrefs.SetInt("yendiğimlwl", Application.loadedLevel - 2);
                }
                //if((Application.loadedLevel-2)%2==0)
                //{
                //    GameObject.FindGameObjectWithTag("reklam").GetComponent<REKLAM>().reklamıGöster();
                //    Debug.Log("reklama girdim");
                //}

                if (PlayerPrefs.HasKey("yenmeSayım"))
                {
                    PlayerPrefs.SetInt("yenmeSayım", PlayerPrefs.GetInt("yenmeSayım") + 1);
                    if (PlayerPrefs.GetInt("yenmeSayım") % 3 == 0)
                    {
                        Invoke("geçişRekGöster", 2f);
                        Debug.Log("reklama girdim");
                    }
                }
                else
                {
                    PlayerPrefs.SetInt("yenmeSayım", 1);
                    Debug.Log("yenme sayısı oluşturdm");
                }



                // GameObject.FindGameObjectWithTag("reklam").GetComponent<REKLAM>().reklamıGöster();

            }
        }
    }


    void gemiPlayerBulucu()
    {
         gemiPlayer1 = GameObject.FindGameObjectWithTag("gemi1Sprite");
       
    }
    public void AnaMenüReturn()
    {
        SceneManager.LoadScene(0);
        
    }
   public void solaDoğruGit()
    {
        fizik.velocity = new Vector3(-3f, 0f, 0f);
        gameObject.GetComponent<Collider>().enabled = false;
        gemiyiTakipEt = false;
        mermiAtsın = false;
    }
    void geçişRekGöster()
    {
        GameObject.FindGameObjectWithTag("reklam").GetComponent<REKLAM>().reklamıGöster();
    }
}
