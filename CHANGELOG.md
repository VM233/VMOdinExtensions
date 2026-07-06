# Changelog

All notable changes to this package are documented here.

## [1.0.0] - 2026-07-06

### Added

- Created `com.vm233.vm-odin-extensions` as a Unity Package Manager Git package.
- Added Odin Inspector attributes, drawers, validation helpers, value dropdowns, and value drawers previously maintained inside MarbleBattlers.
- Added package metadata through `package.json`.

### Changed

- `SceneDrawer` now displays scene handles as text so both legacy `int` handles and Unity 6000.5 `ulong` raw handles are represented safely.

### Fixed

- Fixed Unity 6000.5 compilation compatibility for `SceneHandle`; `SceneHandle.GetRawData()` is used on Unity 6000.5 or newer, while older Unity versions keep the legacy `scene.handle` path.

