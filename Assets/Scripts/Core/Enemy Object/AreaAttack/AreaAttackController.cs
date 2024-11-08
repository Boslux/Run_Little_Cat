using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaAttackController : MonoBehaviour
{
    public GameObject areaAttack;
    void Start()
    {
        StartCoroutine(StartAttack());
    }
    IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(2);
        Instantiate(areaAttack, transform.position, Quaternion.identity);
        
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
