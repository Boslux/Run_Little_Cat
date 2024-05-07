using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [Header("Compenent")]
    public GameObject[] spawnObject; //objeler
    
    [Header("Value")]
    public float spawmnTime; // spawn zamanı
    //public float fixedSpawmTime; // spawn time çarpanı
    public float degreaseTime; // ne kadar hızlanacak
    private bool canSpawn=true; // spawn için bi kontrol
    public Vector3 spawnRadius; // spawn alanı 
    private float countDown=15; // geri sayım
    private bool isCountingDown=true; // geri sayım yapabilir mi
    void Update()
    {
        Call();
        UpdateSpawnTime();
        CheckSpawnTime();
    }
    // Spawn zamanını güncelleyen ve zamanın azalması durumunda zamanı azaltan fonksiyonlar
    void UpdateSpawnTime() 
    {
        // Eğer sayma işlemi yapılıyorsa ve countDown sıfırdan büyükse
        if (isCountingDown && countDown > 0)
        {
            // Zamanı azalt
            countDown -= Time.deltaTime;
            // Zaman sıfırsa spawn zamanını azalt
            if (countDown <= 0)
            {
                DegreareSpawnTime(degreaseTime);
                Debug.Log("hızlandı");
            }
        }
    }

    // Spawn zamanını kontrol eden ve eğer spawn zamanı belirli bir değere ulaşırsa saymayı durduran fonksiyon
    void CheckSpawnTime()
    {
        // Eğer spawn zamanı belirli bir değere ulaştıysa
        if (spawmnTime <= 0.6f)
        {
            // Saymayı durdur
            isCountingDown = false;
        }
    }
    // Geri sayım 0 olduğunda spawn time azaltan fonksiyon
    void DegreareSpawnTime(float time)
    {
        spawmnTime-=time;;
    }

    void Call()
    {
        if(canSpawn)
        {
        Invoke("SpawnRandomObject",spawmnTime);
        canSpawn=false;
        }
    }

    void SpawnRandomObject()
    {
         Vector3 spawnPosition = transform.position + new Vector3
         (
            Random.Range(-spawnRadius.x, spawnRadius.x),
            Random.Range(-spawnRadius.y, spawnRadius.y),
            Random.Range(-spawnRadius.z, spawnRadius.z)
        );
        GameObject objects=spawnObject[Random.Range(0,spawnObject.Length)];
        Instantiate(objects,spawnPosition, Quaternion.identity);
        canSpawn=true;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, spawnRadius);
    }
}
