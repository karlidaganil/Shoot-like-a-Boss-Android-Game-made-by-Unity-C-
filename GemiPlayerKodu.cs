using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GemiPlayerKodu : MonoBehaviour {

    Rigidbody fizik;
   // public GameObject gemipatlama;
    public ParticleSystem gemipatlama;
    GameObject oyunKontroller;

    public Image canBarı;

    // public Text canText;
   // int canSayısı = 3;

    public GameObject mermi;
    public Transform mermiCıkısYeri;
    float puanArttırmazamanı = 0f;
    [HideInInspector]
    public int score = 0;
   // public Text scoreText;
    int yıldızsayısı = 0;
    //public Text yıldızsayısıtext;

    AudioSource[] sesler;
    [HideInInspector]
     public  Text  yıldızsayımText, scoreumText;

    //public GameObject failed;
    [HideInInspector]
    public bool mermiSık = true;
    float damageYe;
    float canım;
    GameObject düşmanGemi;
    float mermiAtmaSıklığı;
    bool skoruYükselt = true;
    void Awake()
    {
        scoreumText = GameObject.FindGameObjectWithTag("scoreText").GetComponent<Text>();
        yıldızsayımText = GameObject.FindGameObjectWithTag("yıldızsayısıText").GetComponent<Text>();
       // MycanText = GameObject.FindGameObjectWithTag("canText").GetComponent<Text>();
        oyunKontroller = GameObject.FindGameObjectWithTag("GameController");
        düşmanGemi = GameObject.FindGameObjectWithTag("düsmanGemi");
        switch (PlayerPrefs.GetInt("gemiplayerİndex"))
        {
            case 0:
                mermiAtmaSıklığı = 0.35f;
                break;
            case 1:
                mermiAtmaSıklığı = 0.35f;
                break;
            case 2:
                mermiAtmaSıklığı = 0.35f;
                break;
            case 3:
                mermiAtmaSıklığı = 0.35f;
                break;
            case 4:
                mermiAtmaSıklığı = 0.35f;
                break;
            case 5:
                mermiAtmaSıklığı = 0.35f;
                break;
        }
    }
    void Start () {
        fizik = GetComponent<Rigidbody>();
        sesler = GetComponents<AudioSource>();
        InvokeRepeating("mermiYolla", mermiAtmaSıklığı, mermiAtmaSıklığı);
        //  canText.text = canSayısı+"";
        //MycanText.text = canSayısı + "";
        switch (PlayerPrefs.GetInt("gemiplayerİndex"))
        {
            case 0:
                canım = 100f;
                break;
            case 1:
                canım = 200f;
                break;
            case 2:
                canım = 400f;
                break;
            case 3:
                canım = 800f;
                break;
            case 4:
                canım = 1000f;
                break;
            case 5:
                canım = 1200f;
                break;
        }
        damageYe = 30f + 10f * (Application.loadedLevel - 3);


       

    }
	
	// Update is called once per frame
	void Update () {


        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    fizik.velocity = new Vector3(0f, 5f, 0f);
        //}
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    fizik.velocity = new Vector3(0f, -5f, 0f);
        //}
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    fizik.velocity = new Vector3(-5f, 0f, 0f);
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    fizik.velocity = new Vector3(5f, 0, 0f);
        //}
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    fizik.velocity = new Vector3(0f, 0f, 0f);
        //}

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * Time.deltaTime * 5f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * Time.deltaTime * 5f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * 5f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * 5f);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z + 2f));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z - 2f));
        }















        for (int i = 0; i < Input.touchCount; i++)           //ilk if in için Input.GetTouch(i).phase == TouchPhase.Moved idi
        {
            if (Input.GetTouch(i).phase == TouchPhase.Moved)
            {
                Vector2 touchPosition = Input.GetTouch(i).position;
                double halfScreen = Screen.width / 2.0;


                if (touchPosition.x < halfScreen)
                {
                    //transform.Translate(Input.GetTouch(i).deltaPosition * Time.deltaTime * 0.35f, Space.World);
                    // Debug.Log(Input.GetTouch(i).deltaPosition);

                    //Debug.Log("sola deydim");

                    transform.Translate(Input.GetTouch(i).deltaPosition * 0.0075f, Space.World);
                }
                else if (touchPosition.x > halfScreen)
                {
                    // Debug.Log("sağa deydim");

                    //transform.Rotate(0f, 0f, Input.GetTouch(i).deltaPosition.y * 10f * Time.deltaTime); birleşik
                    transform.Rotate(0f, 0f, Input.GetTouch(i).deltaPosition.y * 0.080f );

                }
            }
        }



    }

    void FixedUpdate()
    {
        if(skoruYükselt==true)
        {
            puanArttırmazamanı = puanArttırmazamanı + Time.deltaTime;
            if (puanArttırmazamanı > 0.75f)
            {
                score++;
                // scoreText.text = "Score " + score;
                scoreumText.text = "Score " + score;
                puanArttırmazamanı = 0f;
            }
        }
     
        
    }


    void OnTriggerEnter(Collider coll)
    {
       if(coll.tag == "kayatagi" || coll.tag == "baundary" || coll.tag== "dusmanMermi1")
        {
            Destroy(coll.gameObject);
            //GameObject çarpma = Instantiate(gemipatlama, transform.position, Quaternion.identity);
            //Destroy(çarpma, 1.5f);
            gemipatlama.Play();
            sesler[1].Play();
            //canSayısı--;
            //canText.text = canSayısı + "";
            //  canBarı.fillAmount = canBarı.fillAmount - 0.33f;
            if(coll.tag== "dusmanMermi1")
            {
                canBarı.fillAmount = canBarı.fillAmount - damageYe / canım;
            }
            else if(coll.tag == "kayatagi")
            {
                canBarı.fillAmount = canBarı.fillAmount - 15f / canım;
            }

            
            //if (canSayısı>=0)
            //{
            //    MycanText.text = canSayısı + "";
            //}

            //if (canSayısı<0)
            //{

            //    //gameObject.SetActive(false);
            //    transform.position = new Vector3(500, 500, 500);
            //   // Instantiate(failed, new Vector3(0f, 0f, 0f), Quaternion.identity);
            //    //Invoke("levelıYenidenykle", 2f);
            //    PlayerPrefs.SetInt("yıldızSayısı1",PlayerPrefs.GetInt("yıldızSayısı1")+yıldızsayısı);
            //    oyunKontroller.GetComponent<oyunahakimimkodu>().failÇal();

            //}
            if (canBarı.fillAmount<=0f)
            {
                mermiSık = false;
                //gameObject.SetActive(false);
                transform.position = new Vector3(500, 500, 500);
                // Instantiate(failed, new Vector3(0f, 0f, 0f), Quaternion.identity);
                //Invoke("levelıYenidenykle", 2f);
                PlayerPrefs.SetInt("yıldızSayısı1", PlayerPrefs.GetInt("yıldızSayısı1") + yıldızsayısı);
                oyunKontroller.GetComponent<oyunahakimimkodu>().failÇal();
                düşmanGemi.GetComponent<düşmanGemiKodu>().solaDoğruGit();

                if (PlayerPrefs.HasKey("ölmeSayım"))
                {
                    PlayerPrefs.SetInt("ölmeSayım", PlayerPrefs.GetInt("ölmeSayım") + 1);
                    if (PlayerPrefs.GetInt("ölmeSayım") % 3 == 0)
                    {
                        Invoke("geçişreklamınıGÖSTER", 2f);
                        Debug.Log("reklama girdim");
                    }
                }
                else
                {
                    PlayerPrefs.SetInt("ölmeSayım", 1);
                    Debug.Log("ölme sayısı oluşturdm");
                }
                // GameObject.FindGameObjectWithTag("reklam").GetComponent<REKLAM>().reklamıGöster();
            }
        }





        if (coll.tag == "yıldıztagi")
        {
            yıldızsayısı++;
            score = score + 100;
            // yıldızsayısıtext.text = yıldızsayısı + "";
            yıldızsayımText.text = yıldızsayısı + "";
            //scoreText.text = "Score " + score;
            scoreumText.text = "Score " + score;

            Destroy(coll.gameObject);
            sesler[0].Play();
       


        }
    }

    void mermiYolla()
    {
        //if(gameObject.tag=="gemiplayer1"||gameObject.tag=="gemi1Sprite")
        //{
        //    GameObject Mermiobje = Instantiate(mermi, mermiCıkısYeri.position, transform.rotation);
        //    Mermiobje.GetComponent<Rigidbody>().velocity = Mermiobje.transform.right * 10;
        //}
        if(mermiSık==true)
        {
            GameObject Mermiobje = Instantiate(mermi, mermiCıkısYeri.position, transform.rotation);
            Mermiobje.GetComponent<Rigidbody>().velocity = Mermiobje.transform.right * 10;
        }
       


    }
    void levelıYenidenykle()
    {
        SceneManager.LoadScene(0);

    }
    public void yıldızlarıEkle()
    {
        PlayerPrefs.SetInt("yıldızSayısı1", PlayerPrefs.GetInt("yıldızSayısı1") + yıldızsayısı);
        mermiSık = false;
        gameObject.GetComponent<Collider>().enabled = false;
        GetComponent<boundaries>().enabled = false;
        fizik.velocity = new Vector3(3f, 0f, 0f);
        skoruYükselt = false;
    }
    void geçişreklamınıGÖSTER()
    {
        GameObject.FindGameObjectWithTag("reklam").GetComponent<REKLAM>().reklamıGöster();
    }
  

}
