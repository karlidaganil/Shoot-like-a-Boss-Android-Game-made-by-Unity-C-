using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuKontrolKodu : MonoBehaviour {
    
    //PANALDE scroll react de declaration rate 0.135 idi 1 yaptım
    //Lighting den skybox un ambiant ini realtime dan baked yaptım
    // ve realtime global Iı yi kapadm açıktı önceden
    public Text yıldızSayısıText;
    AudioSource[] aSource;
    public Text playText;
    public Text shipText;
    public Text infoText;
    //public Text uGotIt;
    public GameObject ugotİt;
    public GameObject NoEnoughStars;
    int geçtiğimlwl;
    //void Awake()
    //{
    //    PlayerPrefs.DeleteAll();
    //}
    void Start()
    {
        yıldızSayısıText.text = PlayerPrefs.GetInt("yıldızSayısı1") + "";
        aSource = GetComponents<AudioSource>();
        // DontDestroyOnLoad(this.gameObject);

        //Invoke("geçişReklamıGöster", 1f);
        



    }
   
        
    public void lwl_1()
    {
        SceneManager.LoadScene(3);
        aSource[0].Play();
    }
    public void lwl_2()
    {
        SceneManager.LoadScene(4);
        aSource[0].Play();
    }
    public void lwl_3()
    {
        SceneManager.LoadScene(5);
        aSource[0].Play();
    }
    public void lwl_4()
    {
        SceneManager.LoadScene(6);
        aSource[0].Play();
    }
    public void lwl_5()
    {
        SceneManager.LoadScene(7);
        aSource[0].Play();
    }
    public void lwl_6()
    {
        SceneManager.LoadScene(8);
        aSource[0].Play();
    }
    public void lwl_7()
    {
        SceneManager.LoadScene(9);
        aSource[0].Play();
    }
    public void lwl_8()
    {
        SceneManager.LoadScene(10);
        aSource[0].Play();
    }
    public void lwl_9()
    {
        SceneManager.LoadScene(11);
        aSource[0].Play();
    }
    public void lwl_10()
    {
        SceneManager.LoadScene(12);
        aSource[0].Play();
    }
    public void lwl_11()
    {
        SceneManager.LoadScene(13);
        aSource[0].Play();
    }
    public void lwl_12()
    {
        SceneManager.LoadScene(14);
        aSource[0].Play();
    }
    public void lwl_13()
    {
        SceneManager.LoadScene(15);
        aSource[0].Play();
    }
    public void lwl_14()
    {
        SceneManager.LoadScene(16);
        aSource[0].Play();
    }
    public void lwl_15()
    {
        SceneManager.LoadScene(17);
        aSource[0].Play();
    }
    public void lwl_16()
    {
        SceneManager.LoadScene(18);
        aSource[0].Play();
    }
    public void lwl_17()
    {
        SceneManager.LoadScene(19);
        aSource[0].Play();
    }
    public void lwl_18()
    {
        SceneManager.LoadScene(20);
        aSource[0].Play();
    }
    public void lwl_19()
    {
        SceneManager.LoadScene(21);
        aSource[0].Play();
    }
    public void lwl_20()
    {
        SceneManager.LoadScene(22);
        aSource[0].Play();
    }
    public void lwl_21()
    {
        SceneManager.LoadScene(23);
        aSource[0].Play();
    }
    public void lwl_22()
    {
        SceneManager.LoadScene(24);
        aSource[0].Play();
    }
    public void lwl_23()
    {
        SceneManager.LoadScene(25);
        aSource[0].Play();
    }
    public void lwl_24()
    {
        SceneManager.LoadScene(26);
        aSource[0].Play();
    }
    public void lwl_25()
    {
        SceneManager.LoadScene(27);
        aSource[0].Play();
    }
    public void lwl_26()
    {
        SceneManager.LoadScene(28);
        aSource[0].Play();
    }
    public void lwl_27()
    {
        SceneManager.LoadScene(29);
        aSource[0].Play();
    }
    public void lwl_28()
    {
        SceneManager.LoadScene(30);
        aSource[0].Play();
    }
    public void lwl_29()
    {
        SceneManager.LoadScene(31);
        aSource[0].Play();
    }
    public void lwl_30()
    {
        SceneManager.LoadScene(32);
        aSource[0].Play();
    }
    public void lwl_31()
    {
        SceneManager.LoadScene(33);
        aSource[0].Play();
    }
    public void lwl_32()
    {
        SceneManager.LoadScene(34);
        aSource[0].Play();
    }
    public void lwl_33()
    {
        SceneManager.LoadScene(35);
        aSource[0].Play();
    }
    public void lwl_34()
    {
        SceneManager.LoadScene(36);
        aSource[0].Play();
    }
    public void lwl_35()
    {
        SceneManager.LoadScene(37);
        aSource[0].Play();
    }
    public void lwl_36()
    {
        SceneManager.LoadScene(38);
        aSource[0].Play();
    }
    public void lwl_37()
    {
        SceneManager.LoadScene(39);
        aSource[0].Play();
    }
    public void lwl_38()
    {
        SceneManager.LoadScene(40);
        aSource[0].Play();
    }
    public void lwl_39()
    {
        SceneManager.LoadScene(41);
        aSource[0].Play();
    }
    public void lwl_40()
    {
        SceneManager.LoadScene(42);
        aSource[0].Play();
    }
    public void lwl_41()
    {
        SceneManager.LoadScene(43);
        aSource[0].Play();
    }
    public void lwl_42()
    {
        SceneManager.LoadScene(44);
        aSource[0].Play();
    }








    public void playButton()
    {
        // SceneManager.LoadScene(1);
        Invoke("playButtonİnvoke", 1f);
        aSource[0].Play();
        playText.fontSize = playText.fontSize - 50;
       
    }
    public void shipsMenüButton()
    {
        //  SceneManager.LoadScene(2);
        Invoke("shipButtotnİnvoke", 1f);
        aSource[0].Play();
        shipText.fontSize = shipText.fontSize - 50;
    }
    public void info()
    {
        Invoke("infoykle", 1f);
        aSource[0].Play();
        infoText.fontSize = infoText.fontSize - 50;
        
    }
    public void gemi1seçimi()
    {
        
        if(PlayerPrefs.HasKey("gemiplayerİndex"))
        {
            if (PlayerPrefs.GetInt("yıldızSayısı1") >= 1   &&  PlayerPrefs.GetInt("gemiplayerİndex") != 1)
            {
                PlayerPrefs.SetInt("gemiplayerİndex", 1);
                PlayerPrefs.SetInt("yıldızSayısı1", PlayerPrefs.GetInt("yıldızSayısı1") - 1);
                yıldızSayısıText.text = PlayerPrefs.GetInt("yıldızSayısı1") + "";
                aSource[0].Play();
                //gotİt.active = true;
                //uGotIt.text = "YOU GOT IT";
                //Invoke("sil", 1f);
                Instantiate(ugotİt, new Vector3(0f, 0f, 0f), Quaternion.identity);
            }
            else
            {
                Instantiate(NoEnoughStars , new Vector3(0f, 0f, 0f), Quaternion.identity);
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("yıldızSayısı1") >= 1)
            {
                PlayerPrefs.SetInt("gemiplayerİndex", 1);
                PlayerPrefs.SetInt("yıldızSayısı1", PlayerPrefs.GetInt("yıldızSayısı1") - 1);
                yıldızSayısıText.text = PlayerPrefs.GetInt("yıldızSayısı1") + "";
                aSource[0].Play();
                //uGotIt.text = "YOU GOT IT";
                //Invoke("sil", 1f);
                Instantiate(ugotİt, new Vector3(0f, 0f, 0f), Quaternion.identity);
            }
            else
            {
                Instantiate(NoEnoughStars, new Vector3(0f, 0f, 0f), Quaternion.identity);
            }

        }
        
    }
    public void gemi2seçimi()
    {
        if (PlayerPrefs.HasKey("gemiplayerİndex"))
        {
            if (PlayerPrefs.GetInt("yıldızSayısı1") >= 1 && PlayerPrefs.GetInt("gemiplayerİndex") != 2)
            {
                PlayerPrefs.SetInt("gemiplayerİndex", 2);
                PlayerPrefs.SetInt("yıldızSayısı1", PlayerPrefs.GetInt("yıldızSayısı1") - 1);
                yıldızSayısıText.text = PlayerPrefs.GetInt("yıldızSayısı1") + "";
                aSource[0].Play();
                //uGotIt.text = "YOU GOT IT";
                //Invoke("sil", 1f);
                Instantiate(ugotİt, new Vector3(0f, 0f, 0f), Quaternion.identity);
            }
            else
            {
                Instantiate(NoEnoughStars, new Vector3(0f, 0f, 0f), Quaternion.identity);
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("yıldızSayısı1") >= 1)
            {
                PlayerPrefs.SetInt("gemiplayerİndex", 2);
                PlayerPrefs.SetInt("yıldızSayısı1", PlayerPrefs.GetInt("yıldızSayısı1") - 1);
                yıldızSayısıText.text = PlayerPrefs.GetInt("yıldızSayısı1") + "";
                aSource[0].Play();
                //uGotIt.text = "YOU GOT IT";
                //Invoke("sil", 1f);
                Instantiate(ugotİt, new Vector3(0f, 0f, 0f), Quaternion.identity);
            }
            else
            {
                Instantiate(NoEnoughStars, new Vector3(0f, 0f, 0f), Quaternion.identity);
            }

        }

        
            
    }
    public void gemi3seçimi()
    {
        if (PlayerPrefs.HasKey("gemiplayerİndex"))
        {
            if (PlayerPrefs.GetInt("yıldızSayısı1") >= 1 && PlayerPrefs.GetInt("gemiplayerİndex") != 3)
            {
                PlayerPrefs.SetInt("gemiplayerİndex", 3);
                PlayerPrefs.SetInt("yıldızSayısı1", PlayerPrefs.GetInt("yıldızSayısı1") - 1);
                yıldızSayısıText.text = PlayerPrefs.GetInt("yıldızSayısı1") + "";
                aSource[0].Play();
                //uGotIt.text = "YOU GOT IT";
                //Invoke("sil", 1f);
                Instantiate(ugotİt, new Vector3(0f, 0f, 0f), Quaternion.identity);
            }
            else
            {
                Instantiate(NoEnoughStars, new Vector3(0f, 0f, 0f), Quaternion.identity);
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("yıldızSayısı1") >= 1)
            {
                PlayerPrefs.SetInt("gemiplayerİndex", 3);
                PlayerPrefs.SetInt("yıldızSayısı1", PlayerPrefs.GetInt("yıldızSayısı1") - 1);
                yıldızSayısıText.text = PlayerPrefs.GetInt("yıldızSayısı1") + "";
                aSource[0].Play();
                //uGotIt.text = "YOU GOT IT";
                //Invoke("sil", 1f);
                Instantiate(ugotİt, new Vector3(0f, 0f, 0f), Quaternion.identity);
            }
            else
            {
                Instantiate(NoEnoughStars, new Vector3(0f, 0f, 0f), Quaternion.identity);
            }

        }
    }
    public void gemi4seçimi()
    {
        if (PlayerPrefs.HasKey("gemiplayerİndex"))
        {
            if (PlayerPrefs.GetInt("yıldızSayısı1") >= 1 && PlayerPrefs.GetInt("gemiplayerİndex") != 4)
            {
                PlayerPrefs.SetInt("gemiplayerİndex", 4);
                PlayerPrefs.SetInt("yıldızSayısı1", PlayerPrefs.GetInt("yıldızSayısı1") - 1);
                yıldızSayısıText.text = PlayerPrefs.GetInt("yıldızSayısı1") + "";
                aSource[0].Play();
                //uGotIt.text = "YOU GOT IT";
                //Invoke("sil", 1f);
                Instantiate(ugotİt, new Vector3(0f, 0f, 0f), Quaternion.identity);
            }
            else
            {
                Instantiate(NoEnoughStars, new Vector3(0f, 0f, 0f), Quaternion.identity);
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("yıldızSayısı1") >= 1)
            {
                PlayerPrefs.SetInt("gemiplayerİndex", 4);
                PlayerPrefs.SetInt("yıldızSayısı1", PlayerPrefs.GetInt("yıldızSayısı1") - 1);
                yıldızSayısıText.text = PlayerPrefs.GetInt("yıldızSayısı1") + "";
                aSource[0].Play();
                //uGotIt.text = "YOU GOT IT";
                //Invoke("sil", 1f);
                Instantiate(ugotİt, new Vector3(0f, 0f, 0f), Quaternion.identity);
            }
            else
            {
                Instantiate(NoEnoughStars, new Vector3(0f, 0f, 0f), Quaternion.identity);
            }

        }
    }
    public void gemi5seçimi()
    {
        if (PlayerPrefs.HasKey("gemiplayerİndex"))
        {
            if (PlayerPrefs.GetInt("yıldızSayısı1") >= 1 && PlayerPrefs.GetInt("gemiplayerİndex") != 5)
            {
                PlayerPrefs.SetInt("gemiplayerİndex", 5);
                PlayerPrefs.SetInt("yıldızSayısı1", PlayerPrefs.GetInt("yıldızSayısı1") - 1);
                yıldızSayısıText.text = PlayerPrefs.GetInt("yıldızSayısı1") + "";
                aSource[0].Play();
                //uGotIt.text = "YOU GOT IT";
                //Invoke("sil", 1f);
                Instantiate(ugotİt, new Vector3(0f, 0f, 0f), Quaternion.identity);
            }
            else
            {
                Instantiate(NoEnoughStars, new Vector3(0f, 0f, 0f), Quaternion.identity);
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("yıldızSayısı1") >= 1)
            {
                PlayerPrefs.SetInt("gemiplayerİndex", 5);
                PlayerPrefs.SetInt("yıldızSayısı1", PlayerPrefs.GetInt("yıldızSayısı1") -1);
                yıldızSayısıText.text = PlayerPrefs.GetInt("yıldızSayısı1") + "";
                aSource[0].Play();
                //uGotIt.text = "YOU GOT IT";
                //Invoke("sil", 1f);
                Instantiate(ugotİt, new Vector3(0f, 0f, 0f), Quaternion.identity);
            }
            else
            {
                Instantiate(NoEnoughStars, new Vector3(0f, 0f, 0f), Quaternion.identity);
            }

        }
    }






    public void AnaMenüReturnButton()
    {
        SceneManager.LoadScene(0);
        aSource[0].Play();
    }
    void playButtonİnvoke()
    {
        SceneManager.LoadScene(1);
    }
    void shipButtotnİnvoke()
    {
        SceneManager.LoadScene(2);
    }
    public void başLwlYKLE()
    {
      

        SceneManager.LoadScene(13);
    }
     
    void infoykle()
    {
        SceneManager.LoadScene(45);
    }
    //void sil()
    //{
    //    uGotIt.text = "";
    //}
    void geçişReklamıGöster()
    {
        GameObject.FindGameObjectWithTag("reklam").GetComponent<REKLAM>().reklamıGöster();
    }
}
