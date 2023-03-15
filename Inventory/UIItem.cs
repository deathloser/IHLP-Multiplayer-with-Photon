using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{

    public Item item;
    public Image spriteImage;
    public Text spriteText;

    // Start is called before the first frame update
    void Awake()
    {
        spriteImage = GetComponent<Image>();
        UpdateItem(null);

        
    }

    public void UpdateItem(Item item) {
        this.item = item;
        if(this.item != null) {
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
