import os
import shutil
from tkinter import ttk, filedialog, colorchooser, font, messagebox
from tkinterdnd2 import TkinterDnD, DND_FILES
import tkinter as tk
import customtkinter

class UserInterface:
    def __init__(self) -> None:
        customtkinter.set_appearance_mode("System")
        customtkinter.set_default_color_theme("blue")

        self.self.window = customtkinter.CTk()

        dark_bg_color = "#2b2b2b"
        dark_fg_color = "white"
        dark_highlight_color = "#4f4f4f"
        dark_entry_bg_color = "#383838"

        self.window.configure(bg=dark_bg_color)
        self.window.option_add("*Background", dark_bg_color)
        self.window.option_add("*Foreground", dark_fg_color)
        self.window.option_add("*HighlightColor", dark_highlight_color)
        self.window.option_add("*EntryField.Background", dark_entry_bg_color)

        self.style = ttk.Style()
        self.style.configure("TLabel", background=dark_bg_color, foreground=dark_fg_color)
        self.style.configure("TFrame", background=dark_bg_color)
        self.style.configure("TButton", background=dark_highlight_color, foreground=dark_fg_color)
        self.style.configure("TEntry", fieldbackground=dark_entry_bg_color)

        self.window.geometry("800x510")
        self.window.resizable(True, True)
        self.window.title("Updated Editor DL2")

        file_status_label = customtkinter.CTkLabel(self.window, text="No Save Opened", anchor="w")
        file_status_label.grid(row=1, column=0, columnspan=2, sticky="we", padx=10, pady=5)

        self.window.columnconfigure(0, weight=1)
        self.window.rowconfigure(0, weight=1)

        self.tabs = customtkinter.CTkTabview(self.window)

        self.tabs.configure(
            corner_radius=20,
            text_color=('red', 'cyan')
        )

        skills_frame = self.tabs.add("Skills")
        XP_frame = self.tabs.add("Experience")
        inventory_frame = self.tabs.add("Inventory")
        backpack_frame = self.tabs.add("Backpack")
        campaign_frame = self.tabs.add("Campaign")
        All_ID_frame = self.tabs.add("Bountys ???")

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

        self.tabs.grid(row=0, column=0, sticky="news")

        # these are not used in the application itself yet although it may be implemented at some point for some things
        # it is used for the Close_file dummy function as that's not implemented yet.
        self.notification = tk.StringVar()
        self.notification_label = ttk.Label(self.window, textvariable=self.notification)
        self.notification_label.grid(row=5, column=0, padx=5, pady=5, sticky="w")

        # these are not used in the application itself yet although it may be implemented at some point for some things
        # it is used for the Close_file dummy function as that's not implemented yet.
        self.notification = tk.StringVar()
        self.notification_label = ttk.Label(self.window, textvariable=self.notification)
        self.notification_label.grid(row=5, column=0, padx=5, pady=5, sticky="w")

    def remove_notification(self):
        self.notification.set("")
        self.notification_label.configure(textvariable=self.notification)

    def open_save(self, filepath, backup) -> bool:
        current_file = filepath

        filepath = filedialog.askopenfilename()
        if not filepath:
            messagebox.showerror("Error", "File not selected")
            return False
        if current_file is not None and current_file == filepath:
            messagebox.showerror("Error", "File already open")
            return False

        self.file_status_label.configure(text=f"Save Opened: {filepath}")
        self.file_status_label.update()

        if not backup:
            self.create_backup_dir(filepath)

            backup_dir = os.path.join(os.path.dirname(filepath), "Gamesave_Backup", os.path.basename(filepath))
            os.makedirs(backup_dir, exist_ok=True)
            shutil.copy2(filepath, os.path.join(backup_dir, os.path.basename(filepath)))

        return True

    # this isn't working correctly for some reason I need to make
    # sure the file dialog shows up every time !
    def create_backup_dir(self, file_name):
        backup_dir = os.path.join(os.path.dirname(file_name), "Gamesave_Backup", os.path.basename(file_name))
        if not os.path.exists(backup_dir):
            os.makedirs(backup_dir)
    
    def showError(self, message, exception):
        messagebox.showerror("Error", str(exception))
    
    def askQuestion(self, title, message, icon):
        response = messagebox.askquestion(title, message,icon=icon)
        return response