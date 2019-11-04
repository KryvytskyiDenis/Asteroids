using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundariesController : MonoBehaviour
{
    public void CheckBoundaries(in Vector2 pos, out Vector2 newPos, in Vector2 objTransformPos, in float boundariesRadius)
    {
        newPos = objTransformPos;

        // Do vertical bounds
        if (pos.y - boundariesRadius > Camera.main.orthographicSize)
        {
            newPos.y = -Camera.main.orthographicSize;
        }
        if (pos.y + boundariesRadius < -Camera.main.orthographicSize)
        {
            newPos.y = Camera.main.orthographicSize;
        }

        // Calculate the orthographic width based on the screen ration
        float screenRation = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRation;

        // Do horizontal bounds
        if (pos.x - boundariesRadius > widthOrtho)
        {
            newPos.x = -widthOrtho;
        }
        if (pos.x + boundariesRadius < -widthOrtho)
        {
            newPos.x = widthOrtho;
        }
    }
}
