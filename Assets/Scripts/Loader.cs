using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public List<Starter> InitilizationList;

    public IEnumerator Start()
    {
        foreach(var obj in InitilizationList)
        {
            yield return StartCoroutine(obj.Initialize());
            yield return null;
        }
    }
}
