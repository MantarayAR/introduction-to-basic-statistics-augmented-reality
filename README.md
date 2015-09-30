Mantaray AR
===========

# Introduction to Probability and Statistics


This application is a Unity Project that utilizes Vuforia for Augmented Reality.

# Unity

The Unity aspect of the project is written in C#.  Originally, the project was a bundle of Javascript and C# files,
but we ported over to C# as we found it to be the more robust language.

THe source of the project is made to be flexible and reuseable.  The base files should be able to be used for many different lessons.

The C# source is in the /Assets/src folder and is split up into:

* Custom - Files that are dependent on the lesson being taught.  These are static classes that are the same as those that would be loaded in
when using the dynamic version of the application (Mantaray AR: Unlimited).
* GameObjectScript - In Unity, scripts need to be attached to Game Objects.  These are the entry points for our app.
* GUI - Base classes for better GUI functions.  Trust me, you do not want to use the default stuff, it is a nightmare to deal with when you
actually start making complicated GUIs.
- Models - Application models ( not 3D models ).
- Slides - Basic slide logic.
- Util - Game utility classes.  These are really Helpers in disguise.

# Images

Process for getting images for the AR targetting goes something like this:

1. Find high quality images that are free to use (I recommend [Unsplash](http://unsplash.com)). Images must have a lot of "features" (this is the image analysis use of the word).
2. Take the high quality image and shrink it by a factor of 1/2. This will normally half the file size from 10MB to around 4-5MB.
3. Now that the image is under 5MB, throw it into [TinyPNG](http://tinypng.com). The image should now be around 400KB, but anything under 2MB will do.
4. Now that the image is under 2MB, upload the image to an image database in Vuforia.
