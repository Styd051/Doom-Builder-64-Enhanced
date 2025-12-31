# Doom Builder 64 Enhanced
Doom Builder 64 Enhanced is a fork of Doom Builder 64, Its main objective is to update the Doom Builder 64 source code to the latest version of the original Doom Builder 2 source code, and also to improve it and add new features for mappers.

# Doom 64 engines supported

* **DOOM 64 Remastered**
* **DOOM 64 EX+**
* **DOOM 64 EX+ Enhanced**
* **DOOM 64 N64**

# The Plugins That Are Supported

* Comments Panel
* Copy Paste Sector Props
* Stair Sector Builder
* Statistics
* Tag Range
* Reject Editor (Currently, there's a problem when you make your first save on a new map that doesn't yet contain its own WAD file, This causes the Reject Editor plugin to crash the editor, because during the first save on a new map, the editor creates its own WAD file, This is because the Reject Editor plugin looks for the REJECT lump in the map's WAD file, However, when you load a map that already has its own WAD file into the editor and save, the Reject Editor plugin won't crash the editor, it will function correctly.)

# Priority Things to Do First for Doom Builder 64 Enhanced

* Update the Doom Builder 64 source code to the latest version of the original Doom Builder 2 source code(Currently, the source code for Doom Builder 64 Enhanced is not yet updated to the latest version of the original Doom Builder 2 source code, I'm working on it gradually, updating the source code over time.)

# Doom Builder 64
Doom Builder 64 is a custom fork of Doom Builder 2 by CodeImp made to support mapping for DOOM 64 on N64 and on PC (EX/Steam/GOG), originally developed by Samuel "Kaiser" Villarreal and now maintained by Styd051 and Immorpher. 

## Installation
Doom Builder 64 doesn't ship a traditional installer. To start using Doom Builder 64, simply download a .zip file containing the binaries from the Releases page, extract it and launch `Builder.exe`.

If you're updating an existing installation, it is recommended it you delete your old Doom Builder 64 folder entirely and replace its contents with the new version.
### Requirements
Doom Builder 64 requires **Microsoft .NET Framework 3.5** installed. This should be already installed on the vast majority of computers. If your computer is an exception, consult Microsoft's pages on how to install.

## Building
Currently, only building on **Windows** is tested and officially supported. To build Doom Builder 64, use the Visual Studio solution file provided in the repository.

## Links
If you have any problems or suggestions, use the Issues or Pull Requests pages in this repository or join the [DOOM 64 Discord server](https://discord.gg/Ktxz8nz).

## Credits

* **Codeimp:** for creating Doom Builder 2.
* **Boris_i:** for contributing to Doom Builder 2.
* **MaxED:** for creating GZDoom Builder and for adding new features to the editor.
* **Kaiser:** for creating Doom Builder 64.
* **Kovic:** for having done some things and made some improvements to Doom Builder 64.
* **Diema:** for having created the nodebuilder dma-bsp64, which is a fork of D64BSP.
* **Immorpher:** for contribute to the Doom Builder 64 Enhanced project.
