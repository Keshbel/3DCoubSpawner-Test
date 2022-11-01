using TMPro;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public CubeSpawner cubeSpawner;

    public TMP_InputField xField;
    public TMP_InputField zField;
    public TMP_InputField speedField;
    public TMP_InputField timeSpawnField;

    private void Start()
    {
        if (xField != null)
            xField.onEndEdit.AddListener(SetXValue);
        
        if (zField != null)
            zField.onEndEdit.AddListener(SetZValue);
        
        if (speedField != null)
            speedField.onEndEdit.AddListener(SetSpeedValue);
        
        if (timeSpawnField != null)
            timeSpawnField.onEndEdit.AddListener(SetTimeValue);
    }

    private void SetXValue(string x)
    {
        if (cubeSpawner)
            cubeSpawner.x = float.Parse(x);
    }
    private void SetZValue(string z)
    {
        if (cubeSpawner)
            cubeSpawner.z = float.Parse(z);
    }
    private void SetSpeedValue(string speed)
    {
        if (cubeSpawner)
            cubeSpawner.speed = float.Parse(speed);
    }
    private void SetTimeValue(string time)
    {
        if (cubeSpawner)
            cubeSpawner.timeToNewSpawn = float.Parse(time);
    }
}
