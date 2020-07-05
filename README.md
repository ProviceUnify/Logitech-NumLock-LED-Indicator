# Installation:
1. Download [G HUB](https://www.logitechg.com/ru-ru/innovation/g-hub.html) if you hadn't it before;
1. Download [Logitech NumLock LED indicator.zip](https://github.com/ProviceUnify/Logitech-NumLock-LED-Indicator/releases/tag/1.0);
1. Unzip it in any folder;
1. Launch `Logitech NumLock LED Indicator.exe`
***
# Key bindings:
* _`NumLock` - change NumLock color_;
* `Win + Alt + NumLock` - reveal settings window; window doesn't show in TaskBar, you can find it by `Alt + Tab` or `Win + Tab`;
* `Win + NumLock` - stop application; also application can be closed with standard 'X' control's button
***
# Settings:
Reveal application window by `Win + Alt + NumLock`:
> ![Program Window](https://cdn.discordapp.com/attachments/586286335095078920/727896635740258364/unknown.png)
* Buttons **NumLock On** and **NumLock Off** open color pallete. Here you are can set any color as you want. Example, you can write colors here from G HUB if you have dual color keyboard backlight preset;
> ![Color Pallete](https://cdn.discordapp.com/attachments/586286335095078920/727883091737313350/unknown.png)
> 
> _My standard colors are: On - (0, 255, 255); Off - (255, 0, 50)_
* **Start with Windows** add program to Windows startup by creating an entry in Registry
> ![Windows Start Up](https://cdn.discordapp.com/attachments/586286335095078920/727884978544705536/unknown.png)
> 
> _**Note:** for proper start and work G HUB should be started first. I added default delay until `Logitech NumLock LED Indicator` start in 10 seconds_
***
# Additional settings:
All settings of program stored in `Logitech NumLock LED Indicator.exe.config`. It's necessarily should be near to program.
> `<add key="NumLock..." value="..." />`
* Color codes for NumLock On and Off. I don't recommend edit this values. Program work it automatically;
>  `<add key="delay" value="10000" />`
* Delay before program starting in milliseconds. Default value is `10000`. If program doesn't start properly you can increase this value. That's allow G HUB start before `Logitech NumLock LED Indicator`
***
# Uninstalling:
For proper uninstalling I recommend use `uninstall.bat`. It's automatically kill program process, delete startup key from Registry and delete all files related to the program.
***
## Known issues:
1. _Program starts with Windows, but doesn't work properly (doesn't react at key press)_ - **try increase `delay` value in `Logitech NumLock LED Indicator.exe.config`. Remember - in milliseconds!;**
1. _NumLock key doesn't switch color_ - **program can't hook NumLock key press event when in Your focus has window of system app (Example, Registry or etc). Also it doesn't work in window of the program. Just unfocus it (minimize or `Alt + Tab`);**
1. _Got such messages at start program or settings editing_
> ![Error on Start](https://cdn.discordapp.com/attachments/586286335095078920/727897405336584212/unknown.png)
>
> ![Error on Edit](https://cdn.discordapp.com/attachments/586286335095078920/727897459610615898/unknown.png)

**`Logitech NumLock LED Indicator.exe.config` file removed, corrupted or it content invalid. Program will work but settings doesn't will stored. Used defalut program start delay in 10 seconds. You can redownload this file from [here](https://github.com/ProviceUnify/Logitech-NumLock-LED-Indicator/releases)**
