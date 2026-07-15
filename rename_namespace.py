from pathlib import Path

root = Path("/home/spectjumm/.local/share/Terraria/tModLoader/ModSources/ShadowlightMod")
old = "ShadowlightMod"
new = "ShadowlightMod"

excluded_dirs = {".git", ".vs", "bin", "obj"}

changed_files = []

for path in root.rglob("*"):
    if not path.is_file():
        continue

    rel = path.relative_to(root).as_posix()
    parts = path.relative_to(root).parts

    if any(part in excluded_dirs for part in parts):
        continue

    # Skip the excluded boss folder
    if rel.startswith("NPCs/Bosses/ShadowlightMod/") or rel == "NPCs/Bosses/ShadowlightMod":
        continue

    try:
        raw = path.read_bytes()
    except Exception:
        continue

    if b"\x00" in raw:
        continue

    try:
        text = raw.decode("utf-8")
    except UnicodeDecodeError:
        continue

    if old not in text:
        continue

    updated = text.replace(old, new)
    if updated != text:
        path.write_text(updated, encoding="utf-8")
        changed_files.append(rel)

print(f"Updated {len(changed_files)} file(s):")
for rel in changed_files:
    print(rel)