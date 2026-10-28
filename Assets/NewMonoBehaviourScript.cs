using System.Collections;
using Unity.U2D.Physics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] Button _button;
    [SerializeField] private float delay;
    [SerializeField] private UnityEvent startCallback;
    [SerializeField] private UnityEvent endCallback;
    private float _time;

    private void Awake()
    {
        _button.onClick.AddListener(UseAbility);
    }

    private void UseAbility()
    {
        StartCoroutine(AbilityEn());
    }
    private IEnumerator AbilityEn()
    {
        _button.interactable = false;
        startCallback?.Invoke();
        yield return new WaitForSeconds(delay);
        endCallback?.Invoke();
        _button.interactable = true;
        
    }
    
}
