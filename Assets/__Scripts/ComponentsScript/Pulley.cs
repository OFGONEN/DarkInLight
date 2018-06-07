using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulley : MonoBehaviour {

    
    public PlatformMovement platform1;
    public PlatformMovement platform2;

    private bool flag = false;

    public bool platform1Below;
    public float rateOfMethod;

    private void Start()
    {
        InvokeRepeating("Toogle" , 2f , rateOfMethod);
    }
    void Toogle()
    {
        if (platform1Below)  
            Platform1Below();
        else
            Platform2Below();
       
    }

    void Platform1Below()
    {
        if (!flag)
        {
            platform2.Close();
            platform1.Open();
            flag = !flag;
        }
        else
        {
            platform2.Open();
            platform1.Close();
            flag = !flag;
        }
    }

    void Platform2Below()
    {
        if (!flag)
        {
            platform2.Open();
            platform1.Close();
            flag = !flag;
        }
        else
        {
            platform2.Close();
            platform1.Open();
            flag = !flag;
        }
    }
}
