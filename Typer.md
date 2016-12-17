Typer: Simple, reusable script for typing animations

Suggested use: Drop this onto a gameObject, change Messages size to some value greater than 0. Duration value determines how long the message will be displayed. Something like this would work for adding new messages at runtime, `typer.Messages.Add(new TyperMessage("my message goes here", 10)` (perhaps triggered by a player approaching).