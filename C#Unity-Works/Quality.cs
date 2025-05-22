using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quality : MonoBehaviour {

    public void Low()
    {
        QualitySettings.SetQualityLevel(0);
    }
    public void Medium()
    {
        QualitySettings.SetQualityLevel(1);
    }
    public void Ultra()
    {
        QualitySettings.SetQualityLevel(2);
    }
}
