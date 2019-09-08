using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension 
{
    // Start is called before the first frame update
    public static IEnumerator LerpToRotation(this Transform tr, Quaternion targetRotation, float time)
    {
        var originalTime = time;
        Debug.Log(targetRotation);
        while (time > 0.0f)
        {
            time -= Time.deltaTime;
            tr.rotation = Quaternion.Lerp(tr.rotation, targetRotation, 1 - (time / originalTime));
            yield return null;
        }

        yield break;

    }

}
