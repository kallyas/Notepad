# Contributing to Notepad

Thank you for your interest in contributing to the Notepad project! This document provides guidelines and instructions for contributing.

## How to Contribute

### Reporting Bugs

If you find a bug, please create an issue on GitHub with:
- A clear, descriptive title
- Steps to reproduce the issue
- Expected behavior
- Actual behavior
- Screenshots (if applicable)
- Your environment (Windows version, .NET Framework version)

### Suggesting Enhancements

We welcome feature suggestions! Please create an issue with:
- A clear, descriptive title
- Detailed description of the proposed feature
- Why this feature would be useful
- Any examples or mockups (if applicable)

### Pull Requests

1. **Fork the Repository**
   ```bash
   # Fork via GitHub UI, then clone your fork
   git clone https://github.com/YOUR_USERNAME/Notepad.git
   cd Notepad
   ```

2. **Create a Branch**
   ```bash
   git checkout -b feature/your-feature-name
   # or
   git checkout -b bugfix/issue-description
   ```

3. **Make Your Changes**
   - Follow the existing code style
   - Keep changes focused and minimal
   - Test your changes thoroughly
   - Update documentation if needed

4. **Test Your Changes**
   - Build the solution in both Debug and Release modes
   - Test all affected functionality
   - Ensure no existing features are broken

5. **Commit Your Changes**
   ```bash
   git add .
   git commit -m "feat: Add new feature" # or "fix: Fix bug description"
   ```

6. **Push to Your Fork**
   ```bash
   git push origin feature/your-feature-name
   ```

7. **Create a Pull Request**
   - Go to the original repository on GitHub
   - Click "New Pull Request"
   - Select your branch
   - Fill out the PR template with details

## Development Setup

### Requirements
- Windows 7 or later
- Visual Studio 2017 or later (Community edition is fine)
- .NET Framework 4.7.2 SDK

### Building
1. Open `Notepad.sln` in Visual Studio
2. Press `F6` or go to `Build > Build Solution`
3. The executable will be in `Notepad/bin/Debug/` or `Notepad/bin/Release/`

### Code Style Guidelines

#### Visual Basic .NET
- Use meaningful variable names
- Add comments for complex logic
- Keep methods focused and small
- Follow existing indentation (4 spaces)
- Use proper capitalization for VB.NET keywords

#### Example:
```vb
Private Sub SaveFile()
    ' Show save dialog to user
    Using sfd As New SaveFileDialog
        sfd.Filter = "All Files (*.*)|*.*"
        If sfd.ShowDialog() = DialogResult.OK Then
            ' Save file content
            File.WriteAllText(sfd.FileName, RichTextBox1.Text)
        End If
    End Using
End Sub
```

## Commit Message Guidelines

Use conventional commit format:

- `feat:` New feature
- `fix:` Bug fix
- `docs:` Documentation changes
- `style:` Code style changes (formatting, etc.)
- `refactor:` Code refactoring
- `test:` Adding tests
- `chore:` Maintenance tasks

Examples:
```
feat: Add find and replace functionality
fix: Correct word wrap toggle behavior
docs: Update README with new screenshots
style: Format code according to guidelines
refactor: Simplify file saving logic
```

## Areas for Contribution

### High Priority
- [ ] Find and Replace functionality
- [ ] Print support
- [ ] Recent files list
- [ ] Customizable themes
- [ ] Line numbers display

### Medium Priority
- [ ] Syntax highlighting for common languages
- [ ] Tab support for multiple documents
- [ ] Auto-save functionality
- [ ] Go to line number
- [ ] Statistics (word count, line count)

### Low Priority
- [ ] Spell checker
- [ ] Markdown preview
- [ ] Plugin system
- [ ] Macro recording

## Testing

Before submitting a PR, please test:
1. Build in Debug mode - verify no errors
2. Build in Release mode - verify no errors
3. Test all menu items work correctly
4. Test keyboard shortcuts
5. Test file operations (New, Open, Save)
6. Test edit operations (Cut, Copy, Paste, Undo, Redo)
7. Test view options (Zoom, Status Bar, Word Wrap)
8. Test with various file sizes (small, medium, large)

## Questions?

If you have questions about contributing:
- Check existing issues and discussions
- Create a new issue with the "question" label
- Be patient - maintainers are volunteers

## Code of Conduct

### Our Pledge
We are committed to providing a welcoming and inspiring community for all.

### Our Standards
- Be respectful and inclusive
- Welcome diverse perspectives
- Focus on what's best for the community
- Show empathy towards others

### Unacceptable Behavior
- Harassment or discriminatory language
- Personal attacks
- Trolling or insulting comments
- Publishing others' private information

## License

By contributing to this project, you agree that your contributions will be licensed under the MIT License.

---

Thank you for contributing to make Notepad better! 🎉
