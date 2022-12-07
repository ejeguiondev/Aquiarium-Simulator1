using UnityEngine;

public class Inventory : MonoBehaviour
{
    //
    public Transform SecondItem;
    public GameObject[] arrayInventory;
    public GameObject currenItem;
    public int numberItem = 0; 
    public int numberSlots = 5; // Esto se puede saber con arrayInventory.Length

    private void Drop()
    {
        if (Input.GetKeyDown(KeyCode.Q) && SecondItem.childCount > 0)
        {
            if (currenItem != null)
            {
                // Novedad : ahora los objetos no necesitan ser destruidos antes de ser soltados

                for (int i = 0; i < arrayInventory.Length; i++)
                {
                    if(arrayInventory[i] == currenItem)
                    {
                        // Almacenar el objeto que ha de ser soltado
                        GameObject drop = (arrayInventory[i]);
                        Rigidbody dropRigidbody = drop.GetComponent<Rigidbody>();

                        // Desligamos al objeto que sera soltado de su padre
                        drop.transform.parent = null;
                        // Se activa el colisionador del objeto a soltar
                        drop.GetComponent<Collider>().enabled = true;
                        // Se permite la influencia de las fuerzas sobre el objeto
                        dropRigidbody.isKinematic = false;
                        // Aplicar fuerza
                        dropRigidbody.AddForce(10f * Camera.main.transform.forward, ForceMode.Impulse);

                        arrayInventory[i] = null;
                    }
                    
                }
            }

        }
    }

    private void Start ()
    {
        arrayInventory = new GameObject[5];
    }

    private void Update () 
    {
        Drop();
        orderInventory();

        for (int i = 0; i < 5; i++)
        {
            if (Input.GetKeyDown((i + 1).ToString()))
            {
                numberItem = i;
            }
        }

        for (int i = 0; i < arrayInventory.Length; i++)
        {
            if (arrayInventory[i] == arrayInventory[numberItem])
            {
                currenItem = arrayInventory[i];
            }
        }
    }

    // Codigo de ordenacion del inventario
    private void orderInventory()
    {
        for (int i = 0; i < SecondItem.childCount; i++)
        {
            if (SecondItem.GetChild(i).gameObject != currenItem)
            {
                SecondItem.GetChild(i).gameObject.SetActive(false);
            } else
            {
                SecondItem.GetChild(i).gameObject.SetActive(true);
            }

            if (arrayInventory[i] == null)
            {
                GameObject item = SecondItem.GetChild(i).gameObject;
                arrayInventory[i] = item;
            }

        }

        for (int i = 0; i < arrayInventory.Length; i++)
        {
            for (int j = i + 1; j < arrayInventory.Length; j++)
            {
                if (arrayInventory[i] == arrayInventory[j])
                    arrayInventory[j] = null;
            }
        }

    }
}
