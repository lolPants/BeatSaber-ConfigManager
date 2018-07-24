# Beat Saber Config Manager
A way for modders to standardise their mod config.

## For Users
Install the mod like you would any other mod. Download the [latest release](https://github.com/lolPants/BeatSaber-ConfigManager/releases) and extract to your `BeatSaber` game directory.

## For Modders
Import the DLL like you would any other reference. If you don't know how to do this then you should probably learn the basics of modding first.

### Example Usage
```csharp
// Reference the Library Namespace
using BeatSaberConfigManager;
```

Instantiate a settings object. The name parameter can be any identifier for your plugin.  
Any clashes should be avoided as you will then be able to read/write other plugins' config.  
The plugin name will be sanitesd to PascalCase with no spaces. Any illegal file path characters will also be stripped.

```csharp
ConfigManager config = new ConfigManager("PluginName");
```

#### Sub-Key Support
If you want to move some config keys to another namespace *(ie: if you have lots of config options and want to group them)* then you can create a `KeyManager`. The interface for getting and setting values is the same.

```csharp
// Make sure you have a base ConfigManager
ConfigManager config = new ConfigManager("PluginName");

// Define a new KeyManager parented to the config ConfigManager
KeyManager sub = config.CreateSubKey("SubKey");
```

#### Getting a Value
Parameters are in the form `key`, `defaultValue`, `overwrite`  
If the value at `key` is of the wrong type, or does not exist it will return `defaultValue`.  
`overwrite` is optional. When `true` it will save the default value to config.

```csharp
// Example
bool enabled = config.Get("enabled", true, true);
```

#### Setting a Value
Parameters are in the form `key`, `value`, `comment`  
`comment` is optional. If set, it will include a comment line above the key. This can be used to explain what the config value represents.

```csharp
// Example
config.Set("apikey", "", "BeatSaver API Key");
```

### Supported Data Types:
Currently only a few data types can be saved/loaded. These are as follows. You can also encode `IEnumerable<T>` of any type listed.

* `bool`
* `string`
* `int`
* `float`
* `double`
* `long`

### Caveats
Currently you can encode `IEnumerable<T>` of any of the above types. But you can only decode to `List<T>` of that type. This is because Arrays have a fixed length and there is no way for the parser to know the length beforehand.
