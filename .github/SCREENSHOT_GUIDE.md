# Screenshot Guide

This guide explains how to capture and add screenshots for the Notepad application.

## Required Screenshots

The README.md references four screenshots that should be added:

1. **main-interface.png** - Main application window
2. **menu-system.png** - Menu system with opened menus
3. **about-dialog.png** - About dialog
4. **word-wrap.png** - Word wrap feature demonstration

## How to Take Screenshots

### Prerequisites
- Windows computer with .NET Framework 4.7.2 or higher
- Built Notepad.exe application
- Screenshot tool (Windows Snipping Tool, Snip & Sketch, or third-party)

### Steps

#### 1. Build the Application
```bash
# In Visual Studio
1. Open Notepad.sln
2. Select "Release" configuration
3. Build > Build Solution
4. Navigate to Notepad/bin/Release/
5. Run Notepad.exe
```

#### 2. Main Interface Screenshot
1. Launch Notepad.exe
2. Type some sample text (e.g., "This is a modern notepad application with dark theme")
3. Ensure the status bar is visible (View > Status Bar)
4. Capture the full window
5. Save as `screenshots/main-interface.png`

**Tips**:
- Use a clean desktop background
- Show the window at a reasonable size (not too small)
- Include the menu bar, text area, and status bar
- Text should be visible to show the dark theme

#### 3. Menu System Screenshot
1. Keep the application open
2. Click on "File" menu to open it
3. Capture the window with the menu open
4. Save as `screenshots/menu-system.png`

**Alternative**: Create a composite showing multiple menus
- Take screenshots of File, Edit, Format, View, and Help menus
- Use an image editor to combine them

#### 4. About Dialog Screenshot
1. In Notepad, click Help > About Notepad
2. The About dialog will appear
3. Capture just the dialog window
4. Save as `screenshots/about-dialog.png`

**Tips**:
- Center the dialog before capturing
- Ensure all text is readable
- Show the full dialog including the OK button

#### 5. Word Wrap Screenshot
1. Type a long line of text that extends beyond the window
2. Go to Format > Word Wrap (should show a checkmark)
3. The text should wrap to fit the window
4. Capture the window showing wrapped text with the checkmark
5. Save as `screenshots/word-wrap.png`

**Tips**:
- Show the Format menu open with Word Wrap checked
- Or show before/after comparison

## Screenshot Specifications

### Format
- **File Format**: PNG (preferred) or JPG
- **Color Mode**: RGB
- **Compression**: Moderate (balance quality and file size)

### Dimensions
- **Width**: 800-1200 pixels (recommended)
- **Aspect Ratio**: Maintain original window proportions
- **DPI**: 96 or higher

### Quality
- Clear and sharp text
- No blurry elements
- Proper focus on the application
- Good contrast and visibility

## Tools for Screenshots

### Windows Built-in
1. **Snipping Tool** (Windows 7-10)
   - Press Win + Shift + S
   - Select area to capture
   - Edit and save

2. **Snip & Sketch** (Windows 10+)
   - Press Win + Shift + S
   - More editing options
   - Direct save to file

3. **Print Screen**
   - Press PrtScn for full screen
   - Press Alt + PrtScn for active window
   - Paste in Paint and save

### Third-Party Tools
- **ShareX** - Free, powerful screenshot tool
- **Greenshot** - Free, open-source
- **Lightshot** - Simple and quick
- **Snagit** - Professional (paid)

## Editing Screenshots

### Recommended Edits
- Crop to show relevant area
- Add subtle shadow for depth (optional)
- Resize if too large (max width: 1200px)
- Optimize file size

### Tools for Editing
- **Paint** (Windows built-in)
- **Paint.NET** (Free)
- **GIMP** (Free, open-source)
- **Photoshop** (Professional, paid)

## Adding Screenshots to Repository

### Method 1: Using Git
```bash
# Add screenshots
git add screenshots/*.png

# Commit
git commit -m "docs: Add application screenshots"

# Push
git push origin main
```

### Method 2: Using GitHub Web Interface
1. Navigate to the `screenshots/` folder on GitHub
2. Click "Add file" > "Upload files"
3. Drag and drop your screenshot files
4. Commit changes

## File Naming Convention

Use descriptive, lowercase names with hyphens:
- ✅ `main-interface.png`
- ✅ `menu-system.png`
- ✅ `about-dialog.png`
- ✅ `word-wrap.png`
- ❌ `Screenshot1.png`
- ❌ `Notepad Screenshot.PNG`

## Size Optimization

Before committing, optimize file sizes:

### Using Online Tools
- [TinyPNG](https://tinypng.com/) - PNG compression
- [Compress PNG](https://compresspng.com/) - PNG compression
- [ImageOptim](https://imageoptim.com/) - Multiple formats (Mac)

### Using Command Line
```bash
# Using ImageMagick
convert main-interface.png -resize 1200x -quality 90 main-interface-optimized.png

# Using optipng
optipng -o5 main-interface.png
```

## Preview Locally

Before pushing, preview how screenshots appear in README:

1. Open README.md in a Markdown preview tool
2. Or push to a test branch and view on GitHub
3. Verify images load correctly
4. Check if sizes are appropriate

## Additional Tips

### Best Practices
- Take screenshots in a clean environment
- Use consistent window sizes
- Ensure good lighting/contrast
- Capture at native resolution
- Don't include sensitive information

### Common Mistakes to Avoid
- Screenshots too small (unreadable)
- Screenshots too large (slow to load)
- Blurry or low quality
- Inconsistent styling across screenshots
- Including personal desktop items

### Accessibility
- Ensure text is readable at thumbnail size
- Use high contrast
- Consider adding alt text in README
- Provide text descriptions of key features

## Updating Screenshots

When the UI changes significantly:
1. Retake affected screenshots
2. Use same naming convention
3. Maintain consistent style
4. Update commit with: `docs: Update screenshots for v2.1.0`

## Example Alt Text for README

```markdown
![Notepad Main Interface](screenshots/main-interface.png)
*Main interface showing the modern dark theme, menu bar, text editor, and status bar displaying character count*
```

## Questions?

If you have questions about screenshots:
- Check this guide first
- Look at existing screenshots in similar projects
- Ask in an issue or pull request
