# Semantic Versioning Guide

This project follows [Semantic Versioning 2.0.0](https://semver.org/).

## Version Format

Versions are formatted as: `MAJOR.MINOR.PATCH`

- **MAJOR** version: Incremented for incompatible API changes
- **MINOR** version: Incremented for backwards-compatible new features
- **PATCH** version: Incremented for backwards-compatible bug fixes

## Current Version

**v2.0.0** - Major UI redesign with dark theme and bug fixes

## Release Process

### 1. Update Version

Before creating a release, update the version number in:
- `AboutDialog.vb` - Update the version display
- `README.md` - Update the version badge and changelog

### 2. Create a Git Tag

```bash
# For a new major release (breaking changes)
git tag -a v3.0.0 -m "Release version 3.0.0"

# For a new minor release (new features)
git tag -a v2.1.0 -m "Release version 2.1.0"

# For a patch release (bug fixes)
git tag -a v2.0.1 -m "Release version 2.0.1"
```

### 3. Push the Tag

```bash
git push origin v2.0.0
```

This will automatically trigger the GitHub Actions workflow to:
1. Build the application on Windows
2. Create a release package (ZIP file)
3. Create a GitHub release with the package attached

## Versioning Examples

### Major Release (3.0.0)
Breaking changes that affect how users interact with the application:
- Complete UI redesign that changes the layout
- Removal of existing features
- Changes to file format that break backward compatibility

### Minor Release (2.1.0)
New features that don't break existing functionality:
- Adding find/replace functionality
- Adding new menu items
- Adding keyboard shortcuts
- Adding new export formats

### Patch Release (2.0.1)
Bug fixes and minor improvements:
- Fixing crashes
- Fixing UI glitches
- Performance improvements
- Security patches

## Version History

### v2.0.0 (2024-10-19)
- ✨ Major UI redesign with dark theme
- 🐛 Fixed exit handler bug
- 🐛 Fixed status bar toggle
- 🐛 Fixed word wrap functionality
- 🐛 Fixed default zoom level
- ✨ Enhanced About dialog
- 🧹 Removed redundant controls
- 🔒 Improved security

### v1.0.0 (Initial)
- 📝 Basic notepad functionality
- 📂 File operations (New, Open, Save)
- ✂️ Edit operations (Cut, Copy, Paste, Undo, Redo)
- 🎨 Format options (Font, Word Wrap)
- 🔍 View options (Zoom, Status Bar)

## Automated Release

The GitHub Actions workflow (`.github/workflows/build-release.yml`) handles:

1. **On Pull Request**: 
   - Builds in Debug mode
   - Runs basic verification tests
   - Uploads build artifacts

2. **On Tag Push (v*.*.*)**: 
   - Builds in Release mode
   - Packages the application
   - Creates a GitHub release
   - Uploads the ZIP package

## Manual Release Checklist

If you need to create a release manually:

- [ ] Update version in AboutDialog.vb
- [ ] Update version badge in README.md
- [ ] Update changelog in README.md
- [ ] Commit changes: `git commit -m "Bump version to x.y.z"`
- [ ] Create tag: `git tag -a vx.y.z -m "Release version x.y.z"`
- [ ] Push commits: `git push origin main`
- [ ] Push tag: `git push origin vx.y.z`
- [ ] Wait for GitHub Actions to complete
- [ ] Verify release on GitHub Releases page
- [ ] Test the release package

## Notes

- Always use the `v` prefix for version tags (e.g., `v2.0.0`, not `2.0.0`)
- The workflow only triggers on tags matching the pattern `v*.*.*`
- Release packages include the executable, config file, and README
- Build artifacts are retained for 7 days for regular builds
- Release packages are retained for 90 days
