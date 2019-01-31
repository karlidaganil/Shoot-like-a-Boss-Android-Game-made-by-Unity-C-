using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class REKLAM : MonoBehaviour
{
    private InterstitialAd interstitial;

    static REKLAM reklamKontrol;
    bool geçişGöster = true;
    bool gir = true;
    //void Awake()
    //{
    //    if(PlayerPrefs.HasKey("anaMenüAçılmaSayısı")==false)
    //    {
    //        PlayerPrefs.SetInt("anaMenüAçılmaSayısı", 1);
    //    }
    //    else
    //    {
    //        PlayerPrefs.SetInt("anaMenüAçılmaSayısı", PlayerPrefs.GetInt("anaMenüAçılmaSayısı")+1);
    //    }

    //}
    void Start()
    {
        if(reklamKontrol==null)
        {
            //DontDestroyOnLoad(gameObject);
            reklamKontrol = this;
            //1.AŞAMA--------------------------------------------------
        #if UNITY_ANDROID
                    string appId = "ca-app-pub-1904326235902390~9195202669";
        #elif UNITY_IPHONE
                        string appId = "ca-app-pub-3940256099942544~1458002511";
        #else
                        string appId = "unexpected_platform";
        #endif

            // Initialize the Google Mobile Ads SDK.
            MobileAds.Initialize(appId);

            //2.AŞAMA-----------------------------------------------------
        #if UNITY_ANDROID
                    string adUnitId = "ca-app-pub-1904326235902390/3765167618";
        #elif UNITY_IPHONE
                    string adUnitId = "ca-app-pub-3940256099942544/4411468910";
        #else
                    string adUnitId = "unexpected_platform";
        #endif

            // Initialize an InterstitialAd.
            this.interstitial = new InterstitialAd(adUnitId);

            //3.AŞAMA-----------------------------------------------
            //  AdRequest request = new AdRequest.Builder()
            //.AddTestDevice("2077ef9a63d2b398840261c8221a0c9b")
            //.Build();
            //  this.interstitial.LoadAd(request);

            AdRequest request = new AdRequest.Builder().Build();
            
            this.interstitial.LoadAd(request);

            //4.AŞAMA-----------------------------------------
        }
        else
        {
            Destroy(gameObject);
        }
   
    }

   
    void Update()
    {
      if(gir==true)
        {
            if(PlayerPrefs.GetInt("anaMenüSayısı")==0)
            {
                PlayerPrefs.SetInt("anaMenüSayısı", 1);
                gir = false;
            }
            else
            {
                PlayerPrefs.SetInt("anaMenüSayısı", PlayerPrefs.GetInt("anaMenüSayısı")+1);
                gir = false;
            }
        }
        


        if (Application.loadedLevel==0 && PlayerPrefs.GetInt("anaMenüSayısı") !=0 && PlayerPrefs.GetInt("anaMenüSayısı") %3==0)
        {
            if(geçişGöster==true)
            {
                if (this.interstitial.IsLoaded())
                {
                    this.interstitial.Show();
                    geçişGöster = false;
                    reklamKontrol = null;
                    Destroy(gameObject);
                }

            }
          
        }

   
     

        //if(Application.loadedLevel==3)
        //{

        //    if (PlayerPrefs.HasKey("anamenüAçılmaSayısı"))   //burayı kontrol et
        //    {
        //        PlayerPrefs.SetInt("anamenüAçılmaSayısı", PlayerPrefs.GetInt("anamenüAçılmaSayısı") + 1);
        //        if (PlayerPrefs.GetInt("anamenüAçılmaSayısı") %  == 0)
        //        {
        //            // GameObject.FindGameObjectWithTag("reklam").GetComponent<REKLAM>().reklamıGöster();
        //            reklamıGöster();
        //        }
        //    }
        //    else
        //    {
        //        PlayerPrefs.SetInt("anamenüAçılmaSayısı", 1);
        //    }
        //}
        //Debug.Log(PlayerPrefs.GetInt("anamenüAçılmaSayısı"));
    }

    public void reklamıGöster()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
            Debug.Log("reklamı gösterdim");
        }
        reklamKontrol = null;
        Destroy(gameObject);
    }
}
