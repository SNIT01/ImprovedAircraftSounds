# ImprovedAircraftSounds (Audio Switcher Module)

`ImprovedAircraftSounds` is a module for the Cities: Skylines II Audio Switcher mod.  
It ships custom aircraft engine clips and metadata so Audio Switcher can discover and apply them in game with custom values.

This is intended to be an example of an Audio Switcher module.

## Links

- Audio Switcher GitHub: https://github.com/SNIT01/CS2-Audio-Switcher
- Audio Switcher on PDX Mods: https://mods.paradoxplaza.com/mods/135367/Windows
- ImprovedAircraftSounds on PDX Mods: https://mods.paradoxplaza.com/mods/135438/Windows

## How Audio Switcher Modules Work

Audio Switcher modules are regular CS2 code mods that include:

- A minimal code entry point (`Mod.cs`) so the mod can load.
- A module manifest file named `AudioSwitcherModule.json` (also used by Audio Switcher for discovery).
- Audio assets referenced by that manifest (for example `Audio/Engines/*.ogg` or `Audio/Engines/*.wav`).

Audio Switcher scans installed mods for `AudioSwitcherModule.json`, reads the entries, and exposes the sounds in its UI (for example in the Vehicle Engines tab).

In this repository:

- `ImprovedAircraftSounds/AudioSwitcherModule.json` defines the module and sound entries.
- `ImprovedAircraftSounds/Audio/` stores the actual audio files.
- `ImprovedAircraftSounds/ImprovedAircraftSounds.csproj` marks both manifest and audio as content copied to output:
  - `AudioSwitcherModule.json`
  - `Audio/**/*.*`

## Manifest Structure

Current manifest categories are:

- `sirens`
- `vehicleEngines`
- `ambient`

Each audio entry typically includes:

- `key`: stable unique id for the sound in this module.
- `displayName`: user-visible name in Audio Switcher.
- `file`: relative path to the audio asset inside the mod output.
- `profile`: playback settings (volume, pitch, spatial blend, doppler, distances, looping, fade, etc.).

Example:

```json
{
  "schemaVersion": 1,
  "moduleId": "improvedaircraftsounds",
  "displayName": "ImprovedAircraftSounds",
  "vehicleEngines": [
    {
      "key": "Bell Heli Engine.ogg",
      "displayName": "Bell Heli Engine",
      "file": "Audio/Engines/Bell Heli Engine.ogg",
      "profile": {
        "Volume": 0.7,
        "Pitch": 1.0,
        "SpatialBlend": 1.0,
        "Doppler": 0.1,
        "Spread": 220,
        "MinDistance": 150,
        "MaxDistance": 250,
        "Loop": true
      }
    }
  ]
}
```

## How To Create a New Module

1. Add .wav or .ogg files to the custom audio folders where you have the mod installed.

2. Rescan custom files for each type you've added.

3. Generate your module content.
   - Use the Developer tab module builder to export selected local audio into a standalone module folder.
   - The export includes:
     - `AudioSwitcherModule.json`
     - `Audio/Sirens/...`
     - `Audio/Engines/...`
     - `Audio/Ambient/...`
4. Create a new CS2 mod project.

5. Add a minimal `Mod.cs` implementing `IMod`.

6. Copy your module files into that project including:
   - `AudioSwitcherModule.json`.
   - The `Audio` folder including your custom audio.

7. Ensure manifest/audio files are copied to output by adding:

```xml
<ItemGroup>
  <Content Include="AudioSwitcherModule.json" CopyToOutputDirectory="PreserveNewest" />
  <Content Include="Audio\**\*.*" CopyToOutputDirectory="PreserveNewest" />
</ItemGroup>
```
8. Build and publish the module mod. Ensure you keep the mod ID the publisher provides to you.

9. Validate after upload.
   - Check your PDX Mods listing metadata and media.
   - Subscribe and test in-game to confirm Audio Switcher discovers the module.

## Notes

- Use consistent loudness and sensible profile distance/fade settings to prevent clipping or abrupt transitions.
- You can base your profile on an existing profile but it is highly recommended that you adjust and test this.
- Set Audio Switcher as a dependency in publish config (Dependency Id `135367`), as shown in this project.
