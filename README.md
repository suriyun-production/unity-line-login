# unity-line-login

This is LINE sdk implementation for Unity3d

Now it's support just Android, for iOS coming soon...

## How to build Unity project

I've prepared the example project, The folder `/UnityLinePluginProject`

Before you start, I've set it LINE library into it you can download it following LINE's instruction. 

After downloaded extract it you'll see file named likes `line-android-sdk-x.x.xx.jar` Copy it to `/UnityLinePluginProject/Assets/UnityLinePlugin/Plugins/Android/` 

Then copy folder `armeabi-v7a` and `x86` inside folder `libs` to `/UnityLinePluginProject/Assets/UnityLinePlugin/Plugins/Android/libs`

Then go to `/UnityLinePluginProject/Assets/Plugins/Android/` you'll see file `AndroidManifest.xml` open it to changes an channel id about channel id you can see its detail in LINE's document.

Then open folder `/UnityLinePluginProject` with Unity3d to build.

## How to build Android .jar library

Copy file `line-android-sdk-x.x.xx.jar` to `/AndroidPluginProject/LineUnity/libs/`

Then import `/AndroidPluginProject/LineUnity` with Eclipse to build.
