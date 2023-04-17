# SystemRenamer
renames systems

**v1.1.0.0 and higher requires modtek v3 or higher**

```
"Settings": {
		"RenamerConfigs": {
			"pirate_lord": {
				"TargetSystem": "starsystemdef_RezaksHole",
				"RenamerName": "{Commander.Callsign}'s Hole"
			}
		}
	},
```

`RenamerConfigs` - Dictionary of <string, RenamerConfig> dictating what/when/how systems are renamed. Key is the "trigger" tag for a system to be renamed. If company tags have this key, the system defined by `TargetSystem` will be renamed according to `RenamerName`. RenamerName supports normal text parsing that you'd find in events.
