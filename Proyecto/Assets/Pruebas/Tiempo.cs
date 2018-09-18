using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tiempo : MonoBehaviour {
    public Text texto;
    private int time;
	// Use this for initialization
	void Start () {
        time = 0;
        StartCoroutine("Contar_tiempo");
	}

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Tiempo") == 1)
        {
            StopAllCoroutines();
        }
    }
    private IEnumerator Contar_tiempo()
    {
        while (time < 120)
        {
            yield return new WaitForSeconds(1);
            time++;
            if ((time % 60)<10)
            {
                texto.text = "Tiempo: " + time / 60 + ":0" + time % 60; 
            }
            else
            {
                texto.text = "Tiempo: " + time / 60 + ":" + time % 60;
            }
        }
        texto.text = "Se te acabó tu tiempo";
        yield return new WaitForSeconds(2);
        //Que vaya a otra escena

    }

    public void pararCorrutinia()
    {
        StopCoroutine("Contar_tiempo");
    }
}
