# SassBuilder

Simple wrapper of [libSassHost](https://github.com/Taritsyn/LibSassHost).
It will add a MSBuild target for `.scss/.sass` files in your Visual Studio projects.

All `.scss/.sass` files (exclude files in `.gitignore` if this is a git repository) under the
project folder will be compiled to `.css` file.

[DotNet 5.0](https://dotnet.microsoft.com/download/dotnet/5.0) is required. Works for
* Windows/x86
* Windows/x64
* Linux/x64
* OSX/x64

## Install

You can use it from nuget package: https://www.nuget.org/packages/SassBuilder
