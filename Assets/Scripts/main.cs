using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class main : MonoBehaviour
{

    public GameObject prefabBlock;
    public Canvas canv;

    void Start()
    {
        //Instantiate(B, B.transform.position = new Vector3(куда тебе надо), 0), Quaternion.identity) as GameObject;
        //А.transform.SetParent(С.transform, false);

        for (int i = 0; i < 24; i++)
        {
            GameObject block = Instantiate(prefabBlock, prefabBlock.transform.position = new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            block.transform.SetParent(canv.transform, false);
        }


    }


    public void exit()
    {
        Application.Quit();
    }

    public void reset()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
