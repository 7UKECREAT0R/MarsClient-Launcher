# MarsClient
Completely external Minecraft launcher and client which works with all versions of Minecraft including vanilla.

-----------------------------
The launcher attaches to any minecraft version's process and reads from the stdout to figure out what's happening in-game. Say the launcher sees the text "Build something relevant to the theme: " then it will know you're playing Build Battle on Hypixel! The same thing happens with the Hypixel party detection! The launcher also outputs all this data into a nice form of Discord rich presence.

> Note: The codebase for this launcher is incredibly messy and was more of a mock-up than what I intended to be a full project!
> This project also runs off of CmlLib for handling the launching, but performs all the logging in and session management itself for user security.
-----------------------------
The features/upcoming features in this "client" include:
- [x] Full session management.
- [x] No password storing.
- [x] Launch any Forge version.
- [x] Launch any Optifine version.
- [x] Launch any vanilla version.
- [x] Discord rich presence.
- [x] Hypixel game status. (Rich Presence)
- [x] Hypixel party status. (Rich Presence)
- [x] Hypixel keybinds which teleport you to a game.
- [ ] In-game GUI with Hypixel chat windows and friends list management. (Required method figured out, currently in development.)
-----------------------------
## How does the GUI work?
We use the SetParent function with a custom window to attach a "GUI" to minecraft [SEE HERE](https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setparent). A keyboard hook is used to detect when a hotkey is pressed and SendKeys functions are called to send chat commands.
