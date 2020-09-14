using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthLayerFixer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("Earth_layer");
    }

}
