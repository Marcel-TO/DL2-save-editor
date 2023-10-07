# DL2-save-editor
- [DL2-save-editor](#dl2-save-editor)
  - [Introduction](#introduction)
  - [To Do's](#to-dos)
  - [Requirements](#requirements)


## Introduction
This so far is a simple editor for dying light 2 PS4.

There is a LOT still be done but its very simply put together for the moment i will work on it in
my spare time but with work at the moment i just dont have the time to be fully dedicating my time to it.

hopefully if others enjoy the game they can maybe do something with it.


## To Do's
- Break the code in seperate files for easier management.
- Get a new consistent value for backpack or try using a parsing method to just parse the file directly/find patterns and handle each section correctly.
- Fix the backup save code so it will backup the save correctly and prompt the user if they wish to overwrite the last backup save. (was working but broke lol ?)
- Add the customtkinter lib for the buttons and label settings etc. currently it only supports the default tkinter lib.
- Main block file size is located 2 bytes after the header string (top of file) but changing that doest work so there might be individual block sizes for each block of data.
- We would need to locate each block size to add/remove items update the block size then update the main file size.
- Fix the code for the level seeds etc. it reads everything correctly just need to add code to write new values back.
> This also poses an issue if a user swaps a weapon with another item that is not a weapon, so parsing might be the best option to locate everything correctly. For the parse id in tools you need the inventory folder from the the game itself. `Located in data0.pak/scripts/inventory`

Im sure there is many more things to fix but thats where its at the moment.
Currently it supports replacing inventory items and editing skills.
To add support for PC simply use GZIP when opening and writing back to file or use the zlib library.

## Requirements
To make the use of this editor easier, here is a short chapter regarding the requirements and how to install them.
Inside the text file [requirements.txt](./requirements.txt) are all modules that need to be installed in order to use this editor.

To install all modules at once please use the following command (either use `pip` or `pip3` depending on your OS):
```
    pip install -r ./requirements.txt
```