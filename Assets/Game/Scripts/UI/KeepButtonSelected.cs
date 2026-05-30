using UnityEngine;
using UnityEngine.EventSystems;

public class KeepButtonSelected : MonoBehaviour
{
    [SerializeField] private GameObject defaultSelection;

    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(defaultSelection);
        }
    }
}