using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HPSPGenerator : MonoBehaviour
{
    private TMP_InputField toughness;
    private TMP_InputField IQ;
    private TMP_InputField HP;
    private TMP_InputField SP;
    void Start()
    {
        toughness = GameObject.Find("Toughness").GetComponent<TMP_InputField>();
        IQ = GameObject.Find("IQ").GetComponent<TMP_InputField>();
        HP = GameObject.Find("HP").GetComponent<TMP_InputField>();
        SP = GameObject.Find("SP").GetComponent<TMP_InputField>();
    }

    void Update()
    {
        
    }

    //While finish entering toughness, calculate hp.
    public void changeHP()
    {
        int tough;
        if (toughness.text != "")
        {
            tough = int.Parse(toughness.text);
            HP.text = (tough * 2).ToString();
        }
        else
            HP.text = "";
    }

    //While finish entering IQ, calculate sp.
    public void changeSP()
    {
        int cons;
        if (IQ.text != "")
        {
            cons = int.Parse(toughness.text);
            SP.text = (cons * 2).ToString();
        }
        else
            SP.text = "";
    }
}
