using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : SigletonBehaviour<EventManager>
{
    public Action UpdateGraphs = null;
    public Action<int, float> AddGraphValue = null;

    public void UpdateGraphAction()
    {
        if(UpdateGraphs != null)
        {
            UpdateGraphs.Invoke();
        }
    }

    public void AddGraphValueAction(int graphID, float value)
    {
        if(AddGraphValue != null)
        {
            AddGraphValue.Invoke(graphID, value);
        }
    }

    public void AddGraphValueAction(int graphID, double value)
    {
        AddGraphValueAction(graphID, (float)value);
    }
}
