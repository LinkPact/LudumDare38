using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.scripts.WorldObjects {
    public class PickupItem : MonoBehaviour {

        private TextDisplay story_controller;
        public string message = "template message";
        private Inventory inventory;
        public Item axe_item;

        void Start() {
            story_controller = GameObject.FindObjectOfType<TextDisplay>();
            inventory = GameObject.FindObjectOfType<Inventory>();
        }

        void OnMouseDown() {

            print("on mouse down ");
            print("Message: " + message);

            story_controller.ShowText(message, this.gameObject);
            inventory.AddItem(new Item(this.gameObject));
            Destroy(gameObject);
        }
    }
}
