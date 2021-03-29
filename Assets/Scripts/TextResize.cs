using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextResize : MonoBehaviour
{
    RectTransform myRectTrans;

    void Start()
    {
        //Reanchor the UI elements so that they can resize their transforms.
        myRectTrans = GetComponent<RectTransform>();
        Vector2 anchorPos = Vector2.zero;
        anchorPos.x = myRectTrans.anchoredPosition.x / 1920;
        anchorPos.y = myRectTrans.anchoredPosition.y / 1080;
        myRectTrans.anchorMin = anchorPos;
        myRectTrans.anchorMax = anchorPos;
        myRectTrans.anchoredPosition = Vector2.zero;
    }
}
