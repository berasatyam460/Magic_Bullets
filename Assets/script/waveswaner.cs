using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveswaner : MonoBehaviour
{
    [System.Serializable]
    public class wave
    {
        public enemy[] enemy;
        public int count;
        public float timebtwspwan;

    }

    public wave[] waves;
    public Transform[] spwanpoints;
    public float timebtwwaves;
    bool finishedSpawaning;
    waveswaner. wave currentwave;
    int currentwaveIndex;
    Transform player;
  
    public GameObject boss;
    public Transform bosspoint;
    public GameObject healthbar;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(startNextWave(currentwaveIndex));
        
    }

   IEnumerator startNextWave(int index)
    {
        yield return new WaitForSeconds(timebtwwaves);
        StartCoroutine(SpawnWave(index));
        yield break;

    }

    private IEnumerator SpawnWave(int index)
    {
        this.currentwave = this.waves[index];
        
        for (int i = 0; i < this.currentwave.count; i++)
        {
            if (this.player == null)
            {
                yield break;
            }
            enemy randomEnemy = currentwave.enemy[Random.Range(0, currentwave.enemy.Length)];
            Transform randspot = spwanpoints[Random.Range(0, spwanpoints.Length)];
            Instantiate(randomEnemy, randspot.position, randspot.rotation);

            if (i == this.currentwave.count - 1)
            {
                this.finishedSpawaning = true;
            }
            else
            {
                this.finishedSpawaning = false;
            }
            yield return new WaitForSeconds(this.currentwave.timebtwspwan);
            
        }
        yield break;
    }
    private void Update()
    {
        if (this.finishedSpawaning && GameObject.FindGameObjectsWithTag("enemy").Length == 0)
        {
            this.finishedSpawaning = false;
            if (this.currentwaveIndex + 1 < this.waves.Length)
            {
                this.currentwaveIndex++;
                base.StartCoroutine(this.startNextWave(this.currentwaveIndex));
                return;
            }
            else
            {
                Object.Instantiate<GameObject>(this.boss, this.bosspoint.position, this.bosspoint.rotation);
              
                this.healthbar.SetActive(true);

            }
          
           //
        }
    }
}

    

