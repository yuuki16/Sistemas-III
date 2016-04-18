using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BrightnessControl : MonoBehaviour 
{
    public Light lightIntensity;
    public Slider slBright;

    float lightLevel;
	// Use this for initialization
	void Start () 
	{
        slBright = GetComponent<Slider>();
        if (PlayerPrefs.HasKey("CurrBright"))
        {
            lightLevel = PlayerPrefs.GetFloat("CurrBright");
        }
        else
        {
            lightLevel = 8.0f;
        }
        slBright.value = lightLevel;
	}
	
	public void setBrightness()
    {
        lightLevel = slBright.value;
        Debug.Log(lightLevel);
        lightIntensity.intensity = lightLevel;
        PlayerPrefs.SetFloat("CurrBright", lightLevel);
    }
}
