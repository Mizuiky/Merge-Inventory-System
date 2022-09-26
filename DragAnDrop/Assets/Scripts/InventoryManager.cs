using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class InventoryManager : MonoBehaviour
{ 
    [SerializeField]
    private float _delayBetweenItens;
    [SerializeField]
    private List<GameObject> _slots;

    [Header("Slot Animation Settings")]

    [SerializeField]
    private float _scaleDuration;
    [SerializeField]
    private Ease _ease;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(ShowItems());
        }
        else if(Input.GetKeyDown(KeyCode.H))
        {
            StartCoroutine(HideItems());
        }
    }

    private IEnumerator ShowItems()
    {
        foreach(GameObject slot in _slots)
        {
            slot.gameObject.SetActive(true);
            slot.transform.DOScale(0, _scaleDuration).From().SetEase(_ease);

            yield return new WaitForSeconds(_delayBetweenItens);
        }
    }

    private IEnumerator HideItems()
    {
        foreach (GameObject slot in _slots)
        {
            slot.gameObject.SetActive(false);
            yield return new WaitForSeconds(_delayBetweenItens);
        }
    }
}
