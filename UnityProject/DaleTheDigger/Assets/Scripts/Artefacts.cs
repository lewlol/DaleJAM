using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Artefacts : MonoBehaviour
{
    //Artefact Level UI
    public Sprite locked;
    public Sprite Level1;
    public Sprite Level2;
    public Sprite Level3;
    public Sprite Level4;
    public Sprite Level5;



    //Artefact1 Stamina decrease
    public static string Artefact1;
    public static int Artefact1Level = 0;
    public GameObject Artefact1Sprite;
    public Image ArtefactLevelIcon1;
    public static float staminachance = 1;


    //Artefact2 Lower Shop Price
    public static string Artefact2;
    public static int Artefact2Level = 0;
    public GameObject Artefact2Sprite;
    public Image ArtefactLevelIcon2;
    public static float shopdiscount = 0f;

    //Artefact3 Mining Range
    public static string Artefact3;
    public static int Artefact3Level = 0;
    public GameObject Artefact3Sprite;
    public Image ArtefactLevelIcon3;
    public static float miningrange = 2f;

    //Artefact4 Mining Speed
    public static string Artefact4;
    public static int Artefact4Level = 0;
    public GameObject Artefact4Sprite;
    public Image ArtefactLevelIcon4;



    // Start is called before the first frame update
    void Start()
    {
        Artefact1Level = 0;
        Artefact2Level = 0;
        Artefact3Level = 0;
        Artefact4Level = 0;
        Artefact1Sprite.SetActive(false);
        Artefact2Sprite.SetActive(false);
        Artefact3Sprite.SetActive(false);
        Artefact4Sprite.SetActive(false);
        staminachance = 1;
        miningrange = 2f;
        shopdiscount = 0f


    }

    // Update is called once per frame
    void Update()
    {
        Artefact1Logic();
        Artefact2Logic();
        Artefact3Logic();
        Artefact4Logic();
    }

    public void Artefact1Logic()
    {
        if (Artefact1Level == 0)
        {
           // Artefact1Sprite.SetActive(false);
           // ArtefactLevelIcon1.sprite = locked;
            staminachance = 1;


        }
        else if (Artefact1Level == 1)
        {
          //  Artefact1Sprite.SetActive(true);
          //  ArtefactLevelIcon1.sprite = Level1;
            staminachance = 0.9f;
        }
        else if(Artefact1Level == 2)
        {
           // Artefact1Sprite.SetActive(true);
           // ArtefactLevelIcon1.sprite = Level2;
            staminachance = 0.8f;
        }
        else if(Artefact1Level == 3)
        {
          //  Artefact1Sprite.SetActive(true);
          //  ArtefactLevelIcon1.sprite = Level3;
            staminachance = 0.7f;

        }
        else if(Artefact1Level == 4)
        {
          //  Artefact1Sprite.SetActive(true);
           // ArtefactLevelIcon1.sprite = Level4;
            staminachance = 0.6f;
        }
        else if(Artefact1Level == 5)
        {
           // Artefact1Sprite.SetActive(true);
          //  ArtefactLevelIcon1.sprite = Level5;
            staminachance = 0.5f;
        }
        else
        {
            Debug.Log("SOmethings Broke");
        }
    }
    public void Artefact2Logic()
    {
        if (Artefact2Level == 0)
        {
            //  Artefact2Sprite.SetActive(false);
            //   ArtefactLevelIcon2.sprite = locked;
            shopdiscount = 0f;
        }
        else if (Artefact2Level == 1)
        {
            // Artefact2Sprite.SetActive(true);
            //  ArtefactLevelIcon2.sprite = Level1;
            shopdiscount = 0.1f;
        }
        else if (Artefact2Level == 2)
        {
            // Artefact2Sprite.SetActive(true);
            //  ArtefactLevelIcon2.sprite = Level2;
            shopdiscount = 0.15f;
        }
        else if (Artefact2Level == 3)
        {
            // Artefact2Sprite.SetActive(true);
            //  ArtefactLevelIcon2.sprite = Level3;
            shopdiscount = 0.2f;
          
        }
        else if (Artefact2Level == 4)
        {
            // Artefact2Sprite.SetActive(true);
            // ArtefactLevelIcon2.sprite = Level4;
            shopdiscount = 0.25f;
        }
        else if (Artefact2Level == 5)
        {
            // Artefact2Sprite.SetActive(true);
            // ArtefactLevelIcon2.sprite = Level5;
            shopdiscount = 0.3f;
        }
        else
        {
            Debug.Log("SOmethings Broke");
        }
    }
    public void Artefact3Logic()
    {
        if (Artefact3Level == 0)
        {
            //  Artefact3Sprite.SetActive(false);
            //   ArtefactLevelIcon3.sprite = locked;
            miningrange = 2f;
        }
        else if (Artefact3Level == 1)
        {
            // Artefact3Sprite.SetActive(true);
            // ArtefactLevelIcon3.sprite = Level1;
            miningrange = 2.5f;
        }
        else if (Artefact3Level == 2)
        {
            // Artefact3Sprite.SetActive(true);
            // ArtefactLevelIcon3.sprite = Level2;
            miningrange = 3f;
        }
        else if (Artefact3Level == 3)
        {
            // Artefact3Sprite.SetActive(true);
            // ArtefactLevelIcon3.sprite = Level3;
            miningrange = 3.5f;
        }
        else if (Artefact3Level == 4)
        {
            //  Artefact3Sprite.SetActive(true);
            // ArtefactLevelIcon3.sprite = Level4;
            miningrange = 4f;
        }
        else if (Artefact3Level == 5)
        {
            //  Artefact3Sprite.SetActive(true);
            // ArtefactLevelIcon3.sprite = Level5;
            miningrange = 5f;
        }
        else
        {
            Debug.Log("SOmethings Broke");
        }
    }
    public void Artefact4Logic()
    {
        if (Artefact4Level == 0)
        {
           // Artefact4Sprite.SetActive(false);
           // ArtefactLevelIcon4.sprite = locked;
        }
        else if (Artefact4Level == 1)
        {
          //  Artefact4Sprite.SetActive(true);
           // ArtefactLevelIcon4.sprite = Level1;
        }
        else if (Artefact4Level == 2)
        {
           // Artefact4Sprite.SetActive(true);
           // ArtefactLevelIcon4.sprite = Level2;
        }
        else if (Artefact4Level == 3)
        {
          //  Artefact4Sprite.SetActive(true);
          //  ArtefactLevelIcon4.sprite = Level3;
        }
        else if (Artefact4Level == 4)
        {
           // Artefact4Sprite.SetActive(true);
           // ArtefactLevelIcon4.sprite = Level4;
        }
        else if (Artefact4Level == 5)
        {
           // Artefact4Sprite.SetActive(true);
           // ArtefactLevelIcon4.sprite = Level5;
        }
        else
        {
            Debug.Log("SOmethings Broke");
        }
    }

    public static void Artefact1Upgrade()
    {
        if(Artefact1Level < 5)
        {
            Artefact1Level++;
        }
        else
        {
            Debug.Log("Artefact max level");
        }
       
    }
    public static void Artefact2Upgrade()
    {
        if (Artefact2Level < 5)
        {
            Artefact2Level++;
        }
        else
        {
            Debug.Log("Artefact max level");
        }
    }
    public static void Artefact3Upgrade()
    {
        if (Artefact3Level < 5)
        {
            Artefact3Level++;
        }
        else
        {
            Debug.Log("Artefact max level");
        }
    }
    public static void Artefact4Upgrade()
    {
        if (Artefact4Level < 5)
        {
            Artefact4Level++;
        }
        else
        {
            Debug.Log("Artefact max level");
        }
    }


}
