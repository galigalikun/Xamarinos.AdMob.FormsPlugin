# Xamarinos.AdMob.FormsPlugin
AdMob Plugin for Xamarin.Forms

##Setup

###iOS

In your AppDelegate.cs add the following lines:

```
//Register AdBanner Control Renderer
AdBannerRenderer.Init ();

//Initialize Interstitial Manager with a Specific AdMob Key
CrossAdmobManager.Init (Strings.AdMobKey);
```

### Android

In your MainActivity.cs on the "OnCreate" Method add the following lines:

```
//Register AdBanner Control Renderer
AdBannerRenderer.Init ();

//Initialize Interstitial Manager with a Specific AdMob Key
CrossAdmobManager.Init (Strings.AdMobKey);
```

##Usage

###Banner Control

```
var myBanner = new AdBanner();

//Set Your AdMob Key
myBanner.AdID = Strings.AdMobKey;
```

###Interstitial

```
await CrossAdmobManager.Current.Show ();
```
