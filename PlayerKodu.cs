using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerKodu : MonoBehaviour {

    Rigidbody fizik;
    //public float speed;
    //public Text yıldızsayısıtext;
    //public Text scoreText;
    //public Text lavhalisayısıText;
    public float jumpForce;
    
    public GameObject dünyapatlama;
    public GameObject kayapatlama;

    public ParticleSystem partEfect;

    
    public Material lavMat;
    public Material dunyaMat;

    int yıldızsayısı = 0;
    int score = 0;
    int astroidPatlatmahakkıSayısı =0;

    AudioSource[] sesler;
    float puanArttırmazamanı = 0f;

    //AsyncOperation asyncLoad;

    Text myScoretext;
    Text myYıldızSayımText;
    Text myLavhalisayısıText;
    void Awake()
    {
        fizik = GetComponent<Rigidbody>();
        sesler = GetComponents<AudioSource>();

        //Invoke("loadSahne", 1f);

        myScoretext = GameObject.FindGameObjectWithTag("scoreText").GetComponent<Text>();
        myYıldızSayımText= GameObject.FindGameObjectWithTag("yıldızsayısıText").GetComponent<Text>();
        myLavhalisayısıText= GameObject.FindGameObjectWithTag("canText").GetComponent<Text>();
    }
    void Start () {
        //fizik = GetComponent<Rigidbody>();
        //sesler = GetComponents<AudioSource>();


        //asyncLoad = SceneManager.LoadSceneAsync(0);
        //asyncLoad.allowSceneActivation = false;
        // Invoke("loadSahne", 0.1f);
        //lavhalisayısıText.text = astroidPatlatmahakkıSayısı + "";   çalışan halinde bura açık
       // myScoretext.text = "ana skm";
    }
	
	// Update is called once per frame
	void FixedUpdate () {

      /*  float yatay = Input.GetAxisRaw("Horizontal");
        float dikey = Input.GetAxisRaw("Vertical");
        fizik.AddForce(new Vector3(yatay, 0.0f, dikey)*Time.deltaTime*speed); */
        if(Input.GetMouseButton(0))
        {
            fizik.velocity = new Vector3(0f, 0f, 0f);
            fizik.AddForce(new Vector3(0f, jumpForce, 0f));
            sesler[0].Play();
        }
      
       transform.Rotate(new Vector3(0f, 0f, 5f));

    }
    void Update()
    {
        puanArttırmazamanı = puanArttırmazamanı + Time.deltaTime;
        if(puanArttırmazamanı>0.75f)
        {
            score++;
           // scoreText.text = "Score " + score;     çalışan halinde bura var
            myScoretext.text= "Score " + score;
            puanArttırmazamanı = 0f;
        }
        //if(astroidPatlatmahakkıSayısı>0)
        //{
        //    gameObject.GetComponent<MeshRenderer>().material = lavMat;
        //    partEfect.Play();
        //}
        //else
        //{
        //    gameObject.GetComponent<MeshRenderer>().material = dunyaMat;
        //    partEfect.Stop();
        //}
        //lavhalisayısıText.text = astroidPatlatmahakkıSayısı + ""; 

    }
  

    void OnTriggerEnter(Collider coll)
    {
        
        if(coll.tag=="kayatagi"  ||   coll.tag == "upsınır" || coll.tag == "downsınır") //alttan çıkma yaparken burda ekstra coll tag ekle
        {
            if(astroidPatlatmahakkıSayısı>0)
            {
                if(coll.tag == "kayatagi")
                {
                    GameObject player;
                    sesler[2].Play();
                    player = Instantiate(kayapatlama, coll.transform.position, Quaternion.identity) as GameObject;
                    Destroy(coll.gameObject);     //alt ve üst baundary i yok ediyorm bunu düzelt
                    Destroy(player, 2f);
                    astroidPatlatmahakkıSayısı--;
                    // lavhalisayısıText.text = astroidPatlatmahakkıSayısı + "";
                    myLavhalisayısıText.text = astroidPatlatmahakkıSayısı + "";
                    if (astroidPatlatmahakkıSayısı == 0)
                    {
                        gameObject.GetComponent<MeshRenderer>().material = dunyaMat;
                        partEfect.Stop();
                    }


                }
                //else if(coll.tag == "baundary")
                //{
                //    GameObject player;
                //    sesler[2].Play();
                //    player = Instantiate(kayapatlama,transform.position, Quaternion.identity) as GameObject;
                //   // Destroy(coll.gameObject);     //alt ve üst baundary i yok ediyorm bunu düzelt
                //    Destroy(player, 2f);
                //    astroidPatlatmahakkıSayısı--;
                //    //lavhalisayısıText.text = astroidPatlatmahakkıSayısı + "";
                //    myLavhalisayısıText.text = astroidPatlatmahakkıSayısı + "";
                //    if (astroidPatlatmahakkıSayısı == 0)
                //    {
                //        gameObject.GetComponent<MeshRenderer>().material = dunyaMat;
                //        partEfect.Stop();
                //    }
                    
                    


                //}
               
            }
            else if (astroidPatlatmahakkıSayısı == 0)
            {
                if (coll.tag == "kayatagi")
                {
                    
                    sesler[2].Play();
                    Instantiate(dünyapatlama, transform.position, Quaternion.identity);

                    //Destroy(gameObject);
                    // gameObject.active = false;
                    gameObject.SetActive(false);        //burayı sonradan değiştirdim setAktive yaptım

                    PlayerPrefs.SetInt("yıldızSayısı1", PlayerPrefs.GetInt("yıldızSayısı1") + yıldızsayısı);
                    Destroy(coll.gameObject);

                    Invoke("Anamenuyukle", 2f);


                    if (astroidPatlatmahakkıSayısı == 0)
                    {
                        gameObject.GetComponent<MeshRenderer>().material = dunyaMat;
                        partEfect.Stop();
                    }
                }
                    

            }
            if (coll.tag == "upsınır")
            {
                transform.position = new Vector3(transform.position.x, GameObject.FindGameObjectWithTag("downsınır").transform.position.y+1.2f, 0f);
                Debug.Log("sınıra deydim");
            }
            if (coll.tag == "downsınır")
            {
                transform.position = new Vector3(transform.position.x, GameObject.FindGameObjectWithTag("upsınır").transform.position.y-1.2f, 0f);
                Debug.Log("sınıra deydim");
            }
        }
        if(coll.tag=="yıldıztagi")
        {
            yıldızsayısı++;
            score = score + 100;
            // yıldızsayısıtext.text = yıldızsayısı+"";
            // scoreText.text = "Score " + score;
            myYıldızSayımText.text = yıldızsayısı + "";
            myScoretext.text = "Score " + score;

            Destroy(coll.gameObject);
            sesler[3].Play();
            if(yıldızsayısı%3==0 && yıldızsayısı!=0)
            {
                if(astroidPatlatmahakkıSayısı<3)
                {
                    astroidPatlatmahakkıSayısı++;
                    // lavhalisayısıText.text = astroidPatlatmahakkıSayısı + "";
                    myLavhalisayısıText.text = astroidPatlatmahakkıSayısı + "";
                    gameObject.GetComponent<MeshRenderer>().material = lavMat;
                        partEfect.Play();
                    
                }

            }
          

        }
        //if(coll.tag=="oyunsınırıtagı")
        //{
        //    Invoke("Anamenuyukle", 2f);
        //}

       
    }
   
     void Anamenuyukle()
    {
        // Debug.Log("invoke çağırıldı");
        SceneManager.LoadScene(0);
        //asyncLoad.allowSceneActivation = true;
        
    }
 
  
    //void loadSahne()
    //{
    //    asyncLoad = SceneManager.LoadSceneAsync(0);
    //    asyncLoad.allowSceneActivation = false;
    //}

}
