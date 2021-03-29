using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RangeLimiter : MonoBehaviour
{
    private TMP_InputField m_InputField;
    void Start()
    {
        m_InputField = this.gameObject.GetComponent<TMP_InputField>();
    }

    void Update()
    {
        //Limit the properties from 1-20.
        if(m_InputField.text != "")
        {
            if (int.Parse(m_InputField.text) > 20)
                m_InputField.text = 20.ToString();
            else if (int.Parse(m_InputField.text) < 1)
                m_InputField.text = 1.ToString();
        }
    }
}
