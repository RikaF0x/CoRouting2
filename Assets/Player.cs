using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Player : MonoBehaviour
{
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color abilityColor;
    private Image spriteRenderer;
    [SerializeField] private float jumpTime;
    [SerializeField] private float jumpForce;
    [SerializeField] private float scaleTime;
    [SerializeField] private float scaleNum;
    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<Image>();
    }

    public void ColorAbility()
    {
        spriteRenderer.color = abilityColor;
    }

    public void ColorDefault()
    {
        spriteRenderer.color = defaultColor;
    }

    public void UseJump()
    {
        StartCoroutine(Jump());
    }

    public void UseScale()
    {
        StartCoroutine(Scale());
    }

    private IEnumerator Jump()
    {
        Vector3 pos = gameObject.transform.position;
        for (float i = 0; i <= jumpTime; i += Time.deltaTime)
        {
            gameObject.transform.position = pos + new Vector3(0, i/jumpTime*jumpForce, 0);
            yield return null;
        }
        
        for (float i = jumpTime; i >= 0; i -= Time.deltaTime)
        {
            gameObject.transform.position = pos + new Vector3(0, i/jumpTime*jumpForce, 0);
            yield return null;
        }
    }

    private IEnumerator Scale()
    {
        Vector3 scale = gameObject.transform.localScale;
        for (float i = 0; i <= scaleTime; i += Time.deltaTime)
        {
            gameObject.transform.localScale = scale + new Vector3(i/scaleTime*scaleNum, i/scaleTime*scaleNum, 0);
            yield return null;
        }
        
        for (float i = scaleTime; i >= 0; i -= Time.deltaTime)
        {
            gameObject.transform.localScale = scale + new Vector3(i/scaleTime*scaleNum, i/scaleTime*scaleNum, 0);
            yield return null;
        }
    }
}
