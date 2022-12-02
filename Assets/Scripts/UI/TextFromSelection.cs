using TMPro;
using UnityEngine;

public class TextFromSelection : MonoBehaviour
{
    public TMP_Text textItem;
    public TMP_Text textPressE;

    [SerializeField] private SelectionManager selectionManager;

    private void Start()
    {
        //selectionManager = GameObject.FindObjectOfType<SelectionManager>();
    }

    private void Update()
    {
        GameObject selection = selectionManager.selection?.gameObject;

        if (selection != null)
        {
            IInteractable interactable = selection.GetComponent<IInteractable>();

            if (interactable != null)
            {
                interactable.UI(textItem, textPressE);
            }

            if (interactable == null)
            {
                textItem.text = "";
                textPressE.gameObject.SetActive(false);
            }
        }

        if (selection == null)
        {
            textItem.text = "";
            textPressE.gameObject.SetActive(false);
        }
    }
}
