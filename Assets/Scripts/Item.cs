using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public int score;
    public List<int> changeTime = new List<int>();
    public List<int> changeScore = new List<int>();

    private SpriteRenderer renderer;
    private Sprite sprite;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        sprite = renderer.sprite;

        if (changeTime.Count == 0 || changeScore.Count == 0 || changeTime.Count != changeScore.Count) StartCoroutine(ItemDestroy());
        else StartCoroutine(ItemChanging());
    }

    private IEnumerator ItemChanging()
    {
        for(int i = changeScore.Count - 1; i >= 0; i--)
        {
            yield return new WaitForSeconds(changeTime[i]);
            score -= changeScore[i];
            //애니메이션
        }
    }

    private IEnumerator ItemDestroy()
    {
        Color color;
        for (float i = 0; i <= 6; i++)
        {
            color = renderer.color;
            color.a = 0;
            renderer.color = color;
            yield return new WaitForSeconds(0.25f);
            color.a = 1;
            renderer.color = color;
            yield return new WaitForSeconds(0.25f);
        }
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name.Equals("Player"))
        {
            GameManager.Instance.score += score;
            Destroy(this.gameObject);
        }
    }
}
