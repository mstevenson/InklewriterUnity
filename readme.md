InklewriterUnity
================

**InklewriterUnity** is library for parsing [inklewriter](https://writer.inklestudios.com) story files and displaying them through the Unity game engine. The project is built around InklewriterSharp, an unofficial C# reimplementation of [inkle studios'](http://www.inklestudios.com) interactive story system.

Instructions
------------

1. Write a story with [inklewriter](https://writer.inklestudios.com).
2. Generate a share link for your story and append *.json* to the end of its URL.
3. Download the story's json file and place it in your Unity project's _Resources_ folder.
4. Place all illustration images into your project's _Resources_ folder.
5. Drop the Inklewriter Story Player prefab into your scene. Set "Story Name" in the inspector to match the name of your story's json file (without its file extension).

License
-------

The InkleSharp source code is licensed under the MIT License. Inkle story files may be used commercially with a credit to inkle studios.