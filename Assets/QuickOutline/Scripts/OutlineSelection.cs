using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OutlineSelection : MonoBehaviour
{
    private Transform highlight;
    private Transform selection;
    private RaycastHit raycastHit;
    private float maxDistance = 20f; // Maksimum mesafe

    void Update()
    {
        // Highlight
        if (highlight != null)
        {
            if (!IsObjectGrabbed(highlight))
            {
                highlight.gameObject.GetComponent<Outline>().enabled = false;
            }
            highlight = null;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit, maxDistance))
        {
            highlight = raycastHit.transform;
            if (highlight.CompareTag("Box") && highlight != selection)
            {
                if (!IsObjectGrabbed(highlight))
                {
                    if (highlight.gameObject.GetComponent<Outline>() != null)
                    {
                        highlight.gameObject.GetComponent<Outline>().enabled = true;
                    }
                    else
                    {
                        Outline outline = highlight.gameObject.AddComponent<Outline>();
                        outline.enabled = true;
                        outline.OutlineColor = Color.magenta;
                        outline.OutlineWidth = 7.0f;
                    }
                }
                else
                {
                    highlight.gameObject.GetComponent<Outline>().enabled = false;
                }
            }
            else
            {
                highlight = null;
            }
        }
    }

    private bool IsObjectGrabbed(Transform obj)
    {
        Grab grab = obj.GetComponent<Grab>();
        return grab != null && grab.isGrabbed;
    }
}
