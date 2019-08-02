#!/usr/bin/env bash

# dotnet publish -c Release -r linux-x64
~/warp-packer --arch linux-x64 --input_dir Selstam.VoC/bin/Release/netcoreapp2.1/linux-x64/publish --exec Selstam.VoC --output voc
chmod +x voc

