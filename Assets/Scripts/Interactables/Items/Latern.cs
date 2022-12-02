using UnityEngine;

public class Latern : MonoBehaviour
{
    [SerializeField] private Light light;

    public void Toggle ()
    {
        light.enabled = !light.enabled;
    }
}
