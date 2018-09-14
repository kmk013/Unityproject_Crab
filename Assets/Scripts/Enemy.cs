using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {

    private Color spriteColor;
    private bool isFadeOutPlaying = false;

    public float hp;
    public List<GameObject> drop_items = new List<GameObject>();

    private void Start()
    {
        spriteColor = GetComponent<SpriteRenderer>().color;
    }

    public abstract void EnemyMotion();
    public bool CheckHpLeft() {
        if (hp <= 0)
            return false;
        else
            return true;
    }

    private void DieAnimationOn() {
        //GetComponent<Animator>().SetBool("isDie", true);
    }

    private void DropItems() {
        for (int i = 0; i < drop_items.Count; i++) {
            
        }
    }

    private void EnemyFadeOutStart() {
        if (isFadeOutPlaying)
            return;

        StartCoroutine(EnemyFadeOut());
    }

    private IEnumerator EnemyFadeOut() {
        isFadeOutPlaying = true;

        Color color = spriteColor;
        float time = 0f;
        color.a = Mathf.Lerp(0, 1, time);

        while(color.a < 1f) {
            time += Time.deltaTime / 1.5f;
            color.a = Mathf.Lerp(0, 1, time);
            spriteColor = color;

            yield return null;
        }

        isFadeOutPlaying = false;
    }
}
