using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using static CalculateHelper;

public class GraphComponent : MonoBehaviour
{
    [Header("Require UILineRenderer Class")]
    [SerializeField]
    [Tooltip("Require! \nIf missing it then this class will not work!")]
    private UILineRenderer lineRendererComponent = null;

    [Header("Graph Values")]
    [SerializeField]
    [Tooltip("X numbers of graph")]
    private int graphValueNum = 10;

    [SerializeField]
    [Tooltip("Y Max value of graph \nIf Auto Calculate is enabled then ignore this value")]
    private float graphMinVal = 0;
    [SerializeField]
    [Tooltip("Y Min value of graph \nIf Auto Calculate is enabled then ignore this value")]
    private float graphMaxVal = 1;

    [Header("Graph Options")]
    [SerializeField]
    [Tooltip("Auto calculate Y Min/Max value")]
    private bool AutoCalculate = false;

    private List<float> values = new List<float>();
    private float[] sortedValues;
    private float[] actualValues;

    public void AddValue (float value)
    {
        values.Add(value);
    }

    private void Start ()
    {
        EventManager.inst.UpdateGraphs += UpdateGraph;

        UpdateGraph();
    }

    private void UpdateGraph ()
    {
        if (lineRendererComponent == null)
        {
            return;
        }

        SortValues();
        ReCalculateValues();

        if (sortedValues.Length == 0 || sortedValues.Length == 1)
        {
            lineRendererComponent.Points = new Vector2[1];
            lineRendererComponent.Points[0] = new Vector2(0,0);
        }
        else
        {
            lineRendererComponent.Points = new Vector2[sortedValues.Length];
            for (int i = 0; i < actualValues.Length; i++)
            {
                lineRendererComponent.Points[i] = new Vector2((1f / (sortedValues.Length - 1)) * i, actualValues[i]);
            }
        }
    }

    private void SortValues ()
    {
        int loopNum = Mathf.Min(values.Count, graphValueNum);
        sortedValues = new float[loopNum];

        for (int i = 0; i < loopNum; i++)
        {
            sortedValues[i] = values[values.Count - (loopNum - i)];
        }
    }

    private void ReCalculateValues ()
    {
        actualValues = new float[sortedValues.Length];
        for (int i = 0; i < sortedValues.Length; i++)
        {
            if (AutoCalculate)
            {
                actualValues[i] = CalculateHelper.Remap(sortedValues[i], values.Min(), values.Max(), 0, 1);
            }
            else
            {
                actualValues[i] = CalculateHelper.Remap(sortedValues[i], graphMinVal, graphMaxVal, 0, 1);
            }
        }
    }
}
