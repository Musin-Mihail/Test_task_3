using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Menu : MonoBehaviour
{
    public GameObject Level1;
    public GameObject Level2;
    public GameObject Level3;
    void Start()
    {
        if(File.Exists(Application.persistentDataPath  + @"/Level1"))
        {
            Level1.SetActive(true);
        }
        if(File.Exists(Application.persistentDataPath  + @"/Level2"))
        {
            Level2.SetActive(true);
        }
        if(File.Exists(Application.persistentDataPath  + @"/Level3"))
        {
            Level3.SetActive(true);
        }
    }
}
