using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Effect : MonoBehaviour

{
    public GameObject vfxPrefab; // Drag your VFX prefab to this field in the Inspector
    private GameObject currentVFX;
    private Coroutine vfxCoroutine;

    void Start()
    {
        // Instantiate the VFX prefab but keep it inactive initially
        currentVFX = Instantiate(vfxPrefab);
        currentVFX.SetActive(false);
    }


    public void ShowVFX()
    {
        if (currentVFX != null)
        {
            currentVFX.SetActive(true); // Activate the VFX prefab

            // Start a coroutine to deactivate VFX after 2 seconds
            if (vfxCoroutine != null)
            {
                StopCoroutine(vfxCoroutine);
            }
            vfxCoroutine = StartCoroutine(DeactivateVFXAfterDelay(2f));
        }
        else
        {
            Debug.LogError("VFX prefab is not assigned!");
        }
    }


    private IEnumerator DeactivateVFXAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (currentVFX != null)
        {
            currentVFX.SetActive(false); // Deactivate the VFX prefab
        }
    }


    public void HideVFX()
    {
        if (currentVFX != null)
        {
            currentVFX.SetActive(false); // Deactivate the VFX prefab
        }
    }
}
