using System;
using UnityEngine;

public class GraphManager : SigletonBehaviour<GraphManager>
{
    [SerializeField]
    private GraphComponent[] graphs = null;
    [SerializeField]
    private bool AutoUpdateGraphValues = false;

    private void Start ()
    {

        EventManager.inst.AddGraphValue += OnGraphValueAdded;

    }

    private void OnGraphValueAdded (int graphID, float value)
    {
        try
        {
            graphs[graphID].AddValue(value);
        }
        catch (IndexOutOfRangeException ie)
        {

        }
        if (AutoUpdateGraphValues)
        {
            EventManager.inst.UpdateGraphAction();
        }
    }
}
