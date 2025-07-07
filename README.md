# DawnsburyCharacterManager 
## What is this?
A simple character manager for [Dawnsbury Days](https://store.steampowered.com/app/2693730/Dawnsbury_Days/), a turn-based RPG by Dawnsbury Studios that's based on the Pathfinder 2e combat system.
Some friends and I wanted to share our characters easily, so I built this tool. Maybe it can help you too!

This is also, uh, my first time writing software and publishing it to Github like this. I usually just do webdev for my job LOL. So if anything's weird/easily fixable about it, let me know!

## Where do I download it?
It's in the releases section over there on the right! I know github UI is pretty esoteric, though, so you can also just [click here](https://github.com/Choojermelon/DawnsburyCharacterManager/releases)!

## This is cool! Can I say hi?
Check out my [Bluesky](https://bsky.app/profile/chuji.bsky.social), or hit me up on Discord (@chuji).

If you're feeling extra nice, [here's my Ko-Fi](https://ko-fi.com/chuji)!

Feel free to ask for features you might want to see, or let me know if there's any bugs.

## How do I use it?
Let's take a look at the UI!

![image](https://github.com/user-attachments/assets/ec2eb151-fbe6-43c4-8e27-4180259a1f8a)

### Open Character Library
Start here. Your characterLibrary.json file should be in %appdata%/Roaming/Dawnsbury, which the application will try to navigate to automatically.

### Create Backup
When you open a Character Library, you'll be asked if you want to make a backup. You can manually initiate this process using this button.

### About
View some info about the application and its author (hello!).

### Character List (left side)
The list of characters in the opened library. Click on one to select it.

### Move Up / Down
Moves the selected character in the list, swapping it with the character above/below.

### Import
Imports a .json file, or a batch of .json files, each containing a single character's data.

### Export
Exports the selected character to a .json file for use with the above.

### Delete
Deletes the selected character. Use with caution!

## What do I do about tokens?
Tokens aren't stored in AppData with your character library; they're stored wherever the game is, so they basically need to be managed separately.

Luckily, they are all stored in separate files, unlike character data! So if you import a friend's character using this application, you can drag their token file(s) into the tokens folder(s) and, as long as the name is what the character data expects, it'll match up!

In the past, I've just shared both my token folders wholesale with friends, and they do the same with each other; it's easy to merge them that way!

Tokens are stored in:
* Steam/steamapps/common/DawnsburyDays/CustomPortraits
* Steam/steamapps/common/DawnsburyDays/CustomPortraitsWithCustomRing

## Who's that cute catfolk in the icon?
![image](https://github.com/user-attachments/assets/9752feb9-e6ff-4b51-99da-0793107e6b63)

Say hi to Rook, my catfolk cleric!
