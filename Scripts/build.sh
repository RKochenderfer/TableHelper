#!/bin/bash
echo "Building image"
cd "$(dirname $0)" || exit

cd ../
docker build -t ghcr.io/rkochenderfer/tablehelper:latest . --load
 