using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingManager : MonoBehaviour
{
    [SerializeField]
    Material evilSkyboxMaterial;

    [SerializeField]
    Material goodSkyboxMaterial;

    [SerializeField]
    Material neutralSkyboxMaterial;

    Light light;

    // Start is called before the first frame update
    void Start()
    {
        MoralityManager.GetMoralityManager().SignalKarmaChanged += OnKarmaChanged;
        light = GetComponent<Light>();
        light.color = new Color(1, 1, 1);
        RenderSettings.skybox.SetColor("_Tint", light.color);
    }

    ~LightingManager()
    {
        MoralityManager.GetMoralityManager().SignalKarmaChanged -= OnKarmaChanged;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnKarmaChanged(object sender, float karma)
    {
        Vector3 neautralColor = new Vector3(1, 1, 1);
        Vector3 goodColor = new Vector3(0.13f, 1, 0.8f);
        Vector3 badColor = new Vector3(1, 0, 0);

        if (karma > 0)
        {
            Vector3 colour = Vector3.Lerp(neautralColor, goodColor, (karma - 10));
            light.color = new Color(colour.x, colour.y, colour.z);
        }   
        else if (karma < 0)
        {
            Debug.Log(((karma * -1)/10));
            Vector3 colour = Vector3.Lerp(neautralColor, badColor, ((karma * -1) / 10));
            light.color = new Color(colour.x, colour.y, colour.z);
        }
        else
        {
            light.color = new Color(neautralColor.x, neautralColor.y, neautralColor.z);
        }

        RenderSettings.skybox.SetColor("_Tint", light.color);
    }
}
