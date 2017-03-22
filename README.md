# unity-line-login

This is LINE sdk implementation for Unity3d

Now it's support just Android, for iOS coming soon...

## Support features

* Login/Logout
* Get Profile
* Manage access token

Seem like another features have to implement at backend side

## How to build Unity project

I've prepared the example project, The folder `/UnityLinePluginProject`

Before you start, I've set it LINE library into it you can download it following LINE's instruction. 

Then open folder `/UnityLinePluginProject` with Unity3d to build.

## How to build Android .jar library

* It's require `Android Studio` and `LINE SDK`
* Open project at `./AndroidProject/LineUnity/`
* Simply build by Menu Build -> Rebuild
* After built new .aar file will be created at `./AndroidProject/LineUnity/app/build/outputs/aar` copy it to your Unity's Assets/Plugins/Android and Remove old .aar file (For this repo its named as `line-plugin.aar`)
