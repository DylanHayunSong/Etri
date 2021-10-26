using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SigletonBehaviour<T> : MonoBehaviour where T : SigletonBehaviour<T>
{
    public static T inst = null;
    protected virtual void Awake ()
    {
        if(inst != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            inst = (T)this;
            DontDestroyOnLoad(this.gameObject);
        } 
    }
}
