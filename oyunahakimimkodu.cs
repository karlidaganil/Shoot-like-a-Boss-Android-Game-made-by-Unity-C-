using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class oyunahakimimkodu : MonoBehaviour {

    public GameObject kayayolu;
    public GameObject yıldız;
    float taşzaman = 0f;
    float yıldızzaman = 0f;
    float yıldızÇıkmaSüresi;
    
    float taşçıkmasüresi=0.5f;  // 0.5 di bura değiştm deneme için //not==vscyn yi off yaptım her framde halinden tekli kayanın colliderını dışa aldım
    
    //quality kısmında fantastikten fastest haline aldm ve fastest ın pixel light count unu 0 dan 1 yaptm
    public Material[] skyboxlar;
    int EskiskyboxIndis;

    //public Text taşçıkmasüresitext;
    [HideInInspector]
    public AudioSource []arkaplanMüziği;
    [HideInInspector]
    public int eski;

    public GameObject dünyaPlayer;
    //GameObject failobj;


    public  static int lwlnum=-1;
   // public GameObject dünyaPlayer;
    public GameObject []gemiPlayers;
    public GameObject[] düşmanlar;
    // public GameObject dusmanGemi1;


    //public GameObject denemedüşman;

    float deltaTime;
    GameObject music;
   public GameObject failobj;
    public GameObject didItObj;
    bool taşGelsin = true;
    bool müzikDeğişebilirsn = true;
    bool skyboxDeğiştirebilirsin = true;
    void Awake()
    {
        arkaplanMüziği = GetComponents<AudioSource>();
        music = GameObject.FindGameObjectWithTag("music");
        // yıldızÇıkmaSüresi = 0.5f - 0.005f * (Application.loadedLevel - 3);
        yıldızÇıkmaSüresi = 0.45f;
        taşçıkmasüresi = 0.75f - 0.01f * (Application.loadedLevel - 3);



    }
    
    void Start () {     //kayanın metalyelini enable cpu instanses yaptım
        //arkaplanMüziği = GetComponents<AudioSource>();
        Destroy(music);
        float yEksenim = Random.Range(-7.2f, 7.45f);
        Instantiate(kayayolu, new Vector3(14f, yEksenim, 0f), Quaternion.Euler(0f, 0f, 90f));
       // InvokeRepeating("tasZamanıAzalt", 45f, 45f);
        InvokeRepeating("skyboxDegis", 30f, 30f);
        InvokeRepeating("yeniarkaplanmüziğiseç", 30f, 30f);
        
        girisArkaPlanMüziğiSeç();
        girisSkyboxSeç();

        int x = Random.Range(0, 42);
        Instantiate(düşmanlar[x], new Vector3(11.74f, 0f, 0f), Quaternion.identity);
      
        
            if (PlayerPrefs.GetInt("gemiplayerİndex") == 0)
            {
                Instantiate(gemiPlayers[0], new Vector3(-11f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));
                // Instantiate(denemedüşman, new Vector3(12.3f, 0f, 0f), Quaternion.Euler(0f, 90f, 90f));
            }
            if (PlayerPrefs.GetInt("gemiplayerİndex") == 1)
            {
                Instantiate(gemiPlayers[1], new Vector3(-11f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));
                // Instantiate(denemedüşman, new Vector3(12.3f, 0f, 0f), Quaternion.Euler(0f, 90f, 90f));
            }
            if (PlayerPrefs.GetInt("gemiplayerİndex") == 2)
            {
                Instantiate(gemiPlayers[2], new Vector3(-11f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));
                // Instantiate(denemedüşman, new Vector3(12.3f, 0f, 0f), Quaternion.Euler(0f, 90f, 90f));
            }
        if (PlayerPrefs.GetInt("gemiplayerİndex") == 3)
        {
            Instantiate(gemiPlayers[3], new Vector3(-11f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));
            // Instantiate(denemedüşman, new Vector3(12.3f, 0f, 0f), Quaternion.Euler(0f, 90f, 90f));
        }
        if (PlayerPrefs.GetInt("gemiplayerİndex") == 4)
        {
            Instantiate(gemiPlayers[4], new Vector3(-11f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));
            // Instantiate(denemedüşman, new Vector3(12.3f, 0f, 0f), Quaternion.Euler(0f, 90f, 90f));
        }
        if (PlayerPrefs.GetInt("gemiplayerİndex") == 5)
        {
            Instantiate(gemiPlayers[5], new Vector3(-11f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));
            // Instantiate(denemedüşman, new Vector3(12.3f, 0f, 0f), Quaternion.Euler(0f, 90f, 90f));
        }







        // else  if (PlayerPrefs.GetInt("gemiplayerİndex") == 1)
        //   {
        //       Instantiate(gemiPlayers[1], new Vector3(-11f, 0f, 0f), Quaternion.Euler(0f, -90f, 90f));
        //   }
        //else   if (PlayerPrefs.GetInt("gemiplayerİndex") == 0)
        //   {
        //       Instantiate(gemiPlayers[2], new Vector3(-11f, 0f, 0f), Quaternion.Euler(0f, -90f, 90f));
        //   }




    }


    void Update () {

        if(taşGelsin==true)
        {
            taşzaman = taşzaman + Time.deltaTime;
            if (taşzaman > taşçıkmasüresi)
            {
                float yEksenim = Random.Range(-7.2f, 7.45f);
                Instantiate(kayayolu, new Vector3(15f, yEksenim, 0f), Quaternion.Euler(0f, 0f, 90f));

                taşzaman = 0f;
            }
        }

       



        //deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        //float fps = 1.0f / deltaTime;
        //taşçıkmasüresitext.text = Mathf.Ceil(fps).ToString();


    }
    void FixedUpdate()
    {
        yıldızzaman = yıldızzaman + Time.deltaTime;
        if (yıldızzaman > yıldızÇıkmaSüresi)
        {
            float yEksenimYıldız = Random.Range(-7.2f, 7.45f);
            Instantiate(yıldız, new Vector3(20f, yEksenimYıldız, 0f), Quaternion.identity);
            yıldızzaman = 0;
        }


    }
    //void tasZamanıAzalt()
    //{
    //    if(taşçıkmasüresi>=0.2f)
    //    {
    //         taşçıkmasüresi = taşçıkmasüresi - 0.01f;
    //       // Debug.Log("azalttım==" + taşçıkmasüresi);
    //        taşçıkmasüresitext.text = taşçıkmasüresi + "";
            
    //    }
    //}
    void skyboxDegis()
    {
        if(skyboxDeğiştirebilirsin==true)
        {
            int i = Random.Range(0, 6);
            if (i != EskiskyboxIndis)
            {

                EskiskyboxIndis = i;
                RenderSettings.skybox = skyboxlar[EskiskyboxIndis];



            }
            else if (i == EskiskyboxIndis)
            {

                int x = Random.Range(0, 6);
                EskiskyboxIndis = x;
                RenderSettings.skybox = skyboxlar[EskiskyboxIndis];


            }
        }  
    }
    void girisSkyboxSeç()
    {
        
        int i = Random.Range(0, 6);
        EskiskyboxIndis = i;
        RenderSettings.skybox = skyboxlar[EskiskyboxIndis];
       
    }
    void girisArkaPlanMüziğiSeç()
    {
        int x = Random.Range(0, 9);
        eski = x;
        arkaplanMüziği[eski].Play();
        
    }
    void yeniarkaplanmüziğiseç()
    {
        if(müzikDeğişebilirsn==true)
        {
            arkaplanMüziği[eski].Stop();
            int y = Random.Range(0, 9);
            if (y != eski)
            {
                eski = y;
                arkaplanMüziği[eski].Play();
            }
            else if (y == eski)
            {
                int a = Random.Range(0, 9);
                eski = a;
                arkaplanMüziği[eski].Play();
            }
        }
      
    }
    

    public void oyunPause()
    {
        SceneManager.LoadScene(0);
    }

  public void failÇal()
    {
        arkaplanMüziği[eski].Stop();
        arkaplanMüziği[9].Play();
        failobj.SetActive(true);
       // taşGelsin = false;
        müzikDeğişebilirsn = false;
        skyboxDeğiştirebilirsin = false;

    }
    public void didİtÇal()
    {
        arkaplanMüziği[eski].Stop();
        arkaplanMüziği[10].Play();
        didItObj.SetActive(true);
        //taşGelsin = false;
        müzikDeğişebilirsn = false;
        skyboxDeğiştirebilirsin = false;
    }
    public void yenidenOyna()
    {
        SceneManager.LoadScene(Application.loadedLevel);
    }
    public void sonrakilwl()
    {
        SceneManager.LoadScene(Application.loadedLevel+1);
    }







}
