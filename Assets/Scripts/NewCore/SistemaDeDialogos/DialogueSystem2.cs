using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem2 : MonoBehaviour
    {
        public DialogueContainer2 dialogueContainer2 = new DialogueContainer2();

        public static DialogueSystem2 instance;

        private void Awake()
        {
            if(instance == null)
                instance = this;
            else
                DestroyImmediate(gameObject);
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
