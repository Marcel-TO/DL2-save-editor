import logging
import os
import re
import shutil
import struct
import threading
from tkinter import ttk, filedialog, colorchooser, font, messagebox
from tkinterdnd2 import TkinterDnD, DND_FILES
import tkinter as tk
import customtkinter
import asyncio
import json
import time



customtkinter.set_appearance_mode("System")
customtkinter.set_default_color_theme("blue")

window = customtkinter.CTk()

dark_bg_color = "#2b2b2b"
dark_fg_color = "white"
dark_highlight_color = "#4f4f4f"
dark_entry_bg_color = "#383838"

window.configure(bg=dark_bg_color)
window.option_add("*Background", dark_bg_color)
window.option_add("*Foreground", dark_fg_color)
window.option_add("*HighlightColor", dark_highlight_color)
window.option_add("*EntryField.Background", dark_entry_bg_color)

style = ttk.Style()
style.configure("TLabel", background=dark_bg_color, foreground=dark_fg_color)
style.configure("TFrame", background=dark_bg_color)
style.configure("TButton", background=dark_highlight_color, foreground=dark_fg_color)
style.configure("TEntry", fieldbackground=dark_entry_bg_color)

window.geometry("800x510")
window.resizable(True, True)
window.title("Updated Editor DL2")

file_status_label = customtkinter.CTkLabel(window, text="No Save Opened", anchor="w")
file_status_label.grid(row=1, column=0, columnspan=2, sticky="we", padx=10, pady=5)

window.columnconfigure(0, weight=1)
window.rowconfigure(0, weight=1)

tabs = customtkinter.CTkTabview(window)

tabs.configure(
    corner_radius=20,
    text_color=('red', 'cyan')
)

skills_frame = tabs.add("Skills")
XP_frame = tabs.add("Experience")
inventory_frame = tabs.add("Inventory")
backpack_frame = tabs.add("Backpack")
campaign_frame = tabs.add("Campaign")
All_ID_frame = tabs.add("Bountys ???")

frame_skills = customtkinter.CTkFrame(skills_frame)
frame_skills.grid(row=0, column=0, sticky="nsew")

skills_frame.rowconfigure(0, weight=1)
skills_frame.columnconfigure(0, weight=1)

frame_skills.columnconfigure(0, weight=1)
frame_skills.rowconfigure(0, weight=1)

outer_tab_skills = customtkinter.CTkTabview(skills_frame)
outer_tab_skills.grid(row=0, column=0, sticky="news")

inner_tab_skills_1 = outer_tab_skills.add("Base Skills")

inner_tab_skills_1.columnconfigure(0, weight=1)
inner_tab_skills_1.rowconfigure(0, weight=1)

canvas_skills_1 = customtkinter.CTkScrollableFrame(inner_tab_skills_1)
canvas_skills_1.grid(row=0, column=0, sticky="news")

inner_tab_skills_2 = outer_tab_skills.add("Legend Skills")

inner_tab_skills_2.columnconfigure(0, weight=1)
inner_tab_skills_2.rowconfigure(0, weight=1)

canvas_skills_2 = customtkinter.CTkScrollableFrame(inner_tab_skills_2)
canvas_skills_2.grid(row=0, column=0, sticky="news")

frame_XP = customtkinter.CTkFrame(XP_frame)
frame_XP.grid(row=0, column=0, sticky="nsew")

XP_frame.rowconfigure(0, weight=1)
XP_frame.columnconfigure(0, weight=1)

frame_XP.columnconfigure(0, weight=1)
frame_XP.rowconfigure(0, weight=1)

outer_tab_XP = customtkinter.CTkTabview(XP_frame)
outer_tab_XP.grid(row=0, column=0, sticky="news")

inner_tab_XP_1 = outer_tab_XP.add("XP")

inner_tab_XP_1.columnconfigure(0, weight=1)
inner_tab_XP_1.rowconfigure(0, weight=1)

canvas_XP_1 = customtkinter.CTkScrollableFrame(inner_tab_XP_1)
canvas_XP_1.grid(row=0, column=0, sticky="news")

frame_inventory = customtkinter.CTkFrame(inventory_frame)
frame_inventory.grid(row=0, column=0, sticky="nsew")

inventory_frame.rowconfigure(0, weight=1)
inventory_frame.columnconfigure(0, weight=1)

frame_inventory.columnconfigure(0, weight=1)
frame_inventory.rowconfigure(0, weight=1)

outer_tab_inventory = customtkinter.CTkTabview(inventory_frame)
outer_tab_inventory.grid(row=0, column=0, sticky="news")

inner_tab_inventory_1 = outer_tab_inventory.add("Weapons")

inner_tab_inventory_1.columnconfigure(0, weight=1)
inner_tab_inventory_1.rowconfigure(0, weight=1)

canvas_inventory_1 = customtkinter.CTkScrollableFrame(inner_tab_inventory_1)
canvas_inventory_1.grid(row=0, column=0, sticky="news")

inner_tab_inventory_2 = outer_tab_inventory.add("Accessories")

inner_tab_inventory_2.columnconfigure(0, weight=1)
inner_tab_inventory_2.rowconfigure(0, weight=1)

canvas_inventory_2 = customtkinter.CTkScrollableFrame(inner_tab_inventory_2)
canvas_inventory_2.grid(row=0, column=0, sticky="news")

inner_tab_inventory_3 = outer_tab_inventory.add("Consumables")

inner_tab_inventory_3.columnconfigure(0, weight=1)
inner_tab_inventory_3.rowconfigure(0, weight=1)

canvas_inventory_3 = customtkinter.CTkScrollableFrame(inner_tab_inventory_3)
canvas_inventory_3.grid(row=0, column=0, sticky="news")

inner_tab_inventory_4 = outer_tab_inventory.add("Outfits")

inner_tab_inventory_4.columnconfigure(0, weight=1)
inner_tab_inventory_4.rowconfigure(0, weight=1)

canvas_inventory_4 = customtkinter.CTkScrollableFrame(inner_tab_inventory_4)
canvas_inventory_4.grid(row=0, column=0, sticky="news")

inner_tab_inventory_5 = outer_tab_inventory.add("Materials")

inner_tab_inventory_5.columnconfigure(0, weight=1)
inner_tab_inventory_5.rowconfigure(0, weight=1)

canvas_inventory_5 = customtkinter.CTkScrollableFrame(inner_tab_inventory_5)
canvas_inventory_5.grid(row=0, column=0, sticky="news")

inner_tab_inventory_6 = outer_tab_inventory.add("Valuables")

inner_tab_inventory_6.columnconfigure(0, weight=1)
inner_tab_inventory_6.rowconfigure(0, weight=1)

canvas_inventory_6 = customtkinter.CTkScrollableFrame(inner_tab_inventory_6)
canvas_inventory_6.grid(row=0, column=0, sticky="news")

inner_tab_inventory_7 = outer_tab_inventory.add("Ammo")

inner_tab_inventory_7.columnconfigure(0, weight=1)
inner_tab_inventory_7.rowconfigure(0, weight=1)

canvas_inventory_7 = customtkinter.CTkScrollableFrame(inner_tab_inventory_7)
canvas_inventory_7.grid(row=0, column=0, sticky="news")

inner_tab_inventory_8 = outer_tab_inventory.add("Bundles")

inner_tab_inventory_8.columnconfigure(0, weight=1)
inner_tab_inventory_8.rowconfigure(0, weight=1)

canvas_inventory_8 = customtkinter.CTkScrollableFrame(inner_tab_inventory_8)
canvas_inventory_8.grid(row=0, column=0, sticky="news")

frame_backpack = customtkinter.CTkFrame(backpack_frame)
frame_backpack.grid(row=0, column=0, sticky="nsew")

backpack_frame.rowconfigure(0, weight=1)
backpack_frame.columnconfigure(0, weight=1)

frame_backpack.columnconfigure(0, weight=1)
frame_backpack.rowconfigure(0, weight=1)

outer_tab_backpack = customtkinter.CTkTabview(backpack_frame)
outer_tab_backpack.grid(row=0, column=0, sticky="news")

inner_tab_backpack_1 = outer_tab_backpack.add("Weapons")

inner_tab_backpack_1.columnconfigure(0, weight=1)
inner_tab_backpack_1.rowconfigure(0, weight=1)

canvas_backpack_1 = customtkinter.CTkScrollableFrame(inner_tab_backpack_1)
canvas_backpack_1.grid(row=0, column=0, sticky="news")

inner_tab_backpack_2 = outer_tab_backpack.add("Accessories")

inner_tab_backpack_2.columnconfigure(0, weight=1)
inner_tab_backpack_2.rowconfigure(0, weight=1)

canvas_backpack_2 = customtkinter.CTkScrollableFrame(inner_tab_backpack_2)
canvas_backpack_2.grid(row=0, column=0, sticky="news")

inner_tab_backpack_3 = outer_tab_backpack.add("Consumables")

inner_tab_backpack_3.columnconfigure(0, weight=1)
inner_tab_backpack_3.rowconfigure(0, weight=1)

canvas_backpack_3 = customtkinter.CTkScrollableFrame(inner_tab_backpack_3)
canvas_backpack_3.grid(row=0, column=0, sticky="news")

inner_tab_backpack_4 = outer_tab_backpack.add("Outfits")

inner_tab_backpack_4.columnconfigure(0, weight=1)
inner_tab_backpack_4.rowconfigure(0, weight=1)

canvas_backpack_4 = customtkinter.CTkScrollableFrame(inner_tab_backpack_4)
canvas_backpack_4.grid(row=0, column=0, sticky="news")

inner_tab_backpack_5 = outer_tab_backpack.add("Materials")

inner_tab_backpack_5.columnconfigure(0, weight=1)
inner_tab_backpack_5.rowconfigure(0, weight=1)

canvas_backpack_5 = customtkinter.CTkScrollableFrame(inner_tab_backpack_5)
canvas_backpack_5.grid(row=0, column=0, sticky="news")

inner_tab_backpack_6 = outer_tab_backpack.add("Valuebles")

inner_tab_backpack_6.columnconfigure(0, weight=1)
inner_tab_backpack_6.rowconfigure(0, weight=1)

canvas_backpack_6 = customtkinter.CTkScrollableFrame(inner_tab_backpack_6)
canvas_backpack_6.grid(row=0, column=0, sticky="news")

inner_tab_backpack_7 = outer_tab_backpack.add("Ammo")

inner_tab_backpack_7.columnconfigure(0, weight=1)
inner_tab_backpack_7.rowconfigure(0, weight=1)

canvas_backpack_7 = customtkinter.CTkScrollableFrame(inner_tab_backpack_7)
canvas_backpack_7.grid(row=0, column=0, sticky="news")

inner_tab_backpack_8 = outer_tab_backpack.add("Bundles")

inner_tab_backpack_8.columnconfigure(0, weight=1)
inner_tab_backpack_8.rowconfigure(0, weight=1)

canvas_backpack_8 = customtkinter.CTkScrollableFrame(inner_tab_backpack_8)
canvas_backpack_8.grid(row=0, column=0, sticky="news")

tabs.grid(row=0, column=0, sticky="news")

# these are not used in the application itself yet although it may be implemented at some point for some things
# it is used for the Close_file dummy function as that's not implemented yet.
notification = tk.StringVar()
notification_label = ttk.Label(window, textvariable=notification)
notification_label.grid(row=5, column=0, padx=5, pady=5, sticky="w")


def remove_notification():
    notification.set("")
    notification_label.configure(textvariable=notification)


# Global variables
file_contents = None
file_path = None
backup_created = False
current_file = None

START_INVENTORY_VALUE = "51756573745F437562655F416374697665"
END_INVENTORY_VALUE = "5361766567616D653A3A446966666963756C74793A3A"


# this doesn't seem to be correct as its picking up some items still from the inventory.
# will need a new end value to ensure we only pick up items from the backpack !
START_BACKPACK_VALUE = "6D5F4974656D417070656172616E6365496455"
END_BACKPACK_VALUE = "51756573745F437562655F416374697665"

# Need a better method for this maybe using asynch again ...
# or call 1 function at a time print our keys then call next function

json_files = [
    os.path.join("Json", file) for file in ["skill_base.json", "legend_skill.json", "XP_values.json",
                                            "weapons_swap.json", "mod_swap.json", "accessories_swap.json",
                                            "consumable_swap.json", "OutfitPart.json", "CraftComponent.json",
                                            "Valuable.json"]
]


# update_lock = asyncio.Lock()


async def load_keys_for_file(file_path):
    with open(file_path, 'r') as f:
        return json.load(f)


async def process_keys(file_path, keys, key_dict):
    start_time = time.time()
    # Use the file_path argument instead of accessing it from the keys dictionary
    if file_path.endswith("skill_base.json"):
        key_dict['skill_base_keys'] = keys
    elif file_path.endswith("legend_skill.json"):
        key_dict['legend_skill_keys'] = keys
    elif file_path.endswith("XP_values.json"):
        key_dict['XP_value_keys'] = keys
    elif file_path.endswith("weapons_swap.json"):
        key_dict['weapon_swap_keys'] = keys
    elif file_path.endswith("mod_swap.json"):
        key_dict['mod_swap_keys'] = keys
    elif file_path.endswith("accessories_swap.json"):
        key_dict['accessorie_swap_keys'] = keys
    elif file_path.endswith("consumable_swap.json"):
        key_dict['consumable_swap_keys'] = keys
    elif file_path.endswith("OutfitPart.json"):
        key_dict['outfit_swap_keys'] = keys
    elif file_path.endswith("CraftComponent.json"):
        key_dict['material_swap_keys'] = keys
    elif file_path.endswith("Valuable.json"):
        key_dict['valuables_swap_keys'] = keys
    end_time = time.time()
    print(f"{file_path} keys took {end_time - start_time:.4f} seconds to process")


async def load_json_file_and_process(file_path, key_dict):
    start_time = time.time()
    keys = await load_keys_for_file(file_path)
    await asyncio.wait_for(process_keys(file_path, keys, key_dict), timeout=0.01)
    end_time = time.time()
    print(f"{file_path} took {end_time - start_time:.4f} seconds to process")


async def load_json_files():
    key_dict = {}
    tasks = []
    for json_file in json_files:
        task = asyncio.create_task(load_json_file_and_process(json_file, key_dict))
        tasks.append(task)
    await asyncio.gather(*tasks)
    return key_dict


def open_save():
    global file_path, current_file, file_contents, backup_created
    current_file = file_path

    file_path = filedialog.askopenfilename()
    if not file_path:
        messagebox.showerror("Error", "File not selected")
        return
    if current_file is not None and current_file == file_path:
        messagebox.showerror("Error", "File already open")
        return

    file_status_label.configure(text=f"Save Opened: {file_path}")
    file_status_label.update()

    if not backup_created:
        create_backup_dir(file_path)

        backup_dir = os.path.join(os.path.dirname(file_path), "Gamesave_Backup", os.path.basename(file_path))
        os.makedirs(backup_dir, exist_ok=True)
        shutil.copy2(file_path, os.path.join(backup_dir, os.path.basename(file_path)))

        backup_created = True

    try:
        loop = asyncio.get_event_loop()
        key_dict = loop.run_until_complete(load_json_files())

        with open(file_path, 'rb') as f:
            file_contents = bytearray(f.read())

        if key_dict.get('skill_base_keys'):
            handle_skill_base_keys(key_dict['skill_base_keys'])
        if key_dict.get('legend_skill_keys'):
            handle_legend_skill_keys(key_dict['legend_skill_keys'])
        if key_dict.get('XP_value_keys'):
            handle_XP_value_keys(key_dict['XP_value_keys'])
        if key_dict.get('weapon_swap_keys'):
            handle_weapon_swap_keys(key_dict['weapon_swap_keys'])
        if key_dict.get('accessorie_swap_keys'):
            handle_accessories_swap_keys(key_dict['accessorie_swap_keys'])
        if key_dict.get('consumable_swap_keys'):
            handle_consumable_swap_keys(key_dict['consumable_swap_keys'])
        if key_dict.get('outfit_swap_keys'):
            handle_outfit_swap_keys(key_dict['outfit_swap_keys'])
        if key_dict.get('material_swap_keys'):
            handle_material_swap_keys(key_dict['material_swap_keys'])
        if key_dict.get('valuables_swap_keys'):
            handle_valuable_swap_keys(key_dict['valuables_swap_keys'])
        if key_dict.get('weapon_swap_keys'):
            handle_backpack_weapon_swap_keys(key_dict['weapon_swap_keys'])
        if key_dict.get('accessorie_swap_keys'):
            handle_backpack_accessories_swap_keys(key_dict['accessorie_swap_keys'])

    except OSError as e:
        messagebox.showerror("Error", str(e))


# this isn't working correctly for some reason I need to make
# sure the file dialog shows up every time !
def create_backup_dir(file_name):
    backup_dir = os.path.join(os.path.dirname(file_name), "Gamesave_Backup", os.path.basename(file_name))
    if not os.path.exists(backup_dir):
        os.makedirs(backup_dir)


def create_backup(file_path):
    backup_dir = os.path.join(os.path.dirname(file_path), "Gamesave_Backup", os.path.basename(file_path))
    if os.path.exists(backup_dir):
        response = messagebox.askquestion("Backup Exists",
                                          f"A backup for file '{os.path.basename(file_path)}' already exists. Do you "
                                          f"want to overwrite it?",
                                          icon='warning')
        if response == 'yes':
            shutil.rmtree(backup_dir)
        elif response == 'no':
            return
        else:
            return

    create_backup_dir(file_path)
    os.makedirs(backup_dir, exist_ok=True)
    shutil.copy2(file_path, os.path.join(backup_dir, os.path.basename(file_path)))


# A lot of these functions are copy/paste we just need to adjust each function correctly for each set of items.
# that's including level seeds amount etc

def handle_skill_base_keys(skill_base_keys):
    for key, hex_value in skill_base_keys.items():
        key_bytes = bytes.fromhex(hex_value)
        offset = file_contents.find(key_bytes)

        if offset != -1:
            row = len(canvas_skills_1.grid_slaves())

            key_label_text = f"Skill : {key}"
            key_label = ttk.Label(canvas_skills_1, text=key_label_text)
            key_label.grid(row=row, column=0, sticky="w", padx=10, pady=5)

            offset_label_text = f"Offset : {offset}"
            offset_label = ttk.Label(canvas_skills_1, text=offset_label_text)
            offset_label.grid(row=row, column=1, sticky="w", padx=10, pady=5)

            value_offset = offset + len(bytes.fromhex(re.sub(r'\s+', '', skill_base_keys[key])))
            if value_offset + 2 <= len(file_contents):
                two_byte_value = int.from_bytes(file_contents[value_offset:value_offset + 2], byteorder='little')
                skill_label_text = f"Skill Level : {two_byte_value}"
                skill_label = ttk.Label(canvas_skills_1, text=skill_label_text)
                skill_label.grid(row=row, column=1, sticky="w", padx=200, pady=5)

                entry_var = tk.StringVar()
                entry_box = customtkinter.CTkEntry(canvas_skills_1, textvariable=entry_var, width=50)
                entry_box.grid(row=row, column=1, sticky="w", padx=250, pady=5)

                entry_handler = create_entry_handler(key, value_offset, canvas_skills_1, entry_var, skill_label)
                entry_box.bind("<Return>", entry_handler)

                tooltip_message = f"Enter a number from 1-50000\nHigher numbers might break some skills '{skill_label_text}'."
                ToolTip(skill_label, text=tooltip_message)

                tooltip_message = f"Test hint messages for '{key_label_text}'."
                ToolTip(key_label, text=tooltip_message)


def create_entry_handler(key, value_offset, frame, entry_var, skill_label):
    def entry_handler(event):
        new_value = entry_var.get()

        try:
            decimal_value = int(new_value)
            if decimal_value < 0 or decimal_value > 50000:
                tk.messagebox.showerror("Error", "Value must be between 0 and 50000.")
                return

            new_bytes = decimal_value.to_bytes(2, byteorder='little')

            file_contents[value_offset:value_offset + 2] = new_bytes

            with open(file_path, 'rb+') as f:
                f.seek(value_offset)
                f.write(new_bytes)

            print(f"Updated key '{key}' with new value '{decimal_value}'.")

            skill_label_text = f"Skill Level : {decimal_value}"
            skill_label.configure(text=skill_label_text)

            entry_var.set("")

        except ValueError:
            pass

    return entry_handler


def handle_legend_skill_keys(legend_skill_keys):
    for key, hex_value in legend_skill_keys.items():
        key_bytes = bytes.fromhex(hex_value)
        offset = file_contents.find(key_bytes)

        if offset != -1:
            row = len(canvas_skills_2.grid_slaves())

            key_label_text = f"Skill : {key}"
            key_label = ttk.Label(canvas_skills_2, text=key_label_text)
            key_label.grid(row=row, column=0, sticky="w", padx=10, pady=5)

            offset_label_text = f"Offset : {offset}"
            offset_label = ttk.Label(canvas_skills_2, text=offset_label_text)
            offset_label.grid(row=row, column=1, sticky="w", padx=10, pady=5)

            value_offset = offset + len(bytes.fromhex(re.sub(r'\s+', '', legend_skill_keys[key])))
            if value_offset + 2 <= len(file_contents):
                two_byte_value = int.from_bytes(file_contents[value_offset:value_offset + 2], byteorder='little')
                value_label_text = f"Skill Level : {two_byte_value}"
                value_label = ttk.Label(canvas_skills_2, text=value_label_text)
                value_label.grid(row=row, column=1, sticky="w", padx=200, pady=5)

                entry_var = tk.StringVar()
                entry_box = customtkinter.CTkEntry(canvas_skills_2, textvariable=entry_var, width=50)
                entry_box.grid(row=row, column=1, sticky="w", padx=250, pady=5)

                entry_handler = create_entry_handler(key, value_offset, canvas_skills_2, entry_var, value_label)
                entry_box.bind("<Return>", entry_handler)

                tooltip_message = f"Test hint messages for '{value_label_text}'."
                ToolTip(value_label, text=tooltip_message)

                tooltip_message = f"Test hint messages for '{key_label_text}'."
                ToolTip(key_label, text=tooltip_message)


tooltip_messages = {}


# need to fix the tooltips and the labels correctly for this function !
def handle_XP_value_keys(XP_value_keys):
    row = len(canvas_XP_1.grid_slaves())
    player_label = None
    legend_label = None
    event_label = None

    for key, hex_value in XP_value_keys.items():
        key_bytes = bytes.fromhex(hex_value)
        offset = file_contents.find(key_bytes)

        if offset != -1:
            row = len(canvas_XP_1.grid_slaves())

            key_label_text = f"Skill : {key}"
            key_label = ttk.Label(canvas_XP_1, text=key_label_text)
            key_label.grid(row=row, column=0, sticky="w", padx=10, pady=5)

            offset_label_text = f"Offset: {offset}"
            offset_label = ttk.Label(canvas_XP_1, text=offset_label_text)
            offset_label.grid(row=row, column=1, sticky="w", padx=10, pady=5)

            value_offset = offset + len(key_bytes)
            value_label_text = ""

            if key == "player level   ":
                bytes_to_read = 1
            elif key == "Legend level   ":
                bytes_to_read = 1 + 4 + 3
            else:
                bytes_to_read = 3 + 1 + 3

            if value_offset + bytes_to_read <= len(file_contents):
                if key == "player level   ":
                    value = int.from_bytes(file_contents[value_offset:value_offset + 1], byteorder='little')
                    player_label_text = f"Level : {value}"
                    player_label = ttk.Label(canvas_XP_1, text=player_label_text)
                    player_label.grid(row=row, column=1, sticky="w", padx=201, pady=5)
                    tooltip_messages[player_label] = f"Add a player level number 1-8.\n8 = level 9 in-game"
                elif key == "Legend level   ":
                    value = int.from_bytes(file_contents[value_offset:value_offset + 1], byteorder='little')
                    value_offset += 1 + 4
                    next_value = int.from_bytes(file_contents[value_offset:value_offset + 3], byteorder='little')
                    legend_label_text = f"Level : {value} XP: {next_value}"
                    legend_label = ttk.Label(canvas_XP_1, text=legend_label_text)
                    legend_label.grid(row=row, column=1, sticky="w", padx=201, pady=5)
                    tooltip_messages[legend_label] = f"Add a legend level number 1-250."
                else:
                    value = int.from_bytes(file_contents[value_offset:value_offset + 3], byteorder='little')
                    value_offset += 3 + 1
                    next_value = int.from_bytes(file_contents[value_offset:value_offset + 3], byteorder='little')
                    event_label_text = f"Level : {value} XP Level : {next_value}"
                    event_label = ttk.Label(canvas_XP_1, text=event_label_text)
                    event_label.grid(row=row, column=1, sticky="w", padx=201, pady=5)
                    tooltip_messages[event_label] = f"Select a number between 1-9999999\n to increase your XP."

                value_label = ttk.Label(canvas_XP_1, text=value_label_text)
                value_label.grid(row=row, column=1, sticky="w", padx=200, pady=5)

                entry_xp_var = tk.StringVar()
                entry_box_xp = customtkinter.CTkEntry(canvas_XP_1, textvariable=entry_xp_var, width=70)
                entry_box_xp.grid(row=row, column=1, sticky="nsew", padx=350, pady=5)

                entry_box_xp.bind("<Return>", lambda event, key=key, offset=value_offset, entry_var=entry_xp_var,
                                                     value_label=value_label: write_XP_on_enter(event, key, offset,
                                                                                                entry_var, value_label))

                row += 1

    for label, tooltip_text in tooltip_messages.items():
        ToolTip(label, text=tooltip_text)

    tooltip_messages[player_label] = f"Add a player level number 1-8.\n8 = level 9 in-game"
    tooltip_messages[legend_label] = f"Add a legend level number 1-250."
    tooltip_messages[event_label] = f"Select a number between 1-9999999\n to increase your XP."

    tooltip_message = f"Test hint messages for '{key_label_text}'."
    ToolTip(key_label, text=tooltip_message)


def write_XP_values(file_path, key, offset, new_value, value_label, entry_var=None):
    with open(file_path, 'rb+') as file:
        file.seek(offset)

        if key == "player level   ":
            if new_value < 1 or new_value > 8:
                raise ValueError("Player level value must be between 1 and 8.")
            new_bytes = new_value.to_bytes(1, byteorder='little')

            file.write(new_bytes)

            player_label_text = f"Level : {new_value}"
            value_label.configure(text=player_label_text)

        # thanks to batang for the legend level implementation
        elif key == "Legend level   ":
            if new_value < 1 or new_value > 250:
                messagebox.showerror("Invalid Legend Level Number", "Legend level value must be between 1 and 250.")
                return
            xp_increment = 250
            xp_needed = 1000 + (new_value - 2) * xp_increment

            total_xp = 0
            for level in range(2, new_value + 1):
                xp_needed = 1000 + (level - 2) * xp_increment
                total_xp += xp_needed

            sum_xp_bytes = total_xp.to_bytes(3, byteorder='little')
            file.write(sum_xp_bytes)

            legend_label_text = f"Level : {new_value} XP : {total_xp}"
            value_label.configure(text=legend_label_text)

            print(f"Successfully updated key '{key}' with new Legend level: {new_value}")
            print(f"Total XP after updating: {total_xp}")

        else:
            if new_value < 0 or new_value > 9999999:
                raise ValueError("Value must be between 0 and 9999999.")
            new_bytes = new_value.to_bytes(3, byteorder='little')

            file.write(new_bytes)

            value_label_text = f"Value: {new_value}"
            value_label.configure(text=value_label_text)

            print(f"Successfully updated key '{key}' with new value: {new_value}")

            if entry_var:
                entry_var.set("")


def write_XP_on_enter(event, key, offset, entry_XP_var, value_label):
    new_value_string = entry_XP_var.get()

    try:
        new_value = int(new_value_string)

        write_XP_values(file_path, key, offset, new_value, value_label)

        entry_XP_var.set("")

    except ValueError as e:
        print(str(e))


def handle_weapon_swap_keys(weapon_swap_keys):
    if not isinstance(file_contents, bytearray):
        print("Error: file_contents should be a bytearray object.")
        return

    start_bytes = bytes.fromhex(START_INVENTORY_VALUE)
    end_bytes = bytes.fromhex(END_INVENTORY_VALUE)

    start_offset = file_contents.find(start_bytes)
    end_offset = file_contents.find(end_bytes)

    if start_offset != -1 and end_offset != -1:
        print(f"Weapon Swap Function Start hex value found at offset {start_offset}")
        print(f"Weapon Swap Function End hex value found at offset {end_offset}")

        data_between_offsets = file_contents[start_offset + len(start_bytes):end_offset]

        found_keys = []

        for key, hex_value in weapon_swap_keys.items():
            key_bytes = bytes.fromhex(hex_value)
            key_bytes = key_bytes.lstrip(b'\x00')

            last_4_bytes = key_bytes[-4:]

            key_offset = data_between_offsets.find(key_bytes)

            if key_offset != -1:
                found_keys.append(
                    (key, key_offset, key_bytes, last_4_bytes))

        found_keys.sort(key=lambda x: x[1])

        sdg_data_list = handle_weapon_data(found_keys, data_between_offsets, start_offset)

        row_counter = 0

        found_keys_label = ttk.Label(canvas_inventory_1, text=f"Found {len(found_keys)} Weapons in Inventory")
        found_keys_label.grid(row=row_counter * 5, column=0, padx=400, pady=5, sticky="nw")

        row_counter = 1

        for key, key_offset, excluded_key_bytes, last_4_bytes in found_keys:
            label_text = f"Item : {key}, Offset : {key_offset}"

            if row_counter < len(sdg_data_list):
                sdg_data = sdg_data_list[row_counter]

                weapon_label = ttk.Label(canvas_inventory_1, text=label_text)
                weapon_label.grid(row=row_counter * 5, column=0, padx=10, pady=5, sticky="w")

                current_level_value = sdg_data['level']
                current_seed_value = sdg_data['seeds']
                current_amount_value = sdg_data['amount']
                current_float_value_value = sdg_data['float_value']

                current_level_label = ttk.Label(canvas_inventory_1, text=f"Level: {current_level_value}")
                current_level_label.grid(row=row_counter * 5 + 1, column=0, padx=10, pady=5, sticky="w")

                current_seed_label = ttk.Label(canvas_inventory_1, text=f"Seed: {current_seed_value}")
                current_seed_label.grid(row=row_counter * 5 + 2, column=0, padx=10, pady=5, sticky="w")

                current_amount_label = ttk.Label(canvas_inventory_1, text=f"Amount: {current_amount_value}")
                current_amount_label.grid(row=row_counter * 5 + 3, column=0, padx=10, pady=5, sticky="w")

                current_float_value_label = ttk.Label(canvas_inventory_1,
                                                      text=f"Durability : {current_float_value_value}")
                current_float_value_label.grid(row=row_counter * 5 + 4, column=0, padx=10, pady=5, sticky="w")

                new_level_entry = customtkinter.CTkEntry(canvas_inventory_1, width=70, placeholder_text="New Level")
                new_level_entry.grid(row=row_counter * 5 + 1, column=0, padx=120, pady=5, sticky="w")

                new_seed_entry = customtkinter.CTkEntry(canvas_inventory_1, width=70, placeholder_text="New Seed")
                new_seed_entry.grid(row=row_counter * 5 + 2, column=0, padx=120, pady=5, sticky="w")

                new_amount_entry = customtkinter.CTkEntry(canvas_inventory_1, width=70, placeholder_text="New Amount")
                new_amount_entry.grid(row=row_counter * 5 + 3, column=0, padx=120, pady=5, sticky="w")

                new_float_value_entry = customtkinter.CTkEntry(canvas_inventory_1, width=70,
                                                               placeholder_text="New durability Value")
                new_float_value_entry.grid(row=row_counter * 5 + 4, column=0, padx=120, pady=5, sticky="w")

                weapon_size = len(excluded_key_bytes) - 5 if excluded_key_bytes.startswith(b'\x00') else len(
                    excluded_key_bytes) - 4
                weapon_size_label_text = f"Weapon ID Size : {weapon_size}"

                weapon_size_label = ttk.Label(canvas_inventory_1, text=weapon_size_label_text)
                weapon_size_label.grid(row=row_counter * 5 + 0, column=0, padx=500, pady=5, sticky="w")

                row_counter += 0

                weapon_entry = customtkinter.CTkEntry(canvas_inventory_1, width=350,
                                                      placeholder_text="Enter New ID Here")
                weapon_entry.grid(row=row_counter * 5 + 0, column=0, padx=500, pady=5, sticky="w")

                weapon_entry.bind("<Return>",
                                  lambda event, key_bytes=excluded_key_bytes, last_4_bytes=last_4_bytes,
                                         key_offset=key_offset,
                                         entry_var=weapon_entry,
                                         value_label=weapon_label, data=data_between_offsets,
                                         path=file_path, offset=start_offset, bytes=start_bytes:
                                  write_weapon_on_enter(event, key_bytes, last_4_bytes, key_offset, entry_var,
                                                        value_label, data,
                                                        path, offset, bytes))

                new_level_entry.bind("<Return>",
                                     lambda event, sdg_index=row_counter - 1, entry_var=new_level_entry,
                                            level_label=current_level_label:
                                     write_weapon_level_on_enter(event, sdg_index, entry_var, sdg_data_list, file_path,
                                                          level_label))

                row_counter += 1

                key_tooltip_message = f"Key: {key}"
                ToolTip(weapon_label, text=key_tooltip_message)

                key_size_tooltip_message = (f"Size of Weapon : {weapon_size}\nYou can only replace This ID "
                                            f"with a new ID of the same length or smaller")
                ToolTip(weapon_size_label, text=key_size_tooltip_message)

        else:
            print("Start or end hex value not found in the opened file.")


# this does not work correctly yet. we read the correct values for each weapon key im just having issues writing back
# to the same location for each weapon. we need to create a function to perform the write for each item correctly.
# another issue with this is because we are using json and not parsing the file directly if we or a user swaps items
# with a weapon eg : consumable etc. it won't show up but the data for the item will remain unchanged (the game will
# place the item in the correct location in game like in the consumabels etc. but the data for the weapon itself will
# remain in the weapon data. therefore it may show incorrect data for items..... the way the data works for items is
# the field of data eg : seeds etc. is from the first weapon back the first SGDs (jump 17 bytes then read 12) those 12
# bytes are for the first weapon or item. the second weapon will be the second SGDs value and so on. this should be
# the same for all items, so It's not hard to locate.
def write_weapon_level_on_enter(event, sdg_index, entry_var, sdg_data_list, file_path, level_label):
    new_level = int(entry_var.get())

    sdg_data = sdg_data_list[sdg_index]
    target_offset = sdg_data['offset']

    new_level_bytes = struct.pack('H', new_level)

    with open(file_path, "rb+") as file:
        file.seek(target_offset)
        file.write(new_level_bytes)

    sdg_data_list[sdg_index]['level'] = new_level

    level_label.config(text=f"Current Level: {new_level}")

    entry_var.delete(0, "end")

    print(f"Modified level written back to the file.")


def handle_weapon_data(found_keys, data_between_offsets, start_offset):
    sdg_data_list = []

    first_weapon_key_offset_relative = found_keys[0][1]

    first_weapon_key_offset_absolute = start_offset + first_weapon_key_offset_relative

    # Search backwards for the first occurrence of the target value before the first weapon key offset
    # we need to search backwards as the save data is done backwards, so we locate the first weapon key and
    # keep moving back until we hit the string

    target_value = b"\xFF\xFF\xFF\xFF\x04\x00\x4E\x6F\x6E\x65\x53\x47\x44\x73"
    target_value_offset = data_between_offsets.rfind(target_value, 0, first_weapon_key_offset_relative)

    if target_value_offset != -1:
        print(f"Target value offset (relative): {target_value_offset}")
        print(f"Target value offset (absolute): {target_value_offset + start_offset}")

        # Print all data between the target value and the first weapon key
        # this is to ensure we have the correct location
        data_between_target_and_weapon = data_between_offsets[
                                         target_value_offset + len(target_value):first_weapon_key_offset_relative]
        print("Data between target value and first weapon key:", data_between_target_and_weapon.hex())

        sdg = b"\x53\x47\x44\x73"
        sdg_occurrences = [i.start() for i in re.finditer(sdg, data_between_target_and_weapon)]

        if sdg_occurrences:
            print(f"SDG occurrences:", sdg_occurrences)
            jump_amount = -17  # Move back 17 bytes from each SDGs string then read 12 bytes.
            # these 12 bytes are the main data for each weapon (weapon level, seeds, amount and durability)
            read_amount = 12

            for occurrence in reversed(sdg_occurrences):  # Iterate in reverse order because we need to move backwards
                jump_offset = occurrence + jump_amount
                if jump_offset >= 0:  # make sure we don't go out of bounds
                    # Read 12 bytes moving backwards
                    read_data_backwards = data_between_target_and_weapon[jump_offset - read_amount:jump_offset]

                    level = struct.unpack('H', read_data_backwards[0:2])[0]
                    seeds = struct.unpack('H', read_data_backwards[2:4])[0]
                    amount = struct.unpack('H', read_data_backwards[4:6])[0]
                    float_value = struct.unpack('f', read_data_backwards[8:12])[0]

                    sdg_data_list.append({
                        'level': level,
                        'seeds': seeds,
                        'amount': amount,
                        'float_value': float_value,
                        'offset': jump_offset - read_amount
                    })

                    # making sure we have the correct values
                    read_data_hex = read_data_backwards.hex()
                    print(f"Jumped {abs(jump_amount)} bytes and read {read_amount} bytes backwards:")
                    print(f"Level: {level}")
                    print(f"Seeds: {seeds}")
                    print(f"Amount: {amount}")
                    print(f"Float value: {float_value}")
                    print(f"Read data as hex string: {read_data_hex}")
                else:
                    print(f"Not enough bytes to jump back at occurrence {occurrence}")
            else:
                print(f"No SDG found between target value and first weapon key")

        else:
            print("Target value not found before the first weapon key")
        return sdg_data_list


def write_weapon_on_enter(event, key_bytes, last_4_bytes, key_offset, entry_var, value_label, data_between_offsets,
                          file_path, start_offset, start_bytes):
    new_key = entry_var.get().strip()

    padding_length = len(key_bytes) - len(new_key)

    if len(new_key) > len(key_bytes):
        error_message = "New ID cannot be longer than the original ID."
        messagebox.showerror("Error", error_message)
        return

    new_key_padded = new_key + ('\x00' * padding_length)

    new_key_bytes = bytes(new_key_padded, 'utf-8')

    key_offset_in_file = start_offset + len(start_bytes) + key_offset

    # Exclude the last 4 bytes for replacement we don't want to replace the SDGs
    new_key_without_last_4_bytes = new_key_bytes[:-4]

    new_key_without_last_4_bytes_with_last_4_bytes = new_key_without_last_4_bytes + last_4_bytes

    with open(file_path, "rb+") as file:
        file.seek(key_offset_in_file)
        file.write(new_key_without_last_4_bytes_with_last_4_bytes)

    print(f"Replaced key '{key_bytes}' with '{new_key_padded}' at offset {key_offset_in_file}")

    value_label.configure(text=f"Item : {new_key_padded}, Offset : {key_offset_in_file}")

    entry_var.delete(0, "end")

    print("Modified data written back to the file.")


def handle_accessories_swap_keys(accessorie_swap_keys):
    if not isinstance(file_contents, bytearray):
        print("Error: file_contents should be a bytearray object.")
        return

    start_bytes = bytes.fromhex(START_INVENTORY_VALUE)
    end_bytes = bytes.fromhex(END_INVENTORY_VALUE)

    start_offset = file_contents.find(start_bytes)
    end_offset = file_contents.find(end_bytes)

    if start_offset != -1 and end_offset != -1:
        print(f"Accessories Swap Function Start hex value found at offset {start_offset}")
        print(f"Accessories Swap Function End hex value found at offset {end_offset}")

        data_between_offsets = file_contents[start_offset + len(start_bytes):end_offset]

        found_keys = []

        for key, hex_value in accessorie_swap_keys.items():
            key_bytes = bytes.fromhex(hex_value)
            key_bytes = key_bytes.lstrip(b'\x00')  # Remove leading null bytes from json file key

            last_4_bytes = key_bytes[-4:]

            key_offset = data_between_offsets.find(key_bytes)

            if key_offset != -1:
                found_keys.append(
                    (key, key_offset, key_bytes, last_4_bytes))

        found_keys.sort(key=lambda x: x[1])

        row_counter = 0

        found_keys_label = ttk.Label(canvas_inventory_2, text=f"Found {len(found_keys)} Accessories in Inventory")
        found_keys_label.grid(row=row_counter * 5, column=1, padx=0, pady=5, sticky="nw")

        row_counter = 1

        for key, key_offset, excluded_key_bytes, last_4_bytes in found_keys:
            label_text = f"Item : {key}, Offset : {key_offset}"

            accessorie_label = ttk.Label(canvas_inventory_2, text=label_text)
            accessorie_label.grid(row=row_counter, column=0, padx=10, pady=5, sticky="w")

            accessorie_size = len(excluded_key_bytes) - 4
            accessorie_size_label_text = f"Accessorie ID Size : {accessorie_size}"
            accessorie_size_label = ttk.Label(canvas_inventory_2, text=accessorie_size_label_text)
            accessorie_size_label.grid(row=row_counter, column=1, padx=10, pady=5, sticky="w")

            accessorie_entry = customtkinter.CTkEntry(canvas_inventory_2, width=350,
                                                      placeholder_text="Enter New ID Here")
            accessorie_entry.grid(row=row_counter, column=2, padx=10, pady=5, sticky="w")

            accessorie_entry.bind("<Return>",
                                  lambda event, key_bytes=excluded_key_bytes, last_4_bytes=last_4_bytes,
                                         key_offset=key_offset,
                                         entry_var=accessorie_entry,
                                         value_label=accessorie_label, data=data_between_offsets,
                                         path=file_path, offset=start_offset, bytes=start_bytes:
                                  write_accessorie_on_enter(event, key_bytes, last_4_bytes, key_offset, entry_var,
                                                            value_label, data,
                                                            path, offset, bytes))

            row_counter += 1

            key_tooltip_message = f"Key: {key}"
            ToolTip(accessorie_label, text=key_tooltip_message)

            key_size_tooltip_message = (f"Size of Accessorie : {accessorie_size}\nYou can only replace This ID "
                                        f"with a new ID of the same length or smaller")
            ToolTip(accessorie_size_label, text=key_size_tooltip_message)


    else:
        print("Start or end hex value not found in the opened file.")


def write_accessorie_on_enter(event, key_bytes, last_4_bytes, key_offset, entry_var, value_label, data_between_offsets,
                              file_path, start_offset, start_bytes):
    new_key = entry_var.get().strip()

    padding_length = len(key_bytes) - len(new_key)

    if len(new_key) > len(key_bytes):
        error_message = "New ID cannot be longer than the original ID."
        messagebox.showerror("Error", error_message)
        return

    new_key_padded = new_key + ('\x00' * padding_length)

    new_key_bytes = bytes(new_key_padded, 'utf-8')

    key_offset_in_file = start_offset + len(start_bytes) + key_offset

    new_key_without_last_4_bytes = new_key_bytes[:-4]

    new_key_without_last_4_bytes_with_last_4_bytes = new_key_without_last_4_bytes + last_4_bytes

    with open(file_path, "rb+") as file:
        file.seek(key_offset_in_file)
        file.write(new_key_without_last_4_bytes_with_last_4_bytes)

    print(f"Replaced key '{key_bytes}' with '{new_key_padded}' at offset {key_offset_in_file}")

    value_label.configure(text=f"Item : {new_key_padded}, Offset : {key_offset_in_file}")

    entry_var.delete(0, "end")

    print("Modified data written back to the file.")


def handle_consumable_swap_keys(consumable_swap_keys):
    if not isinstance(file_contents, bytearray):
        print("Error: file_contents should be a bytearray object.")
        return

    start_bytes = bytes.fromhex(START_INVENTORY_VALUE)
    end_bytes = bytes.fromhex(END_INVENTORY_VALUE)

    start_offset = file_contents.find(start_bytes)
    end_offset = file_contents.find(end_bytes)

    if start_offset != -1 and end_offset != -1:
        print(f"Consumable Swap Function Start hex value found at offset {start_offset}")
        print(f"Consumable Swap Function End hex value found at offset {end_offset}")

        data_between_offsets = file_contents[start_offset + len(start_bytes):end_offset]

        found_keys = []

        for key, hex_value in consumable_swap_keys.items():
            key_bytes = bytes.fromhex(hex_value)
            key_bytes = key_bytes.lstrip(b'\x00')

            last_4_bytes = key_bytes[-4:]

            key_offset = data_between_offsets.find(key_bytes)

            if key_offset != -1:
                found_keys.append(
                    (key, key_offset, key_bytes, last_4_bytes))

        found_keys.sort(key=lambda x: x[1])

        row_counter = 0

        for key, key_offset, excluded_key_bytes, last_4_bytes in found_keys:
            label_text = f"Item : {key}, Offset : {key_offset}"

            consumable_label = ttk.Label(canvas_inventory_3, text=label_text)
            consumable_label.grid(row=row_counter, column=0, padx=10, pady=5, sticky="w")

            consumable_size = len(excluded_key_bytes) - 4
            consumable_size_label_text = f"Consumable ID Size : {consumable_size}"
            consumable_size_label = ttk.Label(canvas_inventory_3, text=consumable_size_label_text)
            consumable_size_label.grid(row=row_counter, column=1, padx=10, pady=5, sticky="w")

            consumable_entry = customtkinter.CTkEntry(canvas_inventory_3, width=350,
                                                      placeholder_text="Enter New ID Here")
            consumable_entry.grid(row=row_counter, column=2, padx=10, pady=5, sticky="w")

            consumable_entry.bind("<Return>",
                                  lambda event, key_bytes=excluded_key_bytes, last_4_bytes=last_4_bytes,
                                         key_offset=key_offset,
                                         entry_var=consumable_entry,
                                         value_label=consumable_label, data=data_between_offsets,
                                         path=file_path, offset=start_offset, bytes=start_bytes:
                                  write_consumable_on_enter(event, key_bytes, last_4_bytes, key_offset, entry_var,
                                                            value_label, data,
                                                            path, offset, bytes))

            row_counter += 1

            key_tooltip_message = f"Key: {key}"
            ToolTip(consumable_label, text=key_tooltip_message)

            key_size_tooltip_message = (f"Size of Consumable {consumable_size}\nYou can only replace This ID "
                                        f"with a new ID of the same length or smaller")
            ToolTip(consumable_size_label, text=key_size_tooltip_message)


    else:
        print("Start or end hex value not found in the opened file.")


def write_consumable_on_enter(event, key_bytes, last_4_bytes, key_offset, entry_var, value_label, data_between_offsets,
                              file_path, start_offset, start_bytes):
    new_key = entry_var.get().strip()

    padding_length = len(key_bytes) - len(new_key)

    if len(new_key) > len(key_bytes):
        error_message = "New ID cannot be longer than the original ID."
        messagebox.showerror("Error", error_message)
        return

    new_key_padded = new_key + ('\x00' * padding_length)

    new_key_bytes = bytes(new_key_padded, 'utf-8')

    key_offset_in_file = start_offset + len(start_bytes) + key_offset

    new_key_without_last_4_bytes = new_key_bytes[:-4]

    new_key_without_last_4_bytes_with_last_4_bytes = new_key_without_last_4_bytes + last_4_bytes

    with open(file_path, "rb+") as file:
        file.seek(key_offset_in_file)
        file.write(new_key_without_last_4_bytes_with_last_4_bytes)

    print(f"Replaced key '{key_bytes}' with '{new_key_padded}' at offset {key_offset_in_file}")

    value_label.configure(text=f"Item : {new_key_padded}, Offset : {key_offset_in_file}")

    entry_var.delete(0, "end")

    print("Modified data written back to the file.")


def handle_outfit_swap_keys(outfit_swap_keys):
    if not isinstance(file_contents, bytearray):
        print("Error: file_contents should be a bytearray object.")
        return

    start_bytes = bytes.fromhex(START_INVENTORY_VALUE)
    end_bytes = bytes.fromhex(END_INVENTORY_VALUE)

    start_offset = file_contents.find(start_bytes)
    end_offset = file_contents.find(end_bytes)

    if start_offset != -1 and end_offset != -1:
        print(f"Outfit Swap Function Start hex value found at offset {start_offset}")
        print(f"Outfit Swap Function End hex value found at offset {end_offset}")

        data_between_offsets = file_contents[start_offset + len(start_bytes):end_offset]

        found_keys = []

        for key, hex_value in outfit_swap_keys.items():
            key_bytes = bytes.fromhex(hex_value)
            key_bytes = key_bytes.lstrip(b'\x00')

            last_4_bytes = key_bytes[-4:]

            key_offset = data_between_offsets.find(key_bytes)

            if key_offset != -1:
                found_keys.append(
                    (key, key_offset, key_bytes, last_4_bytes))

        found_keys.sort(key=lambda x: x[1])

        row_counter = 0

        for key, key_offset, excluded_key_bytes, last_4_bytes in found_keys:
            label_text = f"Item : {key}, Offset : {key_offset}"

            outfit_label = ttk.Label(canvas_inventory_4, text=label_text)
            outfit_label.grid(row=row_counter, column=0, padx=10, pady=5, sticky="w")

            outfit_size = len(excluded_key_bytes) - 4
            outfit_size_label_text = f"Outfit ID Size : {outfit_size}"
            outfit_size_label = ttk.Label(canvas_inventory_4, text=outfit_size_label_text)
            outfit_size_label.grid(row=row_counter, column=1, padx=10, pady=5, sticky="w")

            outfit_entry = customtkinter.CTkEntry(canvas_inventory_4, width=350, placeholder_text="Enter New ID Here")
            outfit_entry.grid(row=row_counter, column=2, padx=10, pady=5, sticky="w")

            outfit_entry.bind("<Return>",
                              lambda event, key_bytes=excluded_key_bytes, last_4_bytes=last_4_bytes,
                                     key_offset=key_offset,
                                     entry_var=outfit_entry,
                                     value_label=outfit_label, data=data_between_offsets,
                                     path=file_path, offset=start_offset, bytes=start_bytes:
                              write_outfit_on_enter(event, key_bytes, last_4_bytes, key_offset, entry_var,
                                                    value_label, data,
                                                    path, offset, bytes))

            row_counter += 1

            key_tooltip_message = f"Key: {key}"
            ToolTip(outfit_label, text=key_tooltip_message)

            key_size_tooltip_message = (f"Size of Outfit '{key}': {outfit_size}\nYou can only replace This ID "
                                        f"with a new ID of the same length or smaller")
            ToolTip(outfit_size_label, text=key_size_tooltip_message)


    else:
        print("Start or end hex value not found in the opened file.")


def write_outfit_on_enter(event, key_bytes, last_4_bytes, key_offset, entry_var, value_label, data_between_offsets,
                          file_path, start_offset, start_bytes):
    new_key = entry_var.get().strip()

    padding_length = len(key_bytes) - len(new_key)

    if len(new_key) > len(key_bytes):
        error_message = "New ID cannot be longer than the original ID."
        messagebox.showerror("Error", error_message)
        return

    new_key_padded = new_key + ('\x00' * padding_length)

    new_key_bytes = bytes(new_key_padded, 'utf-8')

    key_offset_in_file = start_offset + len(start_bytes) + key_offset

    new_key_without_last_4_bytes = new_key_bytes[:-4]

    new_key_without_last_4_bytes_with_last_4_bytes = new_key_without_last_4_bytes + last_4_bytes

    with open(file_path, "rb+") as file:
        file.seek(key_offset_in_file)
        file.write(new_key_without_last_4_bytes_with_last_4_bytes)

    print(f"Replaced key '{key_bytes}' with '{new_key_padded}' at offset {key_offset_in_file}")

    value_label.configure(text=f"Item : {new_key_padded}, Offset : {key_offset_in_file}")

    entry_var.delete(0, "end")

    print("Modified data written back to the file.")


def handle_material_swap_keys(material_swap_keys):
    if not isinstance(file_contents, bytearray):
        print("Error: file_contents should be a bytearray object.")
        return

    start_bytes = bytes.fromhex(START_INVENTORY_VALUE)
    end_bytes = bytes.fromhex(END_INVENTORY_VALUE)

    start_offset = file_contents.find(start_bytes)
    end_offset = file_contents.find(end_bytes)

    if start_offset != -1 and end_offset != -1:
        print(f"Material Swap Function Start hex value found at offset {start_offset}")
        print(f"Material Swap Function End hex value found at offset {end_offset}")

        data_between_offsets = file_contents[start_offset + len(start_bytes):end_offset]

        found_keys = []

        for key, hex_value in material_swap_keys.items():
            key_bytes = bytes.fromhex(hex_value)
            key_bytes = key_bytes.lstrip(b'\x00')

            last_4_bytes = key_bytes[-4:]

            key_offset = data_between_offsets.find(key_bytes)

            if key_offset != -1:
                found_keys.append(
                    (key, key_offset, key_bytes, last_4_bytes))

        found_keys.sort(key=lambda x: x[1])

        row_counter = 0

        for key, key_offset, excluded_key_bytes, last_4_bytes in found_keys:
            label_text = f"Item : {key}, Offset : {key_offset}"

            material_label = ttk.Label(canvas_inventory_5, text=label_text)
            material_label.grid(row=row_counter, column=0, padx=10, pady=5, sticky="w")

            material_size = len(excluded_key_bytes) - 4
            material_size_label_text = f"Material ID Size : {material_size}"
            material_size_label = ttk.Label(canvas_inventory_5, text=material_size_label_text)
            material_size_label.grid(row=row_counter, column=1, padx=10, pady=5, sticky="w")

            material_entry = customtkinter.CTkEntry(canvas_inventory_5, width=350, placeholder_text="Enter New ID Here")
            material_entry.grid(row=row_counter, column=2, padx=10, pady=5, sticky="w")

            material_entry.bind("<Return>",
                                lambda event, key_bytes=excluded_key_bytes, last_4_bytes=last_4_bytes,
                                       key_offset=key_offset,
                                       entry_var=material_entry,
                                       value_label=material_label, data=data_between_offsets,
                                       path=file_path, offset=start_offset, bytes=start_bytes:
                                write_material_on_enter(event, key_bytes, last_4_bytes, key_offset, entry_var,
                                                        value_label, data,
                                                        path, offset, bytes))

            row_counter += 1

            key_tooltip_message = f"Key: {key}"
            ToolTip(material_label, text=key_tooltip_message)

            key_size_tooltip_message = (f"Size of Material : {material_size}\nYou can only replace This ID "
                                        f"with a new ID of the same length or smaller")
            ToolTip(material_size_label, text=key_size_tooltip_message)


    else:
        print("Start or end hex value not found in the opened file.")


def write_material_on_enter(event, key_bytes, last_4_bytes, key_offset, entry_var, value_label, data_between_offsets,
                            file_path, start_offset, start_bytes):
    new_key = entry_var.get().strip()

    padding_length = len(key_bytes) - len(new_key)

    if len(new_key) > len(key_bytes):
        error_message = "New ID cannot be longer than the original ID."
        messagebox.showerror("Error", error_message)
        return

    new_key_padded = new_key + ('\x00' * padding_length)

    new_key_bytes = bytes(new_key_padded, 'utf-8')

    key_offset_in_file = start_offset + len(start_bytes) + key_offset

    new_key_without_last_4_bytes = new_key_bytes[:-4]

    new_key_without_last_4_bytes_with_last_4_bytes = new_key_without_last_4_bytes + last_4_bytes

    with open(file_path, "rb+") as file:
        file.seek(key_offset_in_file)
        file.write(new_key_without_last_4_bytes_with_last_4_bytes)

    print(f"Replaced key '{key_bytes}' with '{new_key_padded}' at offset {key_offset_in_file}")

    value_label.configure(text=f"Item : {new_key_padded}, Offset : {key_offset_in_file}")

    entry_var.delete(0, "end")

    print("Modified data written back to the file.")


def handle_valuable_swap_keys(valuables_swap_keys):
    if not isinstance(file_contents, bytearray):
        print("Error: file_contents should be a bytearray object.")
        return

    start_bytes = bytes.fromhex(START_INVENTORY_VALUE)
    end_bytes = bytes.fromhex(END_INVENTORY_VALUE)

    start_offset = file_contents.find(start_bytes)
    end_offset = file_contents.find(end_bytes)

    if start_offset != -1 and end_offset != -1:
        print(f"Valuable Swap Function Start hex value found at offset {start_offset}")
        print(f"Valuable Swap Function End hex value found at offset {end_offset}")

        data_between_offsets = file_contents[start_offset + len(start_bytes):end_offset]

        found_keys = []

        for key, hex_value in valuables_swap_keys.items():
            key_bytes = bytes.fromhex(hex_value)
            key_bytes = key_bytes.lstrip(b'\x00')

            last_4_bytes = key_bytes[-4:]

            key_offset = data_between_offsets.find(key_bytes)

            if key_offset != -1:
                found_keys.append(
                    (key, key_offset, key_bytes, last_4_bytes))

        found_keys.sort(key=lambda x: x[1])

        row_counter = 0

        if not found_keys:
            no_valuables_label = ttk.Label(canvas_inventory_6, text="No valuables were found in the inventory.")
            no_valuables_label.grid(row=row_counter, column=0, padx=350, pady=5, sticky="nsew")
        else:

            for key, key_offset, excluded_key_bytes, last_4_bytes in found_keys:
                label_text = f"Item : {key}, Offset : {key_offset}"

                material_label = ttk.Label(canvas_inventory_6, text=label_text)
                material_label.grid(row=row_counter, column=0, padx=10, pady=5, sticky="w")

                valuable_size = len(excluded_key_bytes) - 4
                valuable_size_label_text = f"Material ID Size : {valuable_size}"
                valuable_size_label = ttk.Label(canvas_inventory_6, text=valuable_size_label_text)
                valuable_size_label.grid(row=row_counter, column=1, padx=10, pady=5, sticky="w")

                valuable_entry = customtkinter.CTkEntry(canvas_inventory_6, width=350,
                                                        placeholder_text="Enter New ID Here")
                valuable_entry.grid(row=row_counter, column=2, padx=10, pady=5, sticky="w")

                valuable_entry.bind("<Return>",
                                    lambda event, key_bytes=excluded_key_bytes, last_4_bytes=last_4_bytes,
                                           key_offset=key_offset,
                                           entry_var=valuable_entry,
                                           value_label=material_label, data=data_between_offsets,
                                           path=file_path, offset=start_offset, bytes=start_bytes:
                                    write_valuable_on_enter(event, key_bytes, last_4_bytes, key_offset, entry_var,
                                                            value_label, data,
                                                            path, offset, bytes))

                row_counter += 1

                key_tooltip_message = f"Key: {key}"
                ToolTip(material_label, text=key_tooltip_message)

                key_size_tooltip_message = (f"Size of Valuable : {valuable_size}\nYou can only replace This ID "
                                            f"with a new ID of the same length or smaller")
                ToolTip(valuable_size_label, text=key_size_tooltip_message)

    else:
        print("Start or end hex value not found in the opened file.")


def write_valuable_on_enter(event, key_bytes, last_4_bytes, key_offset, entry_var, value_label, data_between_offsets,
                            file_path, start_offset, start_bytes):
    new_key = entry_var.get().strip()

    padding_length = len(key_bytes) - len(new_key)

    if len(new_key) > len(key_bytes):
        error_message = "New ID cannot be longer than the original ID."
        messagebox.showerror("Error", error_message)
        return

    new_key_padded = new_key + ('\x00' * padding_length)

    new_key_bytes = bytes(new_key_padded, 'utf-8')

    key_offset_in_file = start_offset + len(start_bytes) + key_offset

    new_key_without_last_4_bytes = new_key_bytes[:-4]

    new_key_without_last_4_bytes_with_last_4_bytes = new_key_without_last_4_bytes + last_4_bytes

    with open(file_path, "rb+") as file:
        file.seek(key_offset_in_file)
        file.write(new_key_without_last_4_bytes_with_last_4_bytes)

    print(f"Replaced key '{key_bytes}' with '{new_key_padded}' at offset {key_offset_in_file}")

    value_label.configure(text=f"Item : {new_key_padded}, Offset : {key_offset_in_file}")

    entry_var.delete(0, "end")

    print("Modified data written back to the file.")


def handle_backpack_weapon_swap_keys(weapon_swap_keys):
    if not isinstance(file_contents, bytearray):
        print("Error: file_contents should be a bytearray object.")
        return

    start_bytes = bytes.fromhex(START_BACKPACK_VALUE)
    end_bytes = bytes.fromhex(END_BACKPACK_VALUE)

    start_offset = file_contents.find(start_bytes)
    end_offset = file_contents.find(end_bytes)

    if start_offset != -1 and end_offset != -1:
        print(f"Weapon Swap Function Start hex value found at offset {start_offset}")
        print(f"Weapon Swap Function End hex value found at offset {end_offset}")

        data_between_offsets = file_contents[start_offset + len(start_bytes):end_offset]

        found_keys = []

        for key, hex_value in weapon_swap_keys.items():
            key_bytes = bytes.fromhex(hex_value)
            key_bytes = key_bytes.lstrip(b'\x00')

            last_4_bytes = key_bytes[-4:]

            key_offset = data_between_offsets.find(key_bytes)

            if key_offset != -1:
                found_keys.append(
                    (key, key_offset, key_bytes, last_4_bytes))

        found_keys.sort(key=lambda x: x[1])

        row_counter = 0

        found_keys_label = ttk.Label(canvas_backpack_1, text=f"Found {len(found_keys)} Weapons in Backpack")
        found_keys_label.grid(row=row_counter * 5, column=0, padx=400, pady=5, sticky="nw")

        row_counter = 1

        for key, key_offset, excluded_key_bytes, last_4_bytes in found_keys:
            label_text = f"Item : {key}, Offset : {key_offset}"

            weapon_label = ttk.Label(canvas_backpack_1, text=label_text)
            weapon_label.grid(row=row_counter * 5, column=0, padx=10, pady=5, sticky="w")

            weapon_size = len(excluded_key_bytes) - 5 if excluded_key_bytes.startswith(b'\x00') else len(
                excluded_key_bytes) - 4
            weapon_size_label_text = f"Weapon ID Size : {weapon_size}"

            weapon_size_label = ttk.Label(canvas_backpack_1, text=weapon_size_label_text)
            weapon_size_label.grid(row=row_counter * 5 + 0, column=0, padx=500, pady=5, sticky="w")

            row_counter += 0

            weapon_entry = customtkinter.CTkEntry(canvas_backpack_1, width=350,
                                                  placeholder_text="Enter New ID Here")
            weapon_entry.grid(row=row_counter * 5 + 0, column=0, padx=500, pady=5, sticky="w")

            weapon_entry.bind("<Return>",
                              lambda event, key_bytes=excluded_key_bytes, last_4_bytes=last_4_bytes,
                                     key_offset=key_offset,
                                     entry_var=weapon_entry,
                                     value_label=weapon_label, data=data_between_offsets,
                                     path=file_path, offset=start_offset, bytes=start_bytes:
                              write_backpack_weapon_on_enter(event, key_bytes, last_4_bytes, key_offset, entry_var,
                                                             value_label, data,
                                                             path, offset, bytes))

            row_counter += 1

            key_tooltip_message = f"Key: {key}"
            ToolTip(weapon_label, text=key_tooltip_message)

            key_size_tooltip_message = (f"Size of Accessorie : {weapon_size}\nYou can only replace This ID "
                                        f"with a new ID of the same length or smaller")
            ToolTip(weapon_size_label, text=key_size_tooltip_message)

    else:
        print("Start or end hex value not found in the opened file.")


def write_backpack_weapon_on_enter(event, key_bytes, last_4_bytes, key_offset, entry_var, value_label,
                                   data_between_offsets,
                                   file_path, start_offset, start_bytes):
    new_key = entry_var.get().strip()

    padding_length = len(key_bytes) - len(new_key)

    if len(new_key) > len(key_bytes):
        error_message = "New ID cannot be longer than the original ID."
        messagebox.showerror("Error", error_message)
        return

    new_key_padded = new_key + ('\x00' * padding_length)

    new_key_bytes = bytes(new_key_padded, 'utf-8')

    key_offset_in_file = start_offset + len(start_bytes) + key_offset

    new_key_without_last_4_bytes = new_key_bytes[:-4]

    new_key_without_last_4_bytes_with_last_4_bytes = new_key_without_last_4_bytes + last_4_bytes

    with open(file_path, "rb+") as file:
        file.seek(key_offset_in_file)
        file.write(new_key_without_last_4_bytes_with_last_4_bytes)

    print(f"Replaced key '{key_bytes}' with '{new_key_padded}' at offset {key_offset_in_file}")

    value_label.configure(text=f"Item : {new_key_padded}, Offset : {key_offset_in_file}")

    entry_var.delete(0, "end")

    print("Data written back to the file.")


def handle_backpack_accessories_swap_keys(accessorie_swap_keys):
    if not isinstance(file_contents, bytearray):
        print("Error: file_contents should be a bytearray object.")
        return

    start_bytes = bytes.fromhex(START_BACKPACK_VALUE)
    end_bytes = bytes.fromhex(END_BACKPACK_VALUE)

    start_offset = file_contents.find(start_bytes)
    end_offset = file_contents.find(end_bytes)

    if start_offset != -1 and end_offset != -1:
        print(f"Accessories Swap Function Backpack Start hex value found at offset {start_offset}")
        print(f"Accessories Swap Function Backpack End hex value found at offset {end_offset}")

        data_between_offsets = file_contents[start_offset + len(start_bytes):end_offset]

        found_keys = []

        for key, hex_value in accessorie_swap_keys.items():
            key_bytes = bytes.fromhex(hex_value)
            key_bytes = key_bytes.lstrip(b'\x00')

            last_4_bytes = key_bytes[-4:]

            key_offset = data_between_offsets.find(key_bytes)

            if key_offset != -1:
                found_keys.append(
                    (key, key_offset, key_bytes, last_4_bytes))

        found_keys.sort(key=lambda x: x[1])

        row_counter = 0

        found_keys_label = ttk.Label(canvas_backpack_2, text=f"Found {len(found_keys)} Accessories in Inventory")
        found_keys_label.grid(row=row_counter * 5, column=1, padx=0, pady=5, sticky="nw")

        row_counter = 1

        for key, key_offset, excluded_key_bytes, last_4_bytes in found_keys:
            label_text = f"Item : {key}, Offset : {key_offset}"

            accessorie_label = ttk.Label(canvas_backpack_2, text=label_text)
            accessorie_label.grid(row=row_counter, column=0, padx=10, pady=5, sticky="w")

            accessorie_size = len(excluded_key_bytes) - 4
            accessorie_size_label_text = f"Accessorie ID Size : {accessorie_size}"
            accessorie_size_label = ttk.Label(canvas_backpack_2, text=accessorie_size_label_text)
            accessorie_size_label.grid(row=row_counter, column=1, padx=10, pady=5, sticky="w")

            accessorie_entry = customtkinter.CTkEntry(canvas_backpack_2, width=350,
                                                      placeholder_text="Enter New ID Here")
            accessorie_entry.grid(row=row_counter, column=2, padx=10, pady=5, sticky="w")

            accessorie_entry.bind("<Return>",
                                  lambda event, key_bytes=excluded_key_bytes, last_4_bytes=last_4_bytes,
                                         key_offset=key_offset,
                                         entry_var=accessorie_entry,
                                         value_label=accessorie_label, data=data_between_offsets,
                                         path=file_path, offset=start_offset, bytes=start_bytes:
                                  write_backpack_accessorie_on_enter(event, key_bytes, last_4_bytes, key_offset,
                                                                     entry_var,
                                                                     value_label, data,
                                                                     path, offset, bytes))

            row_counter += 1

            key_tooltip_message = f"Key: {key}"
            ToolTip(accessorie_label, text=key_tooltip_message)

            key_size_tooltip_message = (f"Size of Accessorie : {accessorie_size}\nYou can only replace This ID "
                                        f"with a new ID of the same length or smaller")
            ToolTip(accessorie_size_label, text=key_size_tooltip_message)


    else:
        print("Start or end hex value not found in the opened file.")


def write_backpack_accessorie_on_enter(event, key_bytes, last_4_bytes, key_offset, entry_var, value_label,
                                       data_between_offsets,
                                       file_path, start_offset, start_bytes):
    new_key = entry_var.get().strip()

    padding_length = len(key_bytes) - len(new_key)

    if len(new_key) > len(key_bytes):
        error_message = "New ID cannot be longer than the original ID."
        messagebox.showerror("Error", error_message)
        return

    new_key_padded = new_key + ('\x00' * padding_length)

    new_key_bytes = bytes(new_key_padded, 'utf-8')

    key_offset_in_file = start_offset + len(start_bytes) + key_offset

    new_key_without_last_4_bytes = new_key_bytes[:-4]

    new_key_without_last_4_bytes_with_last_4_bytes = new_key_without_last_4_bytes + last_4_bytes

    with open(file_path, "rb+") as file:
        file.seek(key_offset_in_file)
        file.write(new_key_without_last_4_bytes_with_last_4_bytes)

    print(f"Replaced key '{key_bytes}' with '{new_key_padded}' at offset {key_offset_in_file}")

    value_label.configure(text=f"Item : {new_key_padded}, Offset : {key_offset_in_file}")

    entry_var.delete(0, "end")

    print("Modified data written back to the file.")



def read_file_with_timeout(file_path):
    try:
        with open(file_path, 'r') as input_file:
            return input_file.read()
    except Exception as e:
        print(f"Error while processing file: {file_path}\nError message: {str(e)}")
        return None


class FileContentHolder:
    def __init__(self):
        self.content = None


def process_inventory():
    input_folder = filedialog.askdirectory(title="Select the folder for parsing keywords")
    if not input_folder:
        print("No folder selected. Exiting.")
        return

    output_file_path = filedialog.asksaveasfilename(defaultextension=".txt", title="Save Output File")
    if not output_file_path:
        print("No output file selected. Exiting.")
        return

    if not os.path.exists(input_folder):
        raise ValueError(f"The '{input_folder}' folder does not exist.")

    with open(output_file_path, 'w') as output_file:
        for dirpath, dirnames, filenames in os.walk(input_folder):
            for filename in filenames:
                file_path = os.path.join(dirpath, filename)
                print("Processing file:", file_path)

                print("Reading file content:", file_path)
                file_content = read_file_with_timeout(file_path)
                if file_content is None:
                    print(f"Error reading file: {file_path}")
                    continue

                print("Searching for lines:", file_path)
                try:
                    for line in file_content.splitlines():
                        if 'Item("' in line and 'RequiredItem("' not in line:
                            output_file.write(line[line.index('Item("'):])
                            output_file.write('\n')
                except Exception as extraction_error:
                    print("Error extracting lines:", extraction_error)

    print("Processing complete.")


class ToolTip:
    def __init__(self, widget, text):
        self.widget = widget
        self.text = text
        self.tooltip = None

        self.widget.bind("<Enter>", self.show_tooltip)
        self.widget.bind("<Leave>", self.hide_tooltip)

    def show_tooltip(self, event):
        x, y, _, _ = self.widget.bbox("insert")
        x += self.widget.winfo_rootx() + 25
        y += self.widget.winfo_rooty() + 25

        self.tooltip = tk.Toplevel(self.widget)
        self.tooltip.wm_overrideredirect(True)
        self.tooltip.wm_geometry(f"+{x}+{y}")

        label = ttk.Label(self.tooltip, text=self.text, background="blue", borderwidth=1, relief="solid")
        label.pack()

    def hide_tooltip(self, event):
        if self.tooltip:
            self.tooltip.destroy()




def display_text(text_widget, file_path):
    with open(file_path, 'r') as file:
        text = file.read()
        text_widget.delete("1.0", "end")
        text_widget.insert("1.0", text)


def search_text(event, search_entry, text_widget):
    logging.debug(f"Searching for {search_entry.get().lower()}")
    search_term = search_entry.get()
    text_widget.tag_remove("search", "1.0", "end")
    if search_term:  # only perform search if search term is not empty
        # find the first instance of search term in text widget, ignoring case
        start_index = text_widget.search(search_term, "1.0", nocase=1, stopindex="end")
        if start_index:
            end_index = f"{start_index}+{len(search_term)}c"
            text_widget.tag_add("search", start_index, end_index)
            text_widget.tag_config("search", background="yellow", foreground="black")
            text_widget.tag_remove("sel", "1.0", "end")
            text_widget.tag_add("sel", start_index, end_index)
            text_widget.see(start_index)
        else:
            messagebox.showinfo("Keyword not found", f"The keyword '{search_term}' was not found.")
    else:
        text_widget.tag_remove("sel", "1.0", "end")
        text_widget.yview_moveto(0)


def next_match(search_entry, text_widget):
    search_term = search_entry.get()
    text_widget.tag_remove("sel", "1.0", "end")
    start_index = text_widget.index("search.last")
    next_index = text_widget.search(search_term, f"{start_index}+1c", stopindex="end", nocase=1)
    if next_index:
        text_widget.tag_remove("search", "1.0", "end")
        text_widget.tag_add("search", next_index, f"{next_index}+{len(search_term)}c")
        text_widget.tag_config("search", background="yellow", foreground="black")
        text_widget.tag_add("sel", next_index, f"{next_index}+{len(search_term)}c")
        text_widget.see(next_index)
        text_widget.mark_set("search.last", next_index)
    else:
        all_matches = text_widget.search(search_term, "1.0", stopindex="end", nocase=1)
        if not all_matches:
            messagebox.showinfo("No Matches", "The search term was not found.")
        else:
            messagebox.showinfo("End of Document", "Reached end of document")
            text_widget.mark_set("search.last", "1.0")


def prev_match(search_entry, text_widget):
    search_term = search_entry.get()
    text_widget.tag_remove("sel", "1.0", "end")
    start_index = text_widget.index("search.first")
    prev_index = text_widget.search(search_term, f"{start_index}-1c", stopindex="1.0", nocase=1, backwards=True)
    if prev_index:
        text_widget.tag_remove("search", "1.0", "end")
        text_widget.tag_add("search", prev_index, f"{prev_index}+{len(search_term)}c")
        text_widget.tag_config("search", background="yellow", foreground="black")
        text_widget.tag_add("sel", prev_index, f"{prev_index}+{len(search_term)}c")
        text_widget.see(prev_index)
        text_widget.mark_set("search.first", prev_index)
    else:
        messagebox.showinfo("Start of Document", "Reached start of document")


def create_custom_ui():
    top = customtkinter.CTkToplevel()
    top.title("Dying light 2 All Item IDs")
    top.geometry("800x450")

    main_frame = customtkinter.CTkScrollableFrame(top, width=800, height=500)
    main_frame.grid(row=0, column=0, sticky="nsew")

    text_frame = tk.Frame(main_frame)
    text_frame.grid(row=0, column=0, sticky="nsew")

    text_widget = tk.Text(text_frame, wrap="none", borderwidth=0)
    text_widget.pack(fill="both", expand=True)

    text_widget.insert("end", "Please Click a button to display the IDs.\n" * 1)

    buttons_frame = tk.Frame(main_frame)
    buttons_frame.grid(row=1, column=0, sticky="nsew")

    button_commands = {}

    text_files_dir = os.path.join(os.path.dirname(os.path.abspath(__file__)), "IDs")
    text_file_names = [f for f in os.listdir(text_files_dir) if f.endswith(".txt")]

    for i, file_name in enumerate(text_file_names):
        text_file_path = os.path.join(text_files_dir, file_name)
        command = lambda file=text_file_path: display_text(text_widget, file)
        button_commands[file_name] = command

    buttons_per_row = 6
    max_buttons = 12

    for i, (text, command) in enumerate(button_commands.items()):
        if i >= max_buttons:
            break

        row = i // buttons_per_row
        column = i % buttons_per_row

        button = customtkinter.CTkButton(buttons_frame, text=text, width=10, height=25, border_width=0, corner_radius=8,
                                         hover_color="green", hover=True, command=command)
        button.grid(row=row, column=column, padx=10, pady=5, sticky="sw")

    navigation_frame = tk.Frame(main_frame)
    navigation_frame.grid(row=2, column=0, sticky="nsew")

    search_label = tk.Label(navigation_frame, text="Search Keyword:")
    search_label.grid(row=0, column=0, padx=10, pady=5, sticky="w")

    search_entry = customtkinter.CTkEntry(navigation_frame)
    search_entry.grid(row=0, column=1, padx=10, pady=5, sticky="ew")

    search_entry.bind("<KeyRelease>", lambda event: search_text(event, search_entry, text_widget))

    next_button = customtkinter.CTkButton(navigation_frame, text="Next", width=10, height=25, border_width=0,
                                          corner_radius=8, hover_color="green", hover=True,
                                          command=lambda: next_match(search_entry, text_widget))
    next_button.grid(row=0, column=2, padx=10, pady=5, sticky="e")

    previous_button = customtkinter.CTkButton(navigation_frame, text="Previous", width=10, height=25, border_width=0,
                                              corner_radius=8, hover_color="green", hover=True,
                                              command=lambda: prev_match(search_entry, text_widget))
    previous_button.grid(row=0, column=3, padx=10, pady=5, sticky="w")

    top.mainloop()


# dummy function need to implement
def close_file():
    notification.set("File closed")


# font settings for settings menu, these will need to be changed to adapt to the Customtkinter lib
def change_font_color():
    color = colorchooser.askcolor(parent=window, title="Select Font Color")
    if color[1]:
        style.configure("TButton", foreground=color[1])
        style.configure("TLabel", foreground=color[1])
        style.configure("TText", foreground=color[1])
        style.configure("TNotebook.Tab", foreground=color[1])


def change_button_font_color():
    color = colorchooser.askcolor(parent=window, title="Select Button Font Color")
    if color[1]:
        style.configure("TButton", foreground=color[1])


def change_label_font_color():
    color = colorchooser.askcolor(parent=window, title="Select Label Font Color")
    if color[1]:
        style.configure("TLabel", foreground=color[1])


def change_tab_font_color():
    color = colorchooser.askcolor(parent=window, title="Select Tab Font Color")
    if color[1]:
        style.configure("TNotebook.Tab", foreground=color[1])


def change_text_font_color():
    color = colorchooser.askcolor(parent=window, title="Select Text Font Color")
    if color[1]:
        style.configure("TText", foreground=color[1])


# these are disabled, but they will set the applications font size label color and button color by default.
# style.configure(".", font=("Courier New", 8))

# style.configure("TButton", font=("Courier New", 8), foreground="red")

# style.configure("TLabel", font=("Courier New", 8), foreground="red")

# style.configure("TText", font=("Courier New", 8), foreground="green")

def change_font_size(size):
    font = ("Courier New", size)
    style.configure(".", font=font)
    style.configure("TButton", font=font)
    style.configure("TLabel", font=font)
    style.configure("TText", font=font)
    style.configure("TNotebook.Tab", font=font)


button_font_size_var = tk.StringVar()
label_font_size_var = tk.StringVar()
tab_font_size_var = tk.StringVar()
all_font_size_var = tk.StringVar()


def change_all_font_size():
    selected_size = all_font_size_var.get()
    if selected_size:
        change_font_size(int(selected_size))


def change_button_font_size():
    selected_size = button_font_size_var.get()
    if selected_size:
        change_button_font(("Courier New", int(selected_size)))


def change_label_font_size():
    selected_size = label_font_size_var.get()
    if selected_size:
        change_label_font(("Courier New", int(selected_size)))


def change_tab_font_size():
    selected_size = tab_font_size_var.get()
    if selected_size:
        change_tab_font(("Courier New", int(selected_size)))


def change_button_font(font):
    style.configure("TButton", font=font)


def change_label_font(font):
    style.configure("TLabel", font=font)


def change_tab_font(font):
    style.configure("TNotebook.Tab", font=font)


def change_all_fonts(font):
    style.configure("TButton", font=font)
    style.configure("TLabel", font=font)
    style.configure("TNotebook.Tab", font=font)


def change_font(change_func):
    available_fonts = font.families()
    font_menu = tk.Menu(settings_menu, tearoff=0)
    for font_name in available_fonts:
        font_menu.add_command(label=font_name, command=lambda f=font_name: change_func((f, 8)))

    return font_menu


APP_DIRECTORY = os.path.dirname(os.path.abspath(__file__))

CONFIG_FILE_PATH = os.path.join(APP_DIRECTORY, "config.json")

# not working needs to be implemented correctly
def open_recent_file(file_path):
    config_data = {"last_opened_file": file_path}
    with open(CONFIG_FILE_PATH, "w") as config_file:
        json.dump(config_data, config_file)

    print("Opening recent file:", file_path)


def select_recent_file():
    if os.path.exists(CONFIG_FILE_PATH):
        with open(CONFIG_FILE_PATH, "r") as config_file:
            config_data = json.load(config_file)
            recent_files = config_data.get("recent_files", [])
    else:
        recent_files = []

    file_path = filedialog.askopenfilename()
    if file_path:
        add_recent_file(file_path)


def add_recent_file(file_path):
    if os.path.exists(CONFIG_FILE_PATH):
        with open(CONFIG_FILE_PATH, "r") as config_file:
            config_data = json.load(config_file)
            recent_files = config_data.get("recent_files", [])
            if file_path not in recent_files:
                recent_files.append(file_path)
        with open(CONFIG_FILE_PATH, "w") as config_file:
            json.dump({"recent_files": recent_files}, config_file)
    else:
        with open(CONFIG_FILE_PATH, "w") as config_file:
            json.dump({"recent_files": [file_path]}, config_file)


menu_bar = tk.Menu(window)

file_menu = tk.Menu(menu_bar, tearoff=0)
file_menu.add_command(label="Open file", command=open_save)
file_menu.add_command(label="Close file", command=close_file)
file_menu.add_command(label="Exit", command=window.quit)
menu_bar.add_cascade(label="File", menu=file_menu)

settings_menu = tk.Menu(menu_bar, tearoff=0)

# themes_menu = tk.Menu(settings_menu, tearoff=0)
# themes_menu.add_command(label="Dark Mode", command=lambda: change_theme("dark"))
# themes_menu.add_command(label="Light Mode", command=lambda: change_theme("light"))
# themes_menu.add_command(label="Yellow", command=lambda: change_theme("yellow"))
# themes_menu.add_command(label="Red", command=lambda: change_theme("red"))
# themes_menu.add_command(label="Blue", command=lambda: change_theme("blue"))
# settings_menu.add_cascade(label="Themes", menu=themes_menu)


font_menu_color = tk.Menu(settings_menu, tearoff=0)
font_menu_color.add_command(label="Change Button Font Color", command=change_button_font_color)
font_menu_color.add_command(label="Change Label Font Color", command=change_label_font_color)
font_menu_color.add_command(label="Change Tab Font Color", command=change_tab_font_color)
font_menu_color.add_command(label="Change All Font Colors", command=change_font_color)
settings_menu.add_cascade(label="Font Color", menu=font_menu_color)

menu_bar.add_cascade(label="Settings", menu=settings_menu)

tools_menu = tk.Menu(menu_bar, tearoff=0)
# tools_menu.add_command(label="Open Paint.NET", command=open_paint_net) # was used for PS4 RCO project
tools_menu.add_command(label="Open IDs",
                       command=lambda: create_custom_ui())

tools_menu.add_command(label="Parse Inventory IDs",
                       command=lambda: process_inventory())

menu_bar.add_cascade(label="Tools", menu=tools_menu)

font_size_menu = tk.Menu(settings_menu, tearoff=0)

button_font_size_submenu = tk.Menu(font_size_menu, tearoff=0)
button_font_size_submenu.add_radiobutton(label="8", variable=button_font_size_var, value="8",
                                         command=change_button_font_size)
button_font_size_submenu.add_radiobutton(label="10", variable=button_font_size_var, value="10",
                                         command=change_button_font_size)
button_font_size_submenu.add_radiobutton(label="12", variable=button_font_size_var, value="12",
                                         command=change_button_font_size)
button_font_size_submenu.add_radiobutton(label="14", variable=button_font_size_var, value="14",
                                         command=change_button_font_size)
button_font_size_submenu.add_radiobutton(label="16", variable=button_font_size_var, value="16",
                                         command=change_button_font_size)
button_font_size_submenu.add_radiobutton(label="18", variable=button_font_size_var, value="18",
                                         command=change_button_font_size)
button_font_size_submenu.add_radiobutton(label="20", variable=button_font_size_var, value="20",
                                         command=change_button_font_size)
button_font_size_submenu.add_radiobutton(label="22", variable=button_font_size_var, value="22",
                                         command=change_button_font_size)

label_font_size_submenu = tk.Menu(font_size_menu, tearoff=0)
label_font_size_submenu.add_radiobutton(label="8", variable=label_font_size_var, value="8",
                                        command=change_label_font_size)
label_font_size_submenu.add_radiobutton(label="10", variable=label_font_size_var, value="10",
                                        command=change_label_font_size)
label_font_size_submenu.add_radiobutton(label="12", variable=label_font_size_var, value="12",
                                        command=change_label_font_size)
label_font_size_submenu.add_radiobutton(label="14", variable=label_font_size_var, value="14",
                                        command=change_label_font_size)
label_font_size_submenu.add_radiobutton(label="16", variable=label_font_size_var, value="16",
                                        command=change_label_font_size)
label_font_size_submenu.add_radiobutton(label="18", variable=label_font_size_var, value="18",
                                        command=change_label_font_size)
label_font_size_submenu.add_radiobutton(label="20", variable=label_font_size_var, value="20",
                                        command=change_label_font_size)
label_font_size_submenu.add_radiobutton(label="22", variable=label_font_size_var, value="22",
                                        command=change_label_font_size)

tab_font_size_submenu = tk.Menu(font_size_menu, tearoff=0)
tab_font_size_submenu.add_radiobutton(label="8", variable=tab_font_size_var, value="8", command=change_tab_font_size)
tab_font_size_submenu.add_radiobutton(label="10", variable=tab_font_size_var, value="10", command=change_tab_font_size)
tab_font_size_submenu.add_radiobutton(label="12", variable=tab_font_size_var, value="12", command=change_tab_font_size)
tab_font_size_submenu.add_radiobutton(label="14", variable=tab_font_size_var, value="14", command=change_tab_font_size)
tab_font_size_submenu.add_radiobutton(label="16", variable=tab_font_size_var, value="16", command=change_tab_font_size)
tab_font_size_submenu.add_radiobutton(label="18", variable=tab_font_size_var, value="18", command=change_tab_font_size)
tab_font_size_submenu.add_radiobutton(label="20", variable=tab_font_size_var, value="20", command=change_tab_font_size)
tab_font_size_submenu.add_radiobutton(label="22", variable=tab_font_size_var, value="22", command=change_tab_font_size)

all_font_size_submenu = tk.Menu(font_size_menu, tearoff=0)
all_font_size_submenu.add_radiobutton(label="8", variable=all_font_size_var, value="8", command=change_all_font_size)
all_font_size_submenu.add_radiobutton(label="10", variable=all_font_size_var, value="10", command=change_all_font_size)
all_font_size_submenu.add_radiobutton(label="12", variable=all_font_size_var, value="12", command=change_all_font_size)
all_font_size_submenu.add_radiobutton(label="14", variable=all_font_size_var, value="14", command=change_all_font_size)
all_font_size_submenu.add_radiobutton(label="16", variable=all_font_size_var, value="16", command=change_all_font_size)
all_font_size_submenu.add_radiobutton(label="18", variable=all_font_size_var, value="18", command=change_all_font_size)
all_font_size_submenu.add_radiobutton(label="20", variable=all_font_size_var, value="20", command=change_all_font_size)
all_font_size_submenu.add_radiobutton(label="22", variable=all_font_size_var, value="22", command=change_all_font_size)

font_size_menu.add_cascade(label="Change Button Font Size", menu=button_font_size_submenu)
font_size_menu.add_cascade(label="Change Label Font Size", menu=label_font_size_submenu)
font_size_menu.add_cascade(label="Change Tab Font Size", menu=tab_font_size_submenu)
font_size_menu.add_cascade(label="Change All Font Size", menu=all_font_size_submenu)

settings_menu.add_cascade(label="Font Size", menu=font_size_menu)

font_menu = tk.Menu(settings_menu, tearoff=0)
change_button_font_menu = change_font(change_button_font)
change_label_font_menu = change_font(change_label_font)
change_tab_font_menu = change_font(change_tab_font)
change_all_fonts_menu = change_font(change_all_fonts)

font_menu.add_cascade(label="Change Button Font", menu=change_button_font_menu)
font_menu.add_cascade(label="Change Label Font", menu=change_label_font_menu)
font_menu.add_cascade(label="Change Tab Font", menu=change_tab_font_menu)
font_menu.add_cascade(label="Change All Fonts", menu=change_all_fonts_menu)

settings_menu.add_cascade(label="Change Font", menu=font_menu)

# Choose Custom Background
# settings_menu.add_command(label="Choose Custom Background", command=choose_custom_background)


recent_files_submenu = tk.Menu(file_menu, tearoff=False)
file_menu.add_cascade(label="Recent Files", menu=recent_files_submenu)

if os.path.exists(CONFIG_FILE_PATH):
    with open(CONFIG_FILE_PATH, "r") as config_file:
        config_data = json.load(config_file)
        recent_files = config_data.get("recent_files", [])
        for file_path in recent_files:
            recent_files_submenu.add_command(label=file_path, command=lambda file=file_path: open_recent_file(file))

about_menu = tk.Menu(menu_bar, tearoff=0)

about_menu.add_command(label="About", command=lambda: messagebox.showinfo("About", "This is a work in progress "
                                                                                   "save editor for dying light 2."
                                                                                   "\nIts super early in "
                                                                                   "development and only contains "
                                                                                   "basic"
                                                                                   "\nfunctionality for now."
                                                                                   "\nIt may contain some bugs but "
                                                                                   "it should go without saying"
                                                                                   "\nalways keep a backup copy of "
                                                                                   "your gamesave before modifying "
                                                                                   "it !"
                                                                                   "\nIf you have any questions "
                                                                                   "you can reach me at my email "
                                                                                   "below."
                                                                                   "\nzCaazual123@gmail.com"))

menu_bar.add_cascade(label="About", menu=about_menu)

credits_menu = tk.Menu(menu_bar, tearoff=0)

credits_menu.add_command(label="Credits", command=lambda: messagebox.showinfo("Credits", "- BETA Testing : Batang & "
                                                                                         "Thxnder7"
                                                                                         "\n- Help sorting IDs : Batang, Bub, "
                                                                                         "Username0001 JcB\n  Skiller and the Save Wizard community"
                                                                                         "\n- Help and "
                                                                                         "support : Batang, Bub, Skiller & Method"
                                                                                         "\n- And a special thanks to "
                                                                                         "ZERO & RIA for their "
                                                                                         "inspiration <3"))

menu_bar.add_cascade(label="Credits", menu=credits_menu)

window.config(menu=menu_bar)

window.mainloop()
