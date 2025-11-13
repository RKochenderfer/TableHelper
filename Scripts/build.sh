#!/bin/bash
set -euo pipefail

echo "Building image"
cd "$(dirname "$0")" || exit

cd ../

# prefer known path, fall back to find
csproj="TableHelper.Api/TableHelper.Api.csproj"
if [[ ! -f "$csproj" ]]; then
  csproj=$(find . -maxdepth 4 -type f -iname "TableHelper.Api.csproj" -print -quit)
fi

version=""

if [[ -n "$csproj" && -f "$csproj" ]]; then
  # extract <Version> content and trim whitespace/CR
  version=$(sed -n 's:.*<AssemblyVersion>\(.*\)</AssemblyVersion>.*:\1:p' "$csproj" | tr -d ' \r\n' | head -n1 || true)
fi

echo "Using image tag: $version"
docker build -t "ghcr.io/rkochenderfer/tablehelper:${version}" . --load