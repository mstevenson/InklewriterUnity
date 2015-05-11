InklewriterUnity
================

**InklewriterUnity** is library for parsing and displaying [inklewriter](https://writer.inklestudios.com) story files through the Unity game engine. The project is built around [InklewriterSharp](https://github.com/mstevenson/InklewriterSharp), an unofficial C# reimplementation of [inkle studios'](http://www.inklestudios.com) interactive story system.

Instructions
------------

1. Create a new Unity project and copy the InklewriterUnity repository into the the project's Assets folder.
2. Write a story with [inklewriter](https://writer.inklestudios.com).
3. Generate a share link for your story and append *.json* to the end of its URL.
4. Download your story json file and place it in a [_Resources_ folder](http://docs.unity3d.com/Manual/LoadingResourcesatRuntime.html) within your Unity project.
5. Copy all illustration images into your project's _Resources_ folder.
6. Instantiate the Inklewriter Story Player prefab into your scene. In the inspector, set Story Player's "Story Name" inspector value to the name of your story json file, excluding the _.json_ file extension.
7. Enter play mode. Your story will be shown in a UI very similar to the inklewriter web player. You may modify this prefab to suit your game's graphical style, or build your own custom UI widgets using standard Unity 5 UI components.

License
-------

The InklewriterUnity source code is licensed under the MIT License. Inkle story files may be used commercially with a credit to inkle studios.