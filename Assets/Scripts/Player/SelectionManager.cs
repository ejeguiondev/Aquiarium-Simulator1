using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public GameObject selection = null;
    public float rayDistance = 5f;

    private void Update()
    {
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, rayDistance);

        if(hit.collider != null)
        {
            selection = hit.collider.gameObject;    
        }

        if(hit.collider == null)
        {
            selection = null;
        }
    }
}