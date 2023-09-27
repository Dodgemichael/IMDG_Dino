using UnityEngine;
public class MeteorAni: MonoBehaviour{

    public Sprite[] sprites;

    private SpriteRenderer spriteRenderer;
    private int frame;
    private void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnEnable(){
        Invoke(nameof(AnimateM),0f);
    }
    
    private void OnDisable()
    {
        CancelInvoke();
    }
    private void AnimateM()
    {
        frame++;
        if(frame >= sprites.Length){
            frame = 0;
        }

        if (frame>= 0 && frame < sprites.Length){
            spriteRenderer.sprite = sprites[frame];
        }

        Invoke(nameof(AnimateM), 2f / GameManager.Instance.gameSpeed);
    }
}