using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.scripts.WorldObjects {
    public class PickupItem : MonoBehaviour {

        public string message = "template message";
        public Item axe_item;

        private TextDisplay story_controller;
        private Inventory inventory;
        private TextDisplay text_displayer;
        private CraftingSystem crafting_system;

        void Start() {
            story_controller = GameObject.FindObjectOfType<TextDisplay>();
            inventory = GameObject.FindObjectOfType<Inventory>();
            text_displayer = FindObjectOfType<TextDisplay>();
            crafting_system = FindObjectOfType<CraftingSystem>();
        }

        void OnMouseDown() {

            if (EventSystem.current.IsPointerOverGameObject()) {
                return;
            }

            if (!text_displayer.IsDisplaying() && !crafting_system.IsActive()) {
                story_controller.ShowText(message, this.gameObject);
            }

            if (!inventory.IsInventoryFull() && !text_displayer.IsDisplaying() && !crafting_system.IsActive()) {
                inventory.AddItem(new Item(this.gameObject));
                Destroy(gameObject);
            }
        }
    }
}
