# ContextEditor
A windows application enabling you to edit context menu buttons! (readMe will be updated when im not sleep deprived)

![image](https://github.com/UGEcko/ContextEditor/assets/38820051/f849f806-bb65-4ebf-a35d-9be2d34cb046)





Use Context editor to edit your context menu!

[Install Here](https://github.com/UGEcko/ContextEditor/releases)

Simply add a name, a file directory, maybe even an icon, and your ready to go. Hit add and it will be visible!


# Start

Starting with the first bits. Please enter a name you want your context button to be visible as, any name will do!

Next is the Program directory, either browse or manually find a program or run script that youd like to run when you press the button.

Another feature that is still WIP is icons, you may check the Icon field, and input a valid .ico file. This may or may not work.

Then hit Add and play with your button! 

To remove, select a name that corresponds to the correct program and hit the remove button at the bottom.

Known Current Limitations:

* Doesnt consider anything other than an exe file valid, so for powershell scripts, they will work but will be red in text.


Nice to knows:

* The Program directory and Icon Directory text fields have a green text for valid directories, and red text for invalid directories
* The add button is not enabled unless a valid name and directory is provided. If you check the icon field, the icon must be valid aswell.
* The remove button is not enabled unless a name in the list has been selected.
* Existing context buttons are loaded in if detected.


Cool one you can add:

Name: Task Manager
Dir: tackmgr.exe / 7 

Roadmap:

Make UI the best it can be


