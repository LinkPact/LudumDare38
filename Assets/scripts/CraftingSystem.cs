using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSystem : MonoBehaviour {

    private CraftMenuToggleButton toggle_button;
    private GameObject crafting_options_menu_object;

    private bool is_craft_menu_currently_active;

	void Start () {
        toggle_button = GetComponent<CraftMenuToggleButton>();
        crafting_options_menu_object = GetComponentInChildren<CraftingOptions>().gameObject;

        is_craft_menu_currently_active = false;
        SetCraftMenuActive(is_craft_menu_currently_active);
	}
	
	void Update () {
		
	}

    public void ToggleCraftMenuOptions() {
        is_craft_menu_currently_active = !is_craft_menu_currently_active;
        SetCraftMenuActive(is_craft_menu_currently_active);
    }

    public void SetCraftMenuActive(bool is_active) {
        crafting_options_menu_object.SetActive(is_active);
    }

    public bool IsActive() {
        return crafting_options_menu_object.activeSelf;
    }
}
