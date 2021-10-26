using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphTester : MonoBehaviour
{
    private void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            AddGraphValue(0, Random.Range(0f, 1f));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AddGraphValue(1, Random.Range(-10f, 10f));
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            AddGraphValue(2, Random.Range(100f, 700f));
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            AddGraphValue(0, Random.Range(0f, 1f));
            AddGraphValue(1, Random.Range(-10f, 10f));
            AddGraphValue(2, Random.Range(100f, 700f));
        }
    }

    private void AddGraphValue (int graphID, float value)
    {
        EventManager.inst.AddGraphValueAction(graphID, value);
    }
}
