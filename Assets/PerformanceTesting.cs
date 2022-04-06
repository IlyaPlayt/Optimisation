using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceTesting : MonoBehaviour
{
    const int numberOfTests = 5000;
    Sample test;
    private const string str = "sample";


    void PerformGetComponentGener()
    {
        for (int i = 0; i < numberOfTests; i++)
        {
            test = GetComponent<Sample>();
        }
    }

    void PerformGetComponentStr()
    {
        for (int i = 0; i < numberOfTests; i++)
        {
            test = (Sample) GetComponent(str);
        }
    }

    void PerformGetComponentType()
    {
        for (int i = 0; i < numberOfTests; i++)
        {
            test = (Sample) GetComponent(typeof(Sample));
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PerformGetComponentGener();
            PerformGetComponentStr();
            PerformGetComponentType();
        }
    }
}
