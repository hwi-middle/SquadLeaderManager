using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomBarCanvasController : MonoBehaviour
{
    public Image[] icons;
    public Canvas homeCanvas;
    public Canvas[] accountCanvas;
    public Canvas[] squadCanvas;
    public Canvas[] settitngsCanvas;

    private int curIdx = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBottonBtnClick(string type)
    {
        switch (type)
        {
            case "Home":
                icons[curIdx].color = new Color(217.0f / 255.0f, 217.0f / 255.0f, 217.0f / 255.0f);
                icons[0].color = new Color(0 / 255.0f, 112 / 255.0f, 192 / 255.0f);
                foreach (var item in accountCanvas)
                {
                    item.enabled = false;
                }

                foreach (var item in squadCanvas)
                {
                    item.enabled = false;
                }

                //foreach (var item in settitngsCanvas)
                //{
                //    item.enabled = false;
                //}
                homeCanvas.enabled = true;
                curIdx = 0;
                break;
            case "Account":
                icons[curIdx].color = new Color(217.0f / 255.0f, 217.0f / 255.0f, 217.0f / 255.0f);
                icons[1].color = new Color(0 / 255.0f, 112 / 255.0f, 192 / 255.0f);
                homeCanvas.enabled = false;
                foreach (var item in squadCanvas)
                {
                    item.enabled = false;
                }

                foreach (var item in settitngsCanvas)
                {
                    item.enabled = false;
                }
                accountCanvas[0].enabled = true;
                curIdx = 1;
                break;
            case "Squad":
                icons[curIdx].color = new Color(217.0f / 255.0f, 217.0f / 255.0f, 217.0f / 255.0f);
                icons[2].color = new Color(0 / 255.0f, 112 / 255.0f, 192 / 255.0f);
                homeCanvas.enabled = false;
                foreach (var item in accountCanvas)
                {
                    item.enabled = false;
                }

                foreach (var item in settitngsCanvas)
                {
                    item.enabled = false;
                }
                squadCanvas[0].enabled = true;
                curIdx = 2;
                break;
            case "Settings":
                icons[curIdx].color = new Color(217.0f / 255.0f, 217.0f / 255.0f, 217.0f / 255.0f);
                icons[3].color = new Color(0 / 255.0f, 112 / 255.0f, 192 / 255.0f);
                homeCanvas.enabled = false;
                foreach (var item in accountCanvas)
                {
                    item.enabled = false;
                }

                foreach (var item in squadCanvas)
                {
                    item.enabled = false;
                }
                accountCanvas[0].enabled = true;
                curIdx = 3;
                break;
        }
    }
}
