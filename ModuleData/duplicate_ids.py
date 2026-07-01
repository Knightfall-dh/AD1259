import os
import re
from collections import defaultdict

root = os.path.dirname(os.path.abspath(__file__))
output_path = os.path.join(root, "duplicate_ids.txt")

pattern = re.compile(r"\{=([A-Za-z0-9_:-]+)\}")

counts = defaultdict(list)

for dirpath, _, filenames in os.walk(root):
    for filename in filenames:
        if not filename.lower().endswith(".xml"):
            continue

        path = os.path.join(dirpath, filename)
        try:
            with open(path, "r", encoding="utf-8-sig") as f:
                for lineno, line in enumerate(f, 1):
                    for match in pattern.finditer(line):
                        token = match.group(1)
                        counts[token].append((path, lineno))
        except Exception:
            continue

dupes = [(token, entries) for token, entries in sorted(counts.items()) if len(entries) > 1]

with open(output_path, "w", encoding="utf-8") as out:
    if not dupes:
        out.write("No duplicate translation IDs found.\n")
    else:
        for token, entries in dupes:
            out.write(f"{token} appears {len(entries)} times\n")
            for path, lineno in entries:
                rel_path = os.path.relpath(path, root).replace("\\", "/")
                out.write(f"  {rel_path}:{lineno}\n")
            out.write("\n")

print(f"Report written to: {output_path}")