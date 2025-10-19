# Notepad - Modern Text Editor

A modern, sleek notepad application built with Visual Basic .NET featuring a professional dark theme UI and enhanced functionality.

![Version](https://img.shields.io/badge/version-2.0.0-blue.svg)
![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.7.2-purple.svg)
![Platform](https://img.shields.io/badge/platform-Windows-lightgrey.svg)
![License](https://img.shields.io/badge/license-MIT-green.svg)

## Features

### 🎨 Modern Dark Theme
- Professional dark color scheme for reduced eye strain
- Sleek, borderless text editor
- High-contrast status bar for better visibility
- Consistent dark theme across all UI elements

### ✨ Core Functionality
- **File Operations**: New, Open, Save As (supports TXT, RTF, and all file types)
- **Edit Operations**: Cut, Copy, Paste, Delete, Undo, Redo
- **Format Options**: Font selection, Word wrap with visual indicator
- **View Options**: Zoom In/Out/Reset, Status bar toggle
- **Keyboard Shortcuts**: All standard shortcuts supported (Ctrl+N, Ctrl+O, Ctrl+S, etc.)

### 🛠️ Enhanced Features
- Real-time character count in status bar
- Smooth zoom controls with 10% increments
- Word wrap toggle with visual checkmark
- Professional About dialog with version information
- Clean exit with save confirmation

## Screenshots

### Main Interface - Dark Theme
![Notepad Main Interface](screenshots/main-interface.png)
*Modern dark theme with professional appearance and clean interface*

### Menu System
![Menu System](screenshots/menu-system.png)
*Organized menu system with File, Edit, Format, View, and Help options*

### About Dialog
![About Dialog](screenshots/about-dialog.png)
*Professional about dialog with version and copyright information*

### Word Wrap Feature
![Word Wrap](screenshots/word-wrap.png)
*Word wrap toggle with visual checkmark indicator*

## Requirements

- **Operating System**: Windows 7 or later
- **.NET Framework**: 4.7.2 or higher
- **Memory**: 50 MB RAM minimum
- **Disk Space**: 10 MB

## Installation

### Option 1: Download Release (Recommended)
1. Go to the [Releases](https://github.com/kallyas/Notepad/releases) page
2. Download the latest `Notepad-v{version}.zip` file
3. Extract the ZIP file to your preferred location
4. Run `Notepad.exe`

### Option 2: Build from Source
1. Clone the repository:
   ```bash
   git clone https://github.com/kallyas/Notepad.git
   cd Notepad
   ```

2. Open `Notepad.sln` in Visual Studio 2017 or later

3. Restore NuGet packages (if any)

4. Build the solution:
   - Press `F6` or go to `Build > Build Solution`
   - Or use command line:
     ```bash
     msbuild Notepad.sln /p:Configuration=Release
     ```

5. The executable will be in `Notepad/bin/Release/Notepad.exe`

## Usage

### Keyboard Shortcuts

| Action | Shortcut |
|--------|----------|
| New File | `Ctrl + N` |
| Open File | `Ctrl + O` |
| Save File | `Ctrl + S` |
| Exit | `Alt + F4` |
| Cut | `Ctrl + X` |
| Copy | `Ctrl + C` |
| Paste | `Ctrl + V` |
| Undo | `Ctrl + Z` |
| Redo | `Ctrl + Y` |
| Delete | `Del` |
| Zoom In | `Ctrl + +` |

### Tips
- Use **Format > Word Wrap** to enable/disable text wrapping
- The status bar shows real-time character count
- Use **View > Zoom** to adjust text size (increments of 10%)
- All unsaved changes prompt a confirmation dialog on exit

## Development

### Project Structure
```
Notepad/
├── Notepad/
│   ├── Form1.vb              # Main application logic
│   ├── Form1.Designer.vb     # UI designer code
│   ├── AboutDialog.vb        # About dialog
│   ├── AboutDialog.Designer.vb
│   ├── My Project/           # Assembly info and resources
│   └── Notepad.vbproj        # Project file
├── Notepad.sln               # Solution file
├── README.md                 # This file
└── .github/
    └── workflows/
        └── build-release.yml # CI/CD workflow

```

### Technologies Used
- **Language**: Visual Basic .NET
- **Framework**: .NET Framework 4.7.2
- **UI**: Windows Forms
- **IDE**: Visual Studio 2017+

### Color Palette
```vb
Menu Bar:       #2D2D30 (RGB: 45, 45, 48)
Form Background: #252526 (RGB: 37, 37, 38)
Editor Background: #1E1E1E (RGB: 30, 30, 30)
Editor Text:    #DCDCDC (RGB: 220, 220, 220)
Status Bar:     #007ACC (RGB: 0, 122, 204)
Menu Text:      White
```

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request. For major changes:

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## Changelog

### Version 2.0.0 (Current)
- ✨ Implemented modern dark theme UI
- 🐛 Fixed exit handler DialogResult bug
- 🐛 Fixed status bar toggle (removed web dependency)
- 🐛 Fixed default zoom (now 100% instead of 50%)
- 🐛 Fixed word wrap functionality
- ✨ Added Delete menu handler
- ✨ Enhanced About dialog with branding
- 🧹 Removed redundant scroll bars
- 🔒 Improved security by removing external dependencies
- 📝 Added comprehensive README

### Version 1.0.0
- Initial release with basic notepad functionality

## License

This project is licensed under the MIT License - see below for details:

```
MIT License

Copyright (c) 2024 Notepad Application

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```

## Support

If you encounter any issues or have questions:
- Open an issue on [GitHub Issues](https://github.com/kallyas/Notepad/issues)
- Check existing issues for solutions

## Acknowledgments

- Inspired by the classic Windows Notepad
- Dark theme colors based on Visual Studio Code's dark theme
- Built with ❤️ using Visual Basic .NET

---

**Note**: This is a desktop application for Windows. It requires .NET Framework 4.7.2 or higher to run.
