using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite gt;
    public Sprite uga;
    public Sprite df;

    public Button[] buttons;
    public Sprite[] spriteOrder;
    public Text nText;

    int ntimes;
    DateTime ctime;
    public float totalTime;
    void Start()
    {
        ntimes = 0;
 
        spriteOrder = new Sprite[4];
        for (int i = 0; i < spriteOrder.Length; i++) {
            spriteOrder[i] = uga;
        }
        spriteOrder[0] = gt;
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].image.sprite = df;
            buttons[i].enabled = false;
        }
        StartCoroutine(ExampleCoroutine());
    }

    public void Reshuffle(Button button) {
        ntimes++;
        nText.text = ntimes.ToString();
        TimeSpan dt = DateTime.Now - ctime;

        if (ntimes == 10) {
            nText.text = (totalTime / 10.0f).ToString();
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].image.sprite = df;
                buttons[i].enabled = false;
            }

        }

        float ts = dt.Milliseconds;
        Sprite t = button.image.sprite;
        totalTime += ts;
        Debug.Log(ntimes);
        if (t.name == gt.name) {
            
        }

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].image.sprite = df;
            buttons[i].enabled = false;
        }
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine() { 
        yield return new WaitForSeconds(2);
        for (int i = 0; i < spriteOrder.Length; i++)
        {
            int rnd = UnityEngine.Random.Range(0, spriteOrder.Length);
            Sprite tempGO = spriteOrder[rnd];
            spriteOrder[rnd] = spriteOrder[i];
            spriteOrder[i] = tempGO;
        }
        for (int i = 0; i < spriteOrder.Length; i++)
        {
            buttons[i].enabled = true;
            buttons[i].image.sprite = spriteOrder[i];
        }
        ctime = DateTime.Now;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
