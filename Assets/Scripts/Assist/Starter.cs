using System.Collections;
using UnityEngine;

public abstract class Starter: MonoBehaviour
{
    public virtual IEnumerator Initialize()
    {
        yield break;
    }
}
