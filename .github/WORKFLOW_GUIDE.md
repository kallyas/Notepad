# GitHub Actions Workflow Guide

This guide explains how to use the automated build and release workflow for the Notepad application.

## Workflow Overview

The workflow (`.github/workflows/build-release.yml`) automates:
- Building the application on Windows
- Running tests on pull requests
- Creating releases with packaged executables
- Following semantic versioning

## Trigger Events

### 1. Pull Requests
**When**: A pull request is opened or updated against `main` or `master` branch

**What Happens**:
- Builds the application in Debug mode
- Runs basic verification tests
- Uploads build artifacts (retained for 7 days)
- Reports build status on the PR

**Example**:
```bash
# Create a feature branch
git checkout -b feature/new-feature

# Make changes and commit
git commit -m "feat: Add new feature"

# Push to your fork
git push origin feature/new-feature

# Create a pull request on GitHub
```

### 2. Version Tags
**When**: A version tag matching `v*.*.*` is pushed

**What Happens**:
- Builds the application in Release mode
- Packages the executable with README
- Creates a ZIP file (e.g., `Notepad-v2.0.0.zip`)
- Creates a GitHub release
- Uploads the package to the release

**Example**:
```bash
# Create a version tag
git tag -a v2.0.0 -m "Release version 2.0.0"

# Push the tag to GitHub
git push origin v2.0.0

# The workflow will automatically create the release
```

### 3. Manual Trigger
**When**: Manually triggered from GitHub Actions UI

**What Happens**:
- Builds the application in Release mode
- Uploads build artifacts (retained for 7 days)

**Steps**:
1. Go to GitHub repository
2. Click on "Actions" tab
3. Select "Build and Release" workflow
4. Click "Run workflow"
5. Select branch and click "Run workflow"

## Creating a Release

### Step-by-Step Process

1. **Update Version Number**
   - Edit `Notepad/AboutDialog.vb` and update the version string
   - Edit `README.md` and update the version badge and changelog

2. **Commit Changes**
   ```bash
   git add .
   git commit -m "chore: Bump version to 2.1.0"
   git push origin main
   ```

3. **Create Git Tag**
   ```bash
   # Use semantic versioning: vMAJOR.MINOR.PATCH
   git tag -a v2.1.0 -m "Release version 2.1.0 - Description of changes"
   ```

4. **Push Tag**
   ```bash
   git push origin v2.1.0
   ```

5. **Monitor Workflow**
   - Go to GitHub Actions tab
   - Watch the "Build and Release" workflow run
   - Check for any errors

6. **Verify Release**
   - Go to the Releases page
   - Verify the new release appears
   - Download and test the package

## Semantic Versioning

Follow these rules for version numbers:

### Major Version (X.0.0)
Increment for breaking changes:
- Major UI redesign that changes behavior
- Removal of features
- Changes that break backward compatibility

**Example**: v1.0.0 → v2.0.0

### Minor Version (0.X.0)
Increment for new features (backward compatible):
- Adding find/replace
- Adding new menu items
- Adding keyboard shortcuts
- New export formats

**Example**: v2.0.0 → v2.1.0

### Patch Version (0.0.X)
Increment for bug fixes and minor changes:
- Fixing crashes
- Fixing UI glitches
- Performance improvements
- Security patches

**Example**: v2.1.0 → v2.1.1

## Workflow Jobs

### Build Job
- **Runs on**: Windows (latest)
- **Purpose**: Build the application
- **Steps**:
  1. Checkout code
  2. Setup MSBuild and NuGet
  3. Restore NuGet packages
  4. Build solution (Debug or Release)
  5. Package release (if tag)
  6. Upload artifacts

### Release Job
- **Runs on**: Windows (latest)
- **Purpose**: Create GitHub release
- **Condition**: Only runs on version tags
- **Steps**:
  1. Checkout code
  2. Download build artifacts
  3. Extract version from tag
  4. Generate release notes
  5. Create GitHub release
  6. Upload package to release

### Test Job
- **Runs on**: Windows (latest)
- **Purpose**: Verify build works
- **Condition**: Only runs on pull requests
- **Steps**:
  1. Checkout code
  2. Setup MSBuild and NuGet
  3. Build in Debug mode
  4. Verify executable exists

## Build Artifacts

### Regular Builds
- **Location**: Build artifacts tab in workflow run
- **Retention**: 7 days
- **Contents**: All files from `Notepad/bin/Release/`

### Release Packages
- **Location**: GitHub Releases page
- **Retention**: 90 days (as artifacts), permanent (in release)
- **Contents**: 
  - `Notepad.exe`
  - `Notepad.exe.config`
  - `README.md`

## Troubleshooting

### Build Fails
1. Check the workflow logs in GitHub Actions
2. Verify the solution builds locally in Visual Studio
3. Ensure all required dependencies are available
4. Check for compilation errors in the logs

### Release Not Created
1. Verify the tag matches the pattern `v*.*.*`
2. Check if the workflow was triggered (Actions tab)
3. Look for errors in the release job logs
4. Verify you have write permissions to create releases

### Package Missing Files
1. Check the packaging step in the workflow
2. Verify files exist in the build output
3. Update the workflow to include additional files if needed

## Customizing the Workflow

### Adding More Files to Package
Edit the "Package Release" step in `.github/workflows/build-release.yml`:

```yaml
# Copy additional files
Copy-Item "$outputDir\MyFile.dll" "release\$packageName\"
Copy-Item "LICENSE.txt" "release\$packageName\"
```

### Changing Build Configuration
Modify the MSBuild parameters:

```yaml
# Add custom properties
run: msbuild ${{ env.SOLUTION_PATH }} /p:Configuration=Release /p:CustomProperty=Value
```

### Adding Tests
Add a test step before packaging:

```yaml
- name: Run Tests
  run: |
    # Run your test command here
    dotnet test YourTestProject.csproj
```

## Best Practices

1. **Test Before Tagging**: Always test the build locally before creating a release tag
2. **Write Good Release Notes**: Update the changelog in README.md
3. **Use Descriptive Tag Messages**: Include a summary of changes in the tag message
4. **Monitor Workflows**: Check the Actions tab after pushing tags
5. **Keep Versions Consistent**: Update version in code and documentation together

## Example Release Workflow

```bash
# 1. Make changes on a feature branch
git checkout -b feature/find-replace
# ... make changes ...
git commit -m "feat: Add find and replace functionality"
git push origin feature/find-replace

# 2. Create pull request
# ... create PR on GitHub ...
# ... wait for automated build to pass ...
# ... get code review ...
# ... merge PR ...

# 3. Update version for release
git checkout main
git pull origin main
# Edit AboutDialog.vb and README.md
git commit -m "chore: Bump version to 2.1.0"
git push origin main

# 4. Create release
git tag -a v2.1.0 -m "Release v2.1.0: Add find and replace functionality"
git push origin v2.1.0

# 5. Wait for workflow to complete and verify release
```

## Getting Help

If you encounter issues with the workflow:
1. Check the [GitHub Actions documentation](https://docs.github.com/en/actions)
2. Review the workflow logs for error messages
3. Open an issue on the repository with:
   - Workflow run URL
   - Error messages
   - What you were trying to do
